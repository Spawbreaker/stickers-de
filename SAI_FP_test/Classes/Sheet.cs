using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing; 

namespace StickerDE
{
    // Defines what a Gene is, used in Genetic algorithm, but interpreted lightly in other angloritms. 
    public class Gene
    {
        // Defines what a gene is for the program.        
        public int[] Data = new int[2]; 
        public int X { get { return Data[0]; } set { Data[0] = value; } }
        public int Y { get { return Data[1]; } set { Data[1] = value; } }
        public Gene() { X = 0; Y = 0; }
        public Gene(int X, int Y) { this.X = X; this.Y = Y; }
        public Gene(int[] D) { this.Data = D; }
    }
    // Defines some basic math functions on arrays, required for the new IncrementalSheet
    public static class ArrayFunctions
    {
        public static int[] Add(int[] A, int[] B)
        {
            int[] output = A.ToArray();
            for (int i = 0; i < output.Length; i++)
            {
                output[i] += B[i];
            }
            return output;
        }

        public static int[] Sub(int[] A, int[] B)
        {
            int[] output = A.ToArray();
            for (int i = 0; i < output.Length; i++)
            {
                output[i] -= B[i];
            }
            return output;
        }

        public static int[] Mult(int[] A, double B)
        {
            int[] output = A.ToArray();
            for (int i = 0; i < output.Length; i++)
            {
                output[i] = Convert.ToInt32(output[i] * B);
            }
            return output;
        }

        public static int[] Square(int[] A)
        {
            int[] output = A.ToArray();
            for (int i = 0; i < output.Length; i++)
            {
                output[i] = Convert.ToInt32(output[i] * output[i]);
            }
            return output;
        }
    }
    // The new sheet class that works incrementally instead of with batches 
    public class IncrementalSheet
    {
        /*  Changes the behaviour of the original FastSheet to work incrementally
         *  This means that after one sticker has been placed and accepted, the only thing that changes
         *  is the new sticker. 
         *  
         *  This changes the fitness function to Minimize the distance AND the collissions
         */
        Byte[,] Map;
        public List<Gene> Cromosome; // Interpret Cromosome lightly
        public int Fitness { get; private set; }
        public double dFitness { get; private set; }
        public int Stickers { get; private set; }
        public int MaxCollission;
        public bool HasNoCollissions { get; private set; }

        public IncrementalSheet()
        {
            Stickers = 1;
            Cromosome = new List<Gene>();
            Map = new byte[Global.SheetWidthPixels, Global.SheetHeightPixels];
            Fitness = 0x0fffffff;
        }

        public void Initialize(Random rng)
        {
            // Clears the list of cromosomes, in case it's dirty.
            Cromosome.Clear();

            int x;
            int y;
            // Creates a new set of random cromosomes
            for (int i = 0; i < Stickers; i++)
            {
                x = rng.Next(0, Global.SheetWidthPixels - Global.PaddedSimpleWidthPixels - 1);
                y = rng.Next(0, Global.SheetHeightPixels - Global.PaddedSimpleHeightPixels - 1);

                if (x + Global.PaddedSimpleWidthPixels >= Global.SheetWidthPixels || y + Global.PaddedSimpleHeightPixels >= Global.SheetHeightPixels
                    || x < 0 || y < 0)
                {
                    throw new System.Exception("Selected values out of the matrix range.");
                }

                Cromosome.Add(new Gene(x, y));

            }
            MaxCollission = 0;
            FitLastGene();
            // Cleans up the Map            
            ClearMap();
            HasNoCollissions = false;
        }
        public void ClearMap()
        {
            Array.Clear(Map, 0, Map.Length);
        }

