using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MetroFramework.Forms;
using MetroFramework;
using MetroFramework.Controls;

namespace StickerDE
{
    public partial class MainForm : MetroForm 
    {

        public string ImageRoute = ""; 

        public MainForm()
        {
            InitializeComponent();
            goBtn.Enabled = false; 
        }

        #region Theme
        private void ChangeThemeBtn_Click(object sender, EventArgs e)
        {
            metroStyleManager.Theme = metroStyleManager.Theme == MetroThemeStyle.Light ? MetroThemeStyle.Dark : MetroThemeStyle.Light;
            Global.StyleManager = metroStyleManager;
        }

        private void ChangeColorBtn_Click(object sender, EventArgs e)
        {
            Random m = new Random(); 
            int next = m.Next(0, 13);
            metroStyleManager.Style = (MetroColorStyle)next;
            Global.StyleManager = metroStyleManager;
        }

        private void MetroMainForm_Load(object sender, EventArgs e)
        {
            metroStyleManager = Global.StyleManager;
            metroStyleManager.Owner = this; 
            this.StyleManager = metroStyleManager;
            goBtn.Text = "Waiting";
            LoadDefaultValues(); 
        }




        #endregion

        private void LoadDefaultValues()
        {
            compressionTb.Text = Global.MilimetersToPixel.ToString();
            imgHeightTb.Text = Global.StickerHeightMM.ToString();
            paddingMmTb.Text = Global.PaddingMilimeters.ToString();
            stickerCountTb.Text = Global.StickersToPlace.ToString();
            sheetHeightTb.Text = Global.SheetHeightMM.ToString();
            sheetWidthTb.Text = Global.SheetWidthMM.ToString();
            individuesTb.Text = Global.Individues.ToString();
            GenerationsTb.Text = Global.GenerationsBeforePopUp.ToString();
            mutationTb.Text = Global.MutationChanceDivisor.ToString(); 
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            try
            {
                ofd.ShowDialog();
                ImageRoute = ofd.FileName;
                Global.OriginalBmp = new Bitmap(ImageRoute);
                ofd.Dispose();
                goBtn.Enabled = true;
                goBtn.Text = "Go!";
            }
            catch
            {
                goBtn.Enabled = false;
                goBtn.Text = "Waiting"; 
            }
        }
        private void viewBtn_Click(object sender, EventArgs e)
        {
            if (goBtn.Enabled)
            {
                SheetDisplayForm ivf = new SheetDisplayForm("Preview", Global.OriginalBmp);
                ivf.Show(); 
            }
        }


        #region TextboxValidation 
        private enum ValidationErrorType { UNDER_MIN, ABOVE_MAX, UNEXPECTED_TYPE, NO_ERROR }
        private string GetValidationErrorString(ValidationErrorType v, string min, string max)
        {
            /// <summary>
            /// Checks if the selected text box's numeric value is in a valid range           
            /// </summary> 
            /// <param name="v">Used to denote the kind of error</param>
            /// <param name="min">Determines the minimum valid value</param>
            /// <param name="max">Determines the maximum valid value</param>
            switch (v)
            {
                case ValidationErrorType.ABOVE_MAX: return "The value is above the maximum value of: " + max;
                case ValidationErrorType.UNDER_MIN: return "The value is under the minimum value of: " + min;
                case ValidationErrorType.UNEXPECTED_TYPE: return "Please, only introduce numbers";
                case ValidationErrorType.NO_ERROR: return "No error";
                default: return "Unexpected Validation type"; 
            }

        }
        private ValidationErrorType ValidateNewText(string Text, int min, int max, ref int Var)
        {
            /// <summary>
            /// Checks if the new text in an input textbox is valid
            /// </summary>
            /// <param name="Text">Text to be analized</param>
            /// <param name="max">Maximum valid value</param>
            /// <param name="min">Minimum valid value</param>
            /// <param name="Var">Will hold a numeric value if there's no error in the value passed</param>
            int newValue;
            if (max < min) throw new Exception("Max must be larger than Min."); 
            try               
            {
                newValue = Convert.ToInt32(Text); 

                if(newValue < min) { return ValidationErrorType.UNDER_MIN; }
                else if (newValue > max) { return ValidationErrorType.ABOVE_MAX; }
                else                 
                {
                    Var = newValue;
                    return ValidationErrorType.NO_ERROR; 
                }

            }
            catch(FormatException)
            {                
                return ValidationErrorType.UNEXPECTED_TYPE; 
            }
        }
        private void OnlyNumbersTB(MetroTextBox tb, int min, int max, ref int var)
        {
            ///<summary>
            /// Validates for a textbox to only hold numbers.            
            /// </summary>
            /// <param name="tb">The textbox that will be evaluated</param>
            /// <param name="min">Determines the minimum valid value</param>
            /// <param name="max">Determines the maximum valid value</param>
            /// <param name="Var">The variable that will be modified. It's only modified if the validation succeeds.</param>
            ValidationErrorType response = ValidateNewText(tb.Text, min, max, ref var);
            if (response != ValidationErrorType.NO_ERROR)
            {
                tb.SelectAll();
                MetroMessageBox.Show(this, GetValidationErrorString(response, min.ToString(), max.ToString()), "Error!"); 
            }
        }
        #region Every Textbox's TextChanged Method
        private void compressionTb_TextChanged(object sender, EventArgs e)
        {
            OnlyNumbersTB(compressionTb, 1, 100, ref Global.MilimetersToPixel);
        }

        private void imgHeightTb_TextChanged(object sender, EventArgs e)
        {
            OnlyNumbersTB(imgHeightTb, 10, Global.SheetHeightMM, ref Global.StickerHeightMM);

        }

        private void paddingMmTb_TextChanged(object sender, EventArgs e)
        {
            OnlyNumbersTB(paddingMmTb, 0, 100, ref Global.PaddingMilimeters);
        }

        private void stickerCountTb_TextChanged(object sender, EventArgs e)
        {
            OnlyNumbersTB(stickerCountTb, 1, 256, ref Global.StickersToPlace);
        }

        private void sheetHeightTb_TextChanged(object sender, EventArgs e)
        {
            OnlyNumbersTB(sheetHeightTb, 100, 2000, ref Global.SheetHeightMM);
        }

        private void sheetWidthTb_TextChanged(object sender, EventArgs e)
        {
            OnlyNumbersTB(sheetWidthTb, 100, 2000, ref Global.SheetWidthMM);
        }

        private void individuesTb_TextChanged(object sender, EventArgs e)
        {
            OnlyNumbersTB(individuesTb, 1, 100, ref Global.Individues);
        }

        private void GenerationsTb_TextChanged(object sender, EventArgs e)
        {
           OnlyNumbersTB(GenerationsTb, 1, 5000, ref Global.GenerationsBeforePopUp);
        }

        private void mutationTb_TextChanged(object sender, EventArgs e)
        {
            OnlyNumbersTB(mutationTb, 10, 1000, ref Global.MutationChanceDivisor); 
        }
        #endregion
        #endregion

        private void goBtn_Click(object sender, EventArgs e)
        {
            ProcessForm mpf = new ProcessForm(this);
            mpf.Show();
            this.Hide();
        }
    }
}
