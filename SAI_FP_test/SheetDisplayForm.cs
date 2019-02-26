using MetroFramework.Forms;
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
    public partial class SheetDisplayForm : MetroForm
    {
        public SheetDisplayForm(string name, Bitmap bmp)
        {
            InitializeComponent();
            imagePb.Image = bmp;
            this.Text = name; 
            this.PerformAutoScale();
        }

        private void ImageViewForm_Load(object sender, EventArgs e)
        {
            metroStyleManager = Global.StyleManager;
            metroStyleManager.Owner = this; 
            StyleManager = metroStyleManager; 
        }
    }
}