        public void AddSticker(Random rng, int[] cromosome)
        {
            ///<summary>
            /// Initiates the process to add a new sticker to the sheet
            ///</summary>
            ///<param name="rng">An object from Random to continue using it's seed and position.</param>
            ///<param name="cromosome">The entire last best cromosome</param>            
            Cromosome.Clear();
            // Sets this sticker's cromosome to the last one's
            for (int i = 0; i < cromosome.Count() / 2; i++)
            {
                Gene g = new Gene(cromosome[i * 2], cromosome[1 + i * 2]);
                Cromosome.Add(g);
            }
            Stickers = Cromosome.Count + 1;
            // Adds a new, random gene to the cromosome
            Cromosome.Add(new Gene(
                rng.Next(0, Global.SheetWidthPixels - Global.PaddedSimpleWidthPixels - 1),
                rng.Next(0, Global.SheetHeightPixels - Global.PaddedSimpleHeightPixels - 1))
                );
            HasNoCollissions = false;
            ClearMap();
        }
        private void FitLastGene()
        {
            /// <summary>
            /// Makes sure that the X and Y values of the newest Gene are within valid positions to prevent overflows 
            /// </summary>
            Gene g = Cromosome[Stickers - 1];
            if (g.X + Global.PaddedSimpleWidthPixels >= Global.SheetWidthPixels)
            {
                Cromosome[Stickers - 1].X = Global.SheetWidthPixels - Global.PaddedSimpleWidthPixels - 1;
            }
            else if (g.X < 0)
            {
                Cromosome[Stickers - 1].X = 0;
            }
            if (g.Y + Global.PaddedSimpleHeightPixels >= Global.SheetHeightPixels)
            {
                Cromosome[Stickers - 1].Y = Global.SheetHeightPixels - Global.PaddedSimpleHeightPixels - 1;
            }
            else if (g.Y < 0)
            {
                Cromosome[Stickers - 1].Y = 0;
            }
        }
        public void ChangeCromosome(Gene newCromosome)
        {
            ///<summary>
            /// Changes the latest cromosome to a new value.
            ///</summary>
            // Allows to change the last Cromosome in the chain
            Cromosome[Stickers - 1].Data = newCromosome.Data.ToArray();
            FitLastGene(); // This makes sure the cromosome is in a proper place 
            ClearMap();
            HasNoCollissions = false;
        }
        public void ChangeCromosome(int[] newCromosome)
        {
            ///<summary>
            /// Changes the latest cromosome to a new value
            ///</summary>
            // Allows to change the last Cromosome in the chain
            Cromosome[Stickers - 1].Data = newCromosome.ToArray();
            FitLastGene(); // This makes sure the cromosome is in a proper place 
            ClearMap();
            HasNoCollissions = false;
        }
        public void SetHasNoCollissions(bool value)
        {
            ///<summary>
            /// Forces the HasNoCollissions flag to a value, usually, true. 
            ///</summary>
            HasNoCollissions = value;
        }

        public int EvaluateFitness()
        {
            ///<summary>
            /// Determines the sheet's fitness through C and D.
            /// C = Collission Percentage
            /// D = Distance from every-other sticker to this one.
            /// Fitness = ((C+1) * (D+1)) 
            ///</summary>
            double C, D;
            C = GetCollissionPercentage();
            D = GetDistance();
            dFitness = ((C + 1) * (D + 1));
            Fitness = Convert.ToInt32(dFitness);
            return Fitness;
        }
        private double GetCollissionPercentage()
        {
            ///<summary>
            /// Gives the collission percentage of the last sticker placed            
            ///</summary>
            double Collissions = 0, TotalPixels = 0, Percentage;
            TotalPixels = Global.PixCount;
            ClearMap();
            DetermineMap();

            foreach (int n in Map) if (n > 1) Collissions += (n - 1);

            if (Collissions == 0) HasNoCollissions = true;
            else HasNoCollissions = false;

            Percentage = (Collissions) / TotalPixels;
            Percentage *= 100;

            return Percentage;
        }
        private double GetDistance()
        {
            ///<summary>
            /// Gives the distance from the last sticker to all of the new ones through matrix substraction
            ///</summary>
            double DistanceSum = 0;
            for (int i = 0; i < Stickers - 1; i++)
            {
                int[] d = ArrayFunctions.Sub(Cromosome[i].Data, Cromosome[Stickers - 1].Data);
                foreach (int n in d) DistanceSum += Math.Abs(n);
            }

            return DistanceSum;
        }


