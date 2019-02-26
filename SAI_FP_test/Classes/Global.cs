using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing; 

namespace StickerDE
{
    /*
        A stack of variables considered global to not require to be passed around as parameters between forms.
        This overall reduces the total memory used, preventing the creation of multiple copies of objects, 
        or references to them.
    */
    public static class Global
    {
        // Functions
        public static bool PixelHasColor(Color c)
        {
            // If the color's alpha channel's value is 0, it's considered blank. 
            return c.A != 0;
        }

        // Sticker info
        public static Bitmap OriginalBmp;
        public static Bitmap SimplifiedBmp;
        public static bool[,] SimpleBmpMap; 
        public static int StickerHeightMM = 10;
        public static int StickerWidthMM; 
        public static int SimpleHeightPixels { get { return StickerHeightMM / MilimetersToPixel; } }
        public static int SimpleWidthPixels { get { return StickerWidthMM / MilimetersToPixel; } }
        public static int PaddedSimpleWidthPixels { get { return SimpleWidthPixels + 1 + (PaddingPixels * 2); } }
        public static int PaddedSimpleHeightPixels {  get { return SimpleHeightPixels + 1 + (PaddingPixels * 2);  } }
        public static void SetMap()
        {
            SimpleBmpMap = new bool[PaddedSimpleWidthPixels, PaddedSimpleHeightPixels];
            int i = 0; 
            for (int x = 0; x < PaddedSimpleWidthPixels; x++)
                for(int y = 0; y < PaddedSimpleHeightPixels; y++)
                {
                    SimpleBmpMap[x, y] = PixelHasColor(SimplifiedBmp.GetPixel(x, y));
                    if (SimpleBmpMap[x, y]) i++;
                }
            PixCount = i; 
        }
        public static int PixCount { get; private set;  }

        // Sheet info
        public static Bitmap SheetBmp;
        public static int SheetWidthMM = 594;
        public static int SheetHeightMM = 420; 
        public static int SheetWidthPixels { get { return SheetWidthMM / MilimetersToPixel; } }
        public static int SheetHeightPixels { get { return SheetHeightMM / MilimetersToPixel; } }
        public static int PixelHeatMark { get { return 255 / StickersToPlace; } }
        public static int StickersToPlace = 100; 

        // General info
        public static int MilimetersToPixel = 10; // MTP mm = 1 px

        // Padding info
        public static bool AddPadding = true;
        public static int PaddingMilimeters = 10; 
        public static int PaddingPixels { get { return PaddingMilimeters / MilimetersToPixel; } }

        // Genetic info
        public static int GenerationsBeforePopUp = 100;
        public static int Individues = 10;
        public static int MutationChanceDivisor = 100; // 1 / MCD
        public static int Seed = 0;
        public static bool UseSeed = false; 

        // Fitness options
        #region Fitness Options
        public static bool Transparency { get; private set; } // If set to true it will account transparent pixels in the max fitness.
        public static bool Monoerror { get; private set; } // If set to true any ammount of overlapping counts as 1 error
        public static string FitnessDescription = "No setting has been selected yet.";
        // Monoerror 'true' changes the MaxFitness function to ignore MaxStickers. 
        public static void MostImpactFitnessSettings()
        {
            // This reduces the MaxFitness the most
            FitnessDescription = "Any error pixel will account for more, creating a bigger bridge between good and bad solutions.";
            Transparency = false;
            Monoerror = true; 
        }
        public static void BestFidelityFitnessSettings()
        {
            FitnessDescription = "Filtering the transparency pixels out and accounting for multiple overlapping instances, this setting guarantees the most accurate fitness."; 
            Transparency = false;
            Monoerror = false; 
        }
        public static void HighestFitnessSettings()
        {
            FitnessDescription = "Grants the highest possible fitness value, accounting both transparencies and multiple overlapping instances, this setting gives bloated values.";
            Transparency = true;
            Monoerror = false;
        }
        public static void WorstFitnessSettings()
        {
            FitnessDescription = "Fastest fitness setting, doesn't account multiple overlapping, and doesn't filter out transparency. Not recommended.";
            Transparency = true;
            Monoerror = true;
        }
        #endregion

        // GUI        
        public static MetroFramework.Components.MetroStyleManager StyleManager;

        // ACO
        public static int Intervals = 5; 
    }



}
