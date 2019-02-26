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
    public partial class OutputForm : MetroForm
    {
        IncrementalSheet sheet; 
        public OutputForm(IncrementalSheet newSheet)
        {
            InitializeComponent();
            metroStyleManager = Global.StyleManager;
            metroStyleManager.Owner = this;
            StyleManager = metroStyleManager;
            sheet = newSheet;
            CreatePicture(); 
        }

        Bitmap output;

        private Bitmap ResizeImage(Image image, int width, int height)
        {
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

        private void CreatePicture()
        {
            

            Bitmap smallerImage = ResizeImage(Global.OriginalBmp, Global.StickerWidthMM * 4, Global.StickerHeightMM * 4); 

            output = new Bitmap(Convert.ToInt32(4 * Global.SheetWidthMM), Convert.ToInt32(4 * Global.SheetHeightMM));
            Graphics g = Graphics.FromImage(output);
            g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
            smallerImage.MakeTransparent(); 
            foreach(Gene gene in sheet.Cromosome)
            {
                g.DrawImage(smallerImage, 
                    Convert.ToInt32(4* ((gene.X * Global.MilimetersToPixel) + (Global.PaddingMilimeters ))),
                    Convert.ToInt32(4 *((gene.Y * Global.MilimetersToPixel) + (Global.PaddingMilimeters )))); 
            }

            panel.BackgroundImage = output; 
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            output.Save("Bear.bmp");
            this.Close(); 
        }
    }
}