        private int DetermineMap()
        {
            ///<summary>
            /// Sets up the internal Map variable to reflect the current sheet status with the stickers.
            /// Returns how many "pixels" it modified.
            ///</summary>
            int output = 0;
            FitLastGene();
            try
            {
                foreach (Gene g in Cromosome)
                {
                    // This function is a faster, lightweight version of the regular sticker heat allocation
                    // This works in a byte array instead of a bmp                    

                    for (int x = 0; x < Global.PaddedSimpleWidthPixels; x++)
                        for (int y = 0; y < Global.PaddedSimpleHeightPixels; y++)
                        {
                            if (Global.SimpleBmpMap[x, y])
                            {
                                output++;
                                // Adds 1 to the current collissions on the array
                                Map[x + g.X, y + g.Y]++;
                                // Checks if it's the highest collission point. This will help when making a bmp
                                if (Map[x + g.X, y + g.Y] > MaxCollission) MaxCollission = Map[x + g.X, y + g.Y];
                            }
                        }
                }

            }
            catch
            {
                // Unhandled exception to break the program flow. This shouldn't happen thanks to the Fit function
                throw new Exception("The fit function didn't work as intended");
            }
            
            return output;
        }
        public int DetermineMap(int stickers)
        {
            ///<summary>
            /// Sets up the internal Map variable to reflect the current sheet status with the stickers.
            /// Returns how many "pixels" it modified.           
            ///</summary>
            ///<param name="stickers">Defines how many stickers, out of the ones it has, it will try to place</param>
            int output = 0;
            if (stickers <= this.Stickers)
            {
                for (int i = 0; i < stickers; i++)
                {
                    for (int x = 0; x < Global.PaddedSimpleWidthPixels; x++)
                        for (int y = 0; y < Global.PaddedSimpleHeightPixels; y++)
                        {
                            if (Global.SimpleBmpMap[x, y])
                            {
                                output++;
                                // Adds 1 to the current collissions on the array
                                Map[x + Cromosome[i].X, y + Cromosome[i].Y]++;
                                // Checks if it's the highest collission point. This will help when making a bmp
                                if (Map[x + Cromosome[i].X, y + Cromosome[i].Y] > MaxCollission)
                                    MaxCollission = Map[x + Cromosome[i].X, y + Cromosome[i].Y];
                            }
                        }
                }
            }
            return output;
        }

        private Color GetColorFromMetroStyle(MetroFramework.MetroColorStyle s)
        {
            switch (s)
            {
                case MetroFramework.MetroColorStyle.Black:
                    return MetroFramework.MetroColors.Black;
                case MetroFramework.MetroColorStyle.Blue:
                    return MetroFramework.MetroColors.Blue;
                case MetroFramework.MetroColorStyle.Brown:
                    return MetroFramework.MetroColors.Brown;
                case MetroFramework.MetroColorStyle.Green:
                    return MetroFramework.MetroColors.Green;
                case MetroFramework.MetroColorStyle.Lime:
                    return MetroFramework.MetroColors.Lime;
                case MetroFramework.MetroColorStyle.Magenta:
                    return MetroFramework.MetroColors.Magenta;
                case MetroFramework.MetroColorStyle.Orange:
                    return MetroFramework.MetroColors.Orange;
                case MetroFramework.MetroColorStyle.Pink:
                    return MetroFramework.MetroColors.Pink;
                case MetroFramework.MetroColorStyle.Purple:
                    return MetroFramework.MetroColors.Purple;
                case MetroFramework.MetroColorStyle.Red:
                    return MetroFramework.MetroColors.Red;
                case MetroFramework.MetroColorStyle.Silver:
                    return MetroFramework.MetroColors.Silver;
                case MetroFramework.MetroColorStyle.Teal:
                    return MetroFramework.MetroColors.Teal;
                case MetroFramework.MetroColorStyle.White:
                    return MetroFramework.MetroColors.White;
                case MetroFramework.MetroColorStyle.Yellow:
                    return MetroFramework.MetroColors.Yellow;
                default:
                    return MetroFramework.MetroColors.Magenta;
            }
        }
        public Bitmap GetHeatMap(MetroFramework.MetroColorStyle style)
        {
            ///<summary>
            /// Makes a "Heatmap" with as many colors plus two, where each color is evenly-different from the others
            /// depending on how many collissions the map generated.
            ///</summary>
            Bitmap output = new Bitmap(Global.SheetWidthPixels, Global.SheetHeightPixels);
            // Defines the colors to quickly assign them
            Color[] colors = new Color[MaxCollission + 2];

            // The index represents the collissions, therefore, 0 collissions is transparent.
            colors[0] = Color.Transparent;
            colors[1] = GetColorFromMetroStyle(style);
            for (int i = 2; i < MaxCollission + 1; i++)
            {
                colors[i] = Color.FromArgb(255, colors[1].R / i, colors[1].G / i, colors[1].B / i);
            }

            for (int x = 0; x < Global.SheetWidthPixels; x++)
                for (int y = 0; y < Global.SheetHeightPixels; y++)
                    output.SetPixel(x, y, colors[Map[x, y]]);

            return output;

        }


