using MetroFramework.Forms;
using StickerDE.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StickerDE
{
    public partial class AnimationForm : MetroForm
    {

        IncrementalSheet DrawingSheet;
        int currentStickers; 
        public AnimationForm(IncrementalSheet sheet)
        {
            InitializeComponent();

            metroStyleManager = Global.StyleManager;
            metroStyleManager.Owner = this;
            StyleManager = metroStyleManager;

            DrawingSheet = new IncrementalSheet();
            DrawingSheet.Initialize(new Random());

            DrawingSheet.CromosomeFromData(sheet.CromosomeData());
            currentStickers = 0; 

        }

        private void AnimationForm_Load(object sender, EventArgs e)
        {
            timer.Start(); 
        }

        private void DrawSticker()
        {
            DrawingSheet.DetermineMap(currentStickers); 
            panel.BackgroundImage = DrawingSheet.GetHeatMap(metroStyleManager.Style);
            currentStickers++;
            currentStickers %= Global.StickersToPlace+1;
            if (currentStickers == 0) { DrawingSheet.ClearMap(); }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            DrawSticker(); 
        }
    }
}
