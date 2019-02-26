using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickerDE.Classes
{
    public class DifferentialEvolution          
    {
        /// <summary>
        /// This is the Evolutionary Algorithm Manager for Differential Evolution
        /// It handles requests from a DE_Connector to create a series of sheets that
        /// will try to optimize the wasted space between stickers. 
        /// 
        /// This is an adaptation of a deprecated DE class that used to work with FastSheets to work with
        /// IncrementalSheets, increasing it's overall speed.
        /// </summary>
        
        private IncrementalSheet Best;          // A copy of the all-time-best sheet. 
        private IncrementalSheet[] Individues;  // A small, static list of all the individues
        private IncrementalSheet[] Candidates;  // A small, static list for the candidates of the next generation

        private int CurrentGeneration;
        private int CurrentStickers;
        private int ObjectiveStickers;
        private bool Ready;
        private double F = 0.4;
        private double C = 0.2;

        private Random rng;

        public DE_Connector con;

        public DifferentialEvolution()
        {
            CurrentStickers = 1;
            ObjectiveStickers = Global.StickersToPlace;
            con = null; // Event oriented Connection            
            Ready = false;
            // If there is no seed to be used
            if (!Global.UseSeed)
            {
                // Generate a random seed and store it as a seed value
                rng = new Random();
                Global.Seed = rng.Next();
            }
            // Use the stored seed value
            rng = new Random(Global.Seed);

            Individues = new IncrementalSheet[Global.Individues];
            Candidates = new IncrementalSheet[Global.Individues];
            for (int i = 0; i < Global.Individues; i++)
            {
                Individues[i] = new IncrementalSheet();
                Candidates[i] = new IncrementalSheet();
            }

            Initialize();
        }

        public void CheckConsistency()
        {             
            foreach(IncrementalSheet f in Individues)
            {
                foreach(int i in f.GetLastCromosomeData())
                {
                    if (i < 0) throw new Exception("i < 0"); 
                }         
            }
            foreach (IncrementalSheet f in Candidates)
            {
                foreach (int i in f.GetLastCromosomeData())
                {
                    if (i < 0) throw new Exception("i < 0");
                }         
            }
        }
        public void Initialize()
        {
            // This function prepares the individues to a new ammount of stickers
            foreach (IncrementalSheet f in Individues) f.Initialize(rng); 
            foreach (IncrementalSheet f in Candidates) f.Initialize(rng);
            CheckConsistency(); 
            CurrentGeneration = 0;
            Best = new IncrementalSheet();
            Best.Initialize(rng); 
            Ready = true;
        }
        public void AddSticker()
        {
            CurrentStickers++;
            CurrentGeneration = 0;
            foreach (IncrementalSheet f in Individues) f.AddSticker(rng, Best.CromosomeData());
            foreach (IncrementalSheet f in Candidates) f.AddSticker(rng, Best.CromosomeData());
            Best.AddSticker(rng, Best.CromosomeData());
            Best.EvaluateFitness(); 
            Ready = true;
        }

        private void Evaluate()
        {
            for (int i = 0; i < Individues.Count(); i++)
            {
                Individues[i].EvaluateFitness();
                Candidates[i].EvaluateFitness();
                int minFit = Math.Min(Candidates[i].Fitness, Individues[i].Fitness);

                if (Candidates[i].Fitness < Individues[i].Fitness)
                {
                    Individues[i].ChangeCromosome(Candidates[i].GetLastCromosome());
                    Individues[i].SetHasNoCollissions(Candidates[i].HasNoCollissions); 

                }
                if (minFit < Best.Fitness)
                {
                    // 20180503 Patch
                    // ZeroCollissions integration
                    if (Best.HasNoCollissions)
                    {
                        // The solution already is not having any collissions
                        if (Individues[i].HasNoCollissions)
                        {
                            // The new solution has no collissions
                            Best.ChangeCromosome(Individues[i].GetLastCromosome());
                        }
                        else
                        {
                            // A new solution with better fitness has been found, but it shouldn't replace the last one as it
                            // has collissions. This is an extremely rare case, so we set up an event to monitor it. 
                            con.Report(new DE_ReportEventArgs(Individues[i], CurrentGeneration, Individues[i].Stickers)); 
                        }
                    }
                    else
                    {
                        Best.ChangeCromosome(Individues[i].GetLastCromosome());
                    }
                    Best.EvaluateFitness();
                }
            }
        }

        // This is the main function of the class 
        public void Run(object sender, DE_GenerationRequestEventArgs e)
        {
            if (Ready)
            {
                CheckConsistency(); 
                Ready = false;
                int idx = 0;
                foreach (IncrementalSheet individue in Individues)
                {
                    // Diferential Evolution Implementation
                    IncrementalSheet P1, P2, P3;
                    do { P1 = Individues[rng.Next(0, Individues.Count() - 1)]; }
                    while (P1 == individue);
                    do { P2 = Individues[rng.Next(0, Individues.Count() - 1)]; }
                    while (P2 == individue || P2 == P1);
                    do { P3 = Individues[rng.Next(0, Individues.Count() - 1)]; }
                    while (P3 == individue || P3 == P2 || P3 == P1);

                    int[] data = ArrayFunctions.Add(P3.GetLastCromosomeData(), ArrayFunctions.Mult(ArrayFunctions.Sub(P1.GetLastCromosomeData(), P2.GetLastCromosomeData()), F));
                    int Mutated = rng.Next(0, data.Count());
                    for (int i = 0; i < data.Count(); i++)
                    {
                        double rcj = rng.NextDouble();
                        // If it rolls low or is not the one that is meant to be mutated
                        if (rcj >= C && i != Mutated || data[i] < 0)
                        {
                            // It returns it to the previous value
                            data[i] = individue.GetLastCromosomeData()[i];
                        }
                        else { } // Otherwise it stays mutated
                    }
                    Candidates[idx].ChangeCromosome(data);
                    idx++;
                }
                Evaluate();
                CurrentGeneration++;
                SendUpdate();
                Ready = true;
            }
        }

        private void SendUpdate()
        {
            DE_ReportEventArgs args = new DE_ReportEventArgs(Best, CurrentGeneration, CurrentStickers);
            con.Respond(args);
        }
        private void RigFirstSticker()
        {
            ///<summary>
            /// The program should rig the first sticker's position to 0,0 to maximize it's efficiency
            /// But it's left as is, with a random position, so it will show variety when executed
            ///</summary>
            if (CurrentStickers == 1)
            {
                Best = new IncrementalSheet();
                Best.Initialize(rng); 
                Best.ChangeCromosome(new Gene(0, 0));  
            }
        }
    }

    public class DE_Connector                   
    {
        /// <summary>
        /// An intermediary class between DifferentialEvolution and ProcessingForm
        /// It will handle communication between them two as an interface
        /// </summary>
        /// <param name="sender">Object that sends this request</param>
        /// <param name="e">Arguments for every event</param>
        public delegate void GenerationDoneHandler(object sender, DE_ReportEventArgs e);
        public event GenerationDoneHandler GenerationDone;
        public delegate void GenerationRequestHandler(object sender, DE_GenerationRequestEventArgs e);
        public event GenerationRequestHandler GenerationRequest;
        public delegate void WeirdCaseHandler(object sender, DE_ReportEventArgs e);
        public event WeirdCaseHandler WeirdCase; 

        public DE_Connector(GenerationDoneHandler catcher, GenerationRequestHandler sender, WeirdCaseHandler weirdCase)
        {
            GenerationDone += catcher;
            GenerationRequest += sender;
            WeirdCase = weirdCase; 
        }

        public void Request()
        {
            GenerationRequest(this, new DE_GenerationRequestEventArgs());
        }

        public void Respond(DE_ReportEventArgs e)
        {
            GenerationDone(this, e);
        }

        public void Report(DE_ReportEventArgs e)
        {
            // Only triggers in the 'weird case' described in ProcessForm
            WeirdCase(this, e);
        }
    }
    public class DE_GenerationRequestEventArgs  : System.EventArgs
    {
        /// <summary>
        /// EventArgs for a GenerationRequest event. It's blank, as it's used as a notification only.
        /// </summary>
        public DE_GenerationRequestEventArgs() { }
    }
    public class DE_ReportEventArgs             : System.EventArgs
    {
        /// <summary>
        /// EventArgs for a generated Report
        /// </summary>
        public IncrementalSheet Best;
        public int Gen;
        public int Stickers;
        public DE_ReportEventArgs(IncrementalSheet Best, int Gen, int Stickers)
        {
            this.Best = Best;
            this.Gen = Gen;
            this.Stickers = Stickers;
        }

    }
    public enum AlgorithmManager_States         
    {
        STARTING_UP, // The AM hasn't been initialized 
        READY,    // The AM is ready to work and is waiting to receive a .Run()
        WAITING, // The AM is busy, the form is waiting for an event to continue
        //DONE        // The AM hasn't been cleaned up, nor reinitialized with more stickers. // Deprecated state
        PLACEHOLDER // AM shouldn't ever be in this state, considered for future development
    };


}