        public override string ToString()
        {
            ///<summary>
            /// Override of the ToString method to grant some info on the sheet instead 
            ///</summary>
            return "Stickers: " + Stickers.ToString() + " Fitness: " + Fitness.ToString();
        }
        public int[] CromosomeData()
        {
            ///<summary>
            /// Returns a single array from a Cromosome's data
            ///</summary>
            int[] output = new int[Stickers * 2];
            for (int i = 0; i < Stickers; i++)
            {
                output[i * 2] = Cromosome[i].X;
                output[1 + i * 2] = Cromosome[i].Y;
            }
            return output;
        }
        public void CromosomeFromData(int[] data)
        {
            ///<summary>
            /// Sets up the sheet's cromosome data from an array
            ///</summary>
            Cromosome.Clear();
            for (int i = 0; i < data.Count() / 2; i++)
            {
                Gene g = new Gene(data[i * 2], data[1 + i * 2]);
                Cromosome.Add(g);
            }
            Stickers = Cromosome.Count;
            ClearMap();
        }

        public int[] GetLastCromosomeData()
        {
            return Cromosome[Stickers - 1].Data;
        }

        public Gene GetLastCromosome()
        {
            return Cromosome[Stickers - 1];
        }



    }
    // Functionally deprecated, but still used in the UI. Use the IncrementalSheet for development. 
    public class FastSheet
    {
        Byte[,] Map;
        public List<Gene> Cromosome;
        public int Fitness { get; private set; }
        public int MaxFitness { get; private set; }
        public int Stickers;
        public int MaxCollission; 

        public FastSheet()
        {
            Stickers = 1;
            Cromosome = new List<Gene>();
            Map = new byte[Global.SheetWidthPixels, Global.SheetHeightPixels];
            Fitness = 0x0fffffff;
        }

       
        public void Initialize(Random rng)
        {
            // Clears the list of cromosomes, in case it's still full.
            Cromosome.Clear();

            int x;
            int y;
            // Creates a new set of random cromosomes
            for (int i = 0; i < Stickers; i++)
            {
                x = rng.Next(0, Global.SheetWidthPixels - Global.PaddedSimpleWidthPixels - 1);
                y = rng.Next(0, Global.SheetHeightPixels - Global.PaddedSimpleHeightPixels - 1);

                if(x + Global.PaddedSimpleWidthPixels >= Global.SheetWidthPixels || y + Global.PaddedSimpleHeightPixels >= Global.SheetHeightPixels)
                {
                    throw new System.Exception("Unexpected matrix size");
                }

                Cromosome.Add(new Gene(x, y)); 

            }
            MaxCollission = 0;           
            Fitness = 0;
            // Sets Max Fitness to the ammount of pixels of the expected stickers
            MaxFitness = Stickers * Global.PixCount;
            // Cleans up the Map            
            Clear(); 
        }

        public void Clear()
        {
            Array.Clear(Map, 0, Map.Length);
        }

        public void AddSticker(Random rng)
        {
            Stickers++;
            Initialize(rng); 
        }

        public int Max_Evaluate()
        {
            int Collissions = 0;

            Clear(); 
            MaxFitness = HeatAllocate();

            for (int x = 0; x < Global.SheetWidthPixels; x++)
                 for (int y = 0; y < Global.SheetHeightPixels; y++)
                     if (Map[x, y] > 1)
                         Collissions += (Map[x, y] - 1);

            Fitness = MaxFitness - Collissions; 

            if(Fitness < 0)
            {
                throw new Exception("Fitness should not be under 0");
            }

            return Fitness; 
        }

        public int Min_Evaluate()
        {
            int Collissions = 0;

            Clear();
            MaxFitness = HeatAllocate();
            if (MaxFitness != 0x0fffffff)
            {
                for (int x = 0; x < Global.SheetWidthPixels; x++)
                    for (int y = 0; y < Global.SheetHeightPixels; y++)
                        if (Map[x, y] > 1)
                            Collissions += (Map[x, y] - 1);

                Fitness = Collissions;
            }
            // There was an error somewhere, thus, we set it at max fitness so it is the least prioritized
            else Fitness = MaxFitness; 
            return Fitness;
        }
      
