using MetroFramework; 
using MetroFramework.Forms;
using StickerDE.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StickerDE
{
    public partial class ProcessForm : MetroForm
    {
        // Parent, to call after this window closes.
        MetroForm parent; 
        // Internal data about the stickers
        private int CurrentStickers;
        private int CurrentGenerations;
        private int CurrentBestFitness;
        private IncrementalSheet[] FBestSheets; 
        // Internal variables about the program
        private bool AutoRun;
        private bool ProcessingDone;
        private bool EventProcessingDone; 
        private AlgorithmManager_States State;
        private bool RunDone; 
        // Algorythm objects        
        private DE_Connector   Messenger;
        private DifferentialEvolution De; 
        // Functions
        public ProcessForm(MetroForm parent)
        {
            InitializeComponent();
            this.parent = parent; 
        }
        #region Initialization

        private void _SetInitialParameters()
        {
            CurrentStickers = 1;
            CurrentGenerations = 0;
            CurrentBestFitness = 0;
            State = AlgorithmManager_States.READY;
            AutoRun = false;
            ProcessingDone = false;
            EventProcessingDone = true;
            RunDone = false; 
        }
        private void _InitializeObjects()
        {
            FBestSheets = new IncrementalSheet[Global.StickersToPlace]; 
            
            De = new DifferentialEvolution(); 
            Messenger = new DE_Connector(Catch_GenerationDone, De.Run, Catch_WeirdCase);
            De.con = Messenger; 
        }
        private void _InitializeUI()
        {            
            stickerPb.Maximum = Global.StickersToPlace;
            metroStyleManager = Global.StyleManager;
            metroStyleManager.Owner = this;
            StyleManager = metroStyleManager;

            seeBtn.Enabled = false;
        }
        private void MetroProcessingForm_Load(object sender, EventArgs e)
        {
            _SetInitialParameters();
            _InitializeObjects(); 
            _InitializeUI();
            PrepareImage();
        }

        #endregion
        #region Image Preparation
        private void PrepareImage()
        {

            float ratio = (float)Global.OriginalBmp.Width / (float)Global.OriginalBmp.Height;
            Global.StickerWidthMM = Convert.ToInt32(Global.StickerHeightMM * ratio);

            Bitmap scaledImg = ResizeImage(Global.OriginalBmp, Global.SimpleWidthPixels, Global.SimpleHeightPixels);
            Global.SimplifiedBmp = SimplifyImage(scaledImg);
            Global.SetMap();

        }

        private bool PixelIsFilling(Bitmap pic, int x, int y)
        {
            for (int i = -1; i <= 1; i++) for (int j = -1; j <= 1; j++)
                {
                    if (x + i >= 0 && y + j >= 0 && x + i < pic.Width && y + j < pic.Height)
                    {
                        if (!Global.PixelHasColor(pic.GetPixel(x + i, y + j))) return false;
                    }
                }
            return true;
        }
        private Bitmap AddPadding(Bitmap original, int padding)
        {
            int i, j, k, l;
            Bitmap output = new Bitmap(original);
            // For X, Y
            for (i = 0; i < output.Width; i++) for (j = 0; j < output.Height; j++)
                {
                    // If (X,Y) has color
                    if (Global.PixelHasColor(original.GetPixel(i, j)) && !PixelIsFilling(original, i, j))
                    {
                        for (k = -padding; k <= padding; k++) for (l = -padding; l <= padding; l++)
                            {
                                if (i + k < output.Width && j + l < output.Height && i + k >= 0 && j + l >= 0)
                                {
                                    if (!Global.PixelHasColor(original.GetPixel(i + k, j + l)))
                                    {
                                        output.SetPixel(i + k, j + l, Color.Gray);
                                    }
                                }
                            } // Endfor i,j

                    }

                }// Endfor X,Y
            return output;
        }
        private Bitmap ResizeImage(Image image, int _width, int _height)
        {
            int width = _width, height = _height;
            if (width == 0) width++;
            if (height == 0) height++;
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
        public Bitmap SimplifyImage(Bitmap image)
        {
            Bitmap output;
            int i, j;
            int padding = Global.PaddingPixels;
            int count = 0;
            output = new Bitmap(image.Width + (padding * 2) + 1, image.Height + (padding * 2) + 1);
            for (i = 0; i < image.Width; i++) for (j = 0; j < image.Height; j++)
                {
                    if (Global.PixelHasColor(image.GetPixel(i, j)))
                    {
                        // Negro
                        output.SetPixel(i + padding, j + padding, Color.Black);
                        count++;
                    }
                    else
                    {
                        // Transparente
                        output.SetPixel(i + padding, j + padding, Color.FromArgb(0));
                    }
                } // For i,j


            output.Save("Simplified.bmp");
            if (Global.PaddingPixels > 0)
            {
                output = AddPadding(output, Global.PaddingPixels);
            }
            return output;
        }
        #endregion
        #region UI Update
        private void _updateStrings()
        {
            
            stickersLbl.Text = CurrentStickers.ToString() + "/" + Global.StickersToPlace.ToString();
            generationsLbl.Text = CurrentGenerations.ToString() + "/" + Global.GenerationsBeforePopUp.ToString();
            if(CurrentStickers < Global.StickersToPlace)
            {
                if(FBestSheets[CurrentStickers - 1] != null)
                {
                    fitnessLbl.Text = CurrentBestFitness.ToString() +  " [" + ((FBestSheets[CurrentStickers-1].HasNoCollissions)?"Done":"Not done") + "]"; 
                }
                else
                {
                    fitnessLbl.Text = "N/A"; 
                }
            }
            
        }
        private void _updateProgressBars()
        {
            generationPb.Maximum = Global.GenerationsBeforePopUp;
            generationPb.Value = CurrentGenerations;

            stickerPb.Maximum = Global.StickersToPlace; 
            stickerPb.Value = CurrentStickers;
        }
        private void _ChangeRunningButtons(bool value)
        {
            doOneBtn.Enabled = value;
            runBtn.Enabled = value;
            stopBtn.Enabled = !value; 
        }
        private void _DisableRunningButtons()
        {
            doOneBtn.Enabled = false;
            runBtn.Enabled = false;
            stopBtn.Enabled = false;
        }
        #endregion
        #region Events
        private void Catch_GenerationDone(object sender, DE_ReportEventArgs e)
        {
            ///<summary>
            /// This is the method responsible for receiving the processor object's generations.
            /// It will automatically determine what's next in it's own, little state machine. 
            /// </summary>
            EventProcessingDone = false; 

            // Processes the data received from 'e'
            _ProcessReport(e); 
            // After receiving the first one, this enables the ability to see the current best.
            seeBtn.Enabled = true;
            // Select what to do with the new data... 
            switch (_SelectNextStep())
            {
                case FGAM_STEP.NEXT_GENERATION: _NextGeneration(); break;
                case FGAM_STEP.NEXT_STICKER: _NextSticker(); break;
                case FGAM_STEP.DONE_GENERATIONS: _DoneGenerations(); break;
                case FGAM_STEP.DONE_STICKERS: _DoneStickers(); break;                 
            }
           
            // If the process was meant to only happen once
            if (!AutoRun)
            {
                timer.Stop();
                // You can click the run buttons
                _ChangeRunningButtons(true);
            }

            _updateStrings();
            _updateProgressBars();
            EventProcessingDone = true;
        }
        private void Catch_WeirdCase(object sender, DE_ReportEventArgs e)
        {
            /// <summary>
            /// There is a specific case considered a "Weird case" which would be an incomplete solution
            /// that somehow has a better score than a complete one. It's known to be mathematically possible, 
            /// but it hasn't showed up in around 50 tests this program has been through.
            /// 
            /// The program doesn't add it to a solution pile if there has been any complete solutions, but,
            /// it's so rare I wanted to get a notification.
            /// </summary>
            MessageBox.Show("A weird case has happened! It's alright. Hopefully it will go away.");
        }
        #endregion
        #region Responses to events
        // This is the state machine for the processes
        private enum FGAM_STEP {
            NEXT_GENERATION,    // The default response. The program can continue with the next generation on this set of stickers.
            NEXT_STICKER,       // The program must increase the ammount of stickers before continuing.
            DONE_GENERATIONS,   // The program got to the limit of generations without finding a 100% response. Action must be taken.
            DONE_STICKERS,      // The program found all the stickers specified by the user.
            Z_PLACEHOLDER       // Placeholder for any future implementations
        }
        private void _ProcessReport(DE_ReportEventArgs e)
        {
            if (FBestSheets[CurrentStickers - 1] == null) FBestSheets[CurrentStickers - 1] = new IncrementalSheet();

            FBestSheets[CurrentStickers - 1].CromosomeFromData(e.Best.CromosomeData());
            FBestSheets[CurrentStickers - 1].EvaluateFitness();
            FBestSheets[CurrentStickers - 1].SetHasNoCollissions(e.Best.HasNoCollissions); 
            CurrentBestFitness = FBestSheets[CurrentStickers - 1].Fitness;

            _UpdateComboBox(); 

            CurrentGenerations = e.Gen;
            CurrentStickers = e.Stickers;

        }
        private void _DoneGenerations()
        {   
            MetroMessageBox.Show(this, "Program was unable to put " + CurrentStickers.ToString() + " stickers.\n");
            WrapUp(); 
        }
        private void _NextGeneration()
        {
            State = AlgorithmManager_States.READY; 
            // Doesn't do anything
        }
        private void _DoneStickers()
        {
            WrapUp();
            RunDone = true;
            seeBtn.Text = "See animation"; 
        }
        private void _NextSticker()
        {
            // Audo queue for a generation being done.
            Console.Beep(1400, 100);
            // Increase the ammount of stickers.
            CurrentStickers++;
            // Failproof check
            if (CurrentStickers > Global.StickersToPlace)
            {
                MetroMessageBox.Show(this, "The process is done already.", "Can't restart for more stickers.");
                WrapUp();
            }
            //      If the failproof check passes...
            else
            {
                // Restart generations
                CurrentGenerations = 0;
                // Redefine the fitness
                CurrentBestFitness = 1;
                // Set the GAM_STATE to start a new generation
                State = AlgorithmManager_States.STARTING_UP;
            }
        }
        private FGAM_STEP _SelectNextStep()
        {
            // With the current data, this function will return an enumerated type with a response
            // If there are no more generations to be done... 
            if(CurrentGenerations >= Global.GenerationsBeforePopUp)
            {
                // If the program is done... 
                 if (CurrentStickers >= Global.StickersToPlace)
                {
                    return FGAM_STEP.DONE_STICKERS; 
                }
                else if (FBestSheets[CurrentStickers - 1].HasNoCollissions)
                {
                 // The program found a solution
                    return FGAM_STEP.NEXT_STICKER; 
                }
                else
                {
                // The program couldn't find a solution in the set generations
                    return FGAM_STEP.DONE_GENERATIONS;
                }
            }                             
            //      If the program still has generations to go... 
            else return FGAM_STEP.NEXT_GENERATION; 
            
        }
        private void WrapUp()
        {
            // This function is meant to be called as a wrap-up
            // This function can be called with the following conditions: 
            //      ALL the stickers have been placed successfully
            //      The program couldn't place all stickers at least once, and the user didn't want to continue
            //      The program tried to call for a higher than expected ammount of stickers. 
            // Disable the timer
            timer.Stop(); 
            // Disable the buttons that let the user call functions
            _DisableRunningButtons();
            ProcessingDone = true;
            OutputForm of = new OutputForm(FBestSheets[CurrentStickers-1]);
            of.Show(); 
        }
        #endregion   
        #region Button Behavior
        private void doOneBtn_Click(object sender, EventArgs e)
        {
            /// <summary>
            /// Asks the program to do a single sticker
            /// </summary>
            AutoRun = false;
            EventProcessingDone = true; 
            // You can not press the continue button, but you can press the pause one
            _ChangeRunningButtons(false);
            timer.Start(); 
        }    
        private void stopBtn_Click(object sender, EventArgs e)
        {
            /// <summary>
            /// Stops the timer, essentially pausing the progress
            /// </summary>
            AutoRun = false;
            timer.Stop(); 
            _ChangeRunningButtons(true); 
        }
        private void seeBtn_Click(object sender, EventArgs e)
        {
            /// <summary>
            /// Requests to visualize a sticker sheet, or, in case it's done, an animation on the progress of it. 
            /// </summary>
            int i = CurrentStickers-1;
            IncrementalSheet tmp = FBestSheets[i];            

            while (tmp == null) {
                i--;
                if (i < 0) return; 
                tmp = FBestSheets[i]; 
            }

            if (RunDone)
            {
                AnimationForm af = new AnimationForm(tmp);
                af.Show(); 
            }
            else
            {
                tmp.EvaluateFitness(); 

                SheetDisplayForm mivf = new SheetDisplayForm(
                    "Fitness: " + tmp.Fitness.ToString()+ ".", tmp.GetHeatMap(metroStyleManager.Style)
                    );
                mivf.Show(); 

            }
        }
        private void runBtn_Click(object sender, EventArgs e)
        {
            /// <summary>
            /// Starts the program to automatically work on the stickers set before.
            /// It also continues the progress if it was paused.
            /// </summary>
            EventProcessingDone = true;
            AutoRun = true;
            timer.Start();
            _ChangeRunningButtons(false); 
        }

        #endregion
        private void MainTimer_Tick(object sender, EventArgs e)
        {
            /// This is the heart of the program.
            /// The timer will now run a state-machine: Setting up, Ready to work, or Working.
            /// It's done this way to keep the form's controls, and so it doesn't end up in race conditions.
            
            // If it's done, then we wrap up.
            if (CurrentStickers > Global.StickersToPlace || ProcessingDone ) { WrapUp(); return; }
            // If it isn't done...
            if (EventProcessingDone)
            {
                switch (State)
                {                    
                    case AlgorithmManager_States.STARTING_UP:
                        De.AddSticker(); 
                        State = AlgorithmManager_States.READY;
                        break;
                    case AlgorithmManager_States.READY:
                        State = AlgorithmManager_States.WAITING;
                        // We request a new sticker
                        Messenger.Request(); 
                        break;
                    case AlgorithmManager_States.WAITING:
                        break;
                }
            }
            // Then we update the UI 
            _updateProgressBars();
            _updateStrings(); 
        }
        #region 20180322 Patch
        private void _UpdateComboBox()
        {
            /// <summary>
            /// Automatically updates the combobox with new sheets after every update.
            /// This method currently causes the combobox to stutter visually while it's processing.
            /// The combobox could be disabled to prevent this from being an issue, but it's left as is for testing purposes.
            /// </summary>
            int i;
            seeCb.Items.Clear(); 
            for (i= 0; i < Global.StickersToPlace; i++)
            {
                if (FBestSheets[i] != null)
                {
                    seeCb.Items.Add("Click to see: " + FBestSheets[i].ToString()); 
                }
            }
        }
        private void seeCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            /// <summary>
            /// Checks when the user wants to see a specific sheet and, if possible, shows it to them
            /// </summary>
            int index = seeCb.SelectedIndex;
            try
            {
                if(FBestSheets[index] != null)
                {
                    // Gets the selected sheet from the index
                    IncrementalSheet selectedSheet = FBestSheets[index];
                    // Creates the new window 
                    SheetDisplayForm sdf = new SheetDisplayForm(
                        "Fitness: " + selectedSheet.Fitness.ToString() + ".", selectedSheet.GetHeatMap(metroStyleManager.Style)
                        );
                    // Displays the window
                    sdf.Show();
                }
            }
            catch(Exception ex)
            {
                // This shouldn't happen, but it never hurts to have a pop-up.
                MessageBox.Show("An unexpecte error has happened: " + ex.Message);
            }
        }
        #endregion

        private void ProcessForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // The form shows it's parent when it's closed
            parent.Show();
        }
    }
}