        private int HeatAllocate()
        {
            int output = 0;
            try
            {
                foreach(Gene g in Cromosome)
                {
                    // This function is a faster, lightweight version of the regular sticker heat allocation
                    // This works in a byte array instead of a bmp

                    for (int x = 0; x < Global.PaddedSimpleWidthPixels; x++)
                        for (int y = 0; y < Global.PaddedSimpleHeightPixels; y++)
                        {
                            if (Global.SimpleBmpMap[x, y])
                            {
                                output++;
                                // Adds 1 to the current collissions on the array
                                Map[x + g.X, y + g.Y]++;
                                // Checks if it's the highest collission point. This will help when making a bmp
                                if (Map[x + g.X, y + g.Y] > MaxCollission) MaxCollission = Map[x + g.X, y + g.Y]; 
                            }
                        }
                }

            }
            catch
            {
                Clear(); 
                output = 0x0fffffff;
            }
            return output; 
        }

        private Color GetColorFromMetroStyle(MetroFramework.MetroColorStyle s)
        {
            switch (s)
            {
                case MetroFramework.MetroColorStyle.Black:
                    return MetroFramework.MetroColors.Black;
                case MetroFramework.MetroColorStyle.Blue:
                    return MetroFramework.MetroColors.Blue;
                case MetroFramework.MetroColorStyle.Brown:
                    return MetroFramework.MetroColors.Brown;
                case MetroFramework.MetroColorStyle.Green:
                    return MetroFramework.MetroColors.Green;
                case MetroFramework.MetroColorStyle.Lime:
                    return MetroFramework.MetroColors.Lime;
                case MetroFramework.MetroColorStyle.Magenta:
                    return MetroFramework.MetroColors.Magenta;
                case MetroFramework.MetroColorStyle.Orange:
                    return MetroFramework.MetroColors.Orange;
                case MetroFramework.MetroColorStyle.Pink:
                    return MetroFramework.MetroColors.Pink;
                case MetroFramework.MetroColorStyle.Purple:
                    return MetroFramework.MetroColors.Purple;
                case MetroFramework.MetroColorStyle.Red:
                    return MetroFramework.MetroColors.Red;
                case MetroFramework.MetroColorStyle.Silver:
                    return MetroFramework.MetroColors.Silver;
                case MetroFramework.MetroColorStyle.Teal:
                    return MetroFramework.MetroColors.Teal;
                case MetroFramework.MetroColorStyle.White:
                    return MetroFramework.MetroColors.White;
                case MetroFramework.MetroColorStyle.Yellow:
                    return MetroFramework.MetroColors.Yellow;
                default:
                    return MetroFramework.MetroColors.Magenta; 
            }
        }
        public Bitmap GetHeatMap(MetroFramework.MetroColorStyle style)
        {
            Bitmap output = new Bitmap(Global.SheetWidthPixels, Global.SheetHeightPixels);
            // Defines the colors to quickly assign them
            Color[] colors = new Color[MaxCollission+2];
                      
            // The index represents the collissions, therefore, 0 collissions is transparent.
            colors[0] = Color.Transparent;
            colors[1] = GetColorFromMetroStyle(style); 
            for(int i = 2; i <MaxCollission+1; i++)
            {
                colors[i] = Color.FromArgb(255, colors[1].R / i, colors[1].G / i, colors[1].B / i); 
            }

            for (int x = 0; x < Global.SheetWidthPixels; x++)
                for (int y = 0; y < Global.SheetHeightPixels; y++)
                    output.SetPixel(x, y, colors[Map[x, y]]); 

            return output; 

        }
        public void ChangeCromosome(Gene[] newCromosome)
        {
            Cromosome.Clear();
            Cromosome.AddRange(newCromosome);
            Stickers = Cromosome.Count; 
            Clear(); 
        }

        public override string ToString()
        {
            return "Stickers: " + Stickers.ToString() + " Fitness: " + Fitness.ToString() + "/" + MaxFitness.ToString(); 
        }


        public int[] CromosomeData()
        {
            int[] output = new int[Stickers*2];
            for(int i = 0; i < Stickers; i++)
            {
                output[i * 2] = Cromosome[i].X;
                output[1 + i * 2] = Cromosome[i].Y; 
            }
            return output; 
        }
        public void CromosomeFromData(int[] data)
        {
            Cromosome.Clear(); 
            for(int i = 0; i < data.Count() / 2; i++)
            {
                Gene g = new Gene(i * 2, 1 + i * 2);
                Cromosome.Add(g);
            }
            Stickers = Cromosome.Count;
            Clear(); 
        }
    }    
}
