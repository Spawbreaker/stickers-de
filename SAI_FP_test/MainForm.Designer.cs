namespace StickerDE
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.metroStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.styleBtn = new MetroFramework.Controls.MetroTile();
            this.themeBtn = new MetroFramework.Controls.MetroTile();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.sheetWidthTb = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.sheetHeightTb = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.stickerCountTb = new MetroFramework.Controls.MetroTextBox();
            this.paddingMmTb = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.imgHeightTb = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.viewBtn = new MetroFramework.Controls.MetroTile();
            this.loadBtn = new MetroFramework.Controls.MetroTile();
            this.metroTabPage3 = new MetroFramework.Controls.MetroTabPage();
            this.compressionTb = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.mutationTb = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel14 = new MetroFramework.Controls.MetroLabel();
            this.GenerationsTb = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.individuesTb = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel12 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel13 = new MetroFramework.Controls.MetroLabel();
            this.goBtn = new MetroFramework.Controls.MetroTile();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).BeginInit();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage2.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.metroTabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroStyleManager
            // 
            this.metroStyleManager.Owner = this;
            this.metroStyleManager.Style = MetroFramework.MetroColorStyle.Magenta;
            this.metroStyleManager.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPage2);
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Controls.Add(this.metroTabPage3);
            this.metroTabControl1.Location = new System.Drawing.Point(23, 62);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 2;
            this.metroTabControl1.Size = new System.Drawing.Size(397, 262);
            this.metroTabControl1.TabIndex = 1;
            this.metroTabControl1.UseSelectable = true;
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.metroLabel10);
            this.metroTabPage2.Controls.Add(this.styleBtn);
            this.metroTabPage2.Controls.Add(this.themeBtn);
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.HorizontalScrollbarSize = 10;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(389, 220);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "Application";
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 10;
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel10.Location = new System.Drawing.Point(0, 3);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(53, 25);
            this.metroLabel10.TabIndex = 18;
            this.metroLabel10.Text = "Color";
            this.metroLabel10.UseStyleColors = true;
            // 
            // styleBtn
            // 
            this.styleBtn.ActiveControl = null;
            this.styleBtn.Location = new System.Drawing.Point(3, 117);
            this.styleBtn.Name = "styleBtn";
            this.styleBtn.Size = new System.Drawing.Size(80, 80);
            this.styleBtn.TabIndex = 3;
            this.styleBtn.Text = "Change\r\nColor";
            this.styleBtn.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.styleBtn.UseSelectable = true;
            this.styleBtn.UseStyleColors = true;
            this.styleBtn.Click += new System.EventHandler(this.ChangeColorBtn_Click);
            // 
            // themeBtn
            // 
            this.themeBtn.ActiveControl = null;
            this.themeBtn.Location = new System.Drawing.Point(3, 31);
            this.themeBtn.Name = "themeBtn";
            this.themeBtn.Size = new System.Drawing.Size(80, 80);
            this.themeBtn.TabIndex = 2;
            this.themeBtn.Text = "Change\r\nTheme";
            this.themeBtn.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.themeBtn.UseSelectable = true;
            this.themeBtn.UseStyleColors = true;
            this.themeBtn.Click += new System.EventHandler(this.ChangeThemeBtn_Click);
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.sheetWidthTb);
            this.metroTabPage1.Controls.Add(this.metroLabel6);
            this.metroTabPage1.Controls.Add(this.sheetHeightTb);
            this.metroTabPage1.Controls.Add(this.metroLabel7);
            this.metroTabPage1.Controls.Add(this.metroLabel5);
            this.metroTabPage1.Controls.Add(this.metroLabel4);
            this.metroTabPage1.Controls.Add(this.stickerCountTb);
            this.metroTabPage1.Controls.Add(this.paddingMmTb);
            this.metroTabPage1.Controls.Add(this.metroLabel3);
            this.metroTabPage1.Controls.Add(this.imgHeightTb);
            this.metroTabPage1.Controls.Add(this.metroLabel2);
            this.metroTabPage1.Controls.Add(this.metroLabel1);
            this.metroTabPage1.Controls.Add(this.viewBtn);
            this.metroTabPage1.Controls.Add(this.loadBtn);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(389, 220);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Image";
            this.metroTabPage1.UseStyleColors = true;
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // sheetWidthTb
            // 
            // 
            // 
            // 
            this.sheetWidthTb.CustomButton.Image = null;
            this.sheetWidthTb.CustomButton.Location = new System.Drawing.Point(116, 1);
            this.sheetWidthTb.CustomButton.Name = "";
            this.sheetWidthTb.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.sheetWidthTb.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.sheetWidthTb.CustomButton.TabIndex = 1;
            this.sheetWidthTb.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.sheetWidthTb.CustomButton.UseSelectable = true;
            this.sheetWidthTb.CustomButton.Visible = false;
            this.sheetWidthTb.Lines = new string[0];
            this.sheetWidthTb.Location = new System.Drawing.Point(233, 109);
            this.sheetWidthTb.MaxLength = 32767;
            this.sheetWidthTb.Name = "sheetWidthTb";
            this.sheetWidthTb.PasswordChar = '\0';
            this.sheetWidthTb.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.sheetWidthTb.SelectedText = "";
            this.sheetWidthTb.SelectionLength = 0;
            this.sheetWidthTb.SelectionStart = 0;
            this.sheetWidthTb.ShortcutsEnabled = true;
            this.sheetWidthTb.Size = new System.Drawing.Size(138, 23);
            this.sheetWidthTb.TabIndex = 16;
            this.sheetWidthTb.UseSelectable = true;
            this.sheetWidthTb.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.sheetWidthTb.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.sheetWidthTb.Leave += new System.EventHandler(this.sheetWidthTb_TextChanged);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(271, 87);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(86, 19);
            this.metroLabel6.TabIndex = 15;
            this.metroLabel6.Text = "Width in MM";
            // 
            // sheetHeightTb
            // 
            // 
            // 
            // 
            this.sheetHeightTb.CustomButton.Image = null;
            this.sheetHeightTb.CustomButton.Location = new System.Drawing.Point(116, 1);
            this.sheetHeightTb.CustomButton.Name = "";
            this.sheetHeightTb.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.sheetHeightTb.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.sheetHeightTb.CustomButton.TabIndex = 1;
            this.sheetHeightTb.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.sheetHeightTb.CustomButton.UseSelectable = true;
            this.sheetHeightTb.CustomButton.Visible = false;
            this.sheetHeightTb.Lines = new string[0];
            this.sheetHeightTb.Location = new System.Drawing.Point(233, 61);
            this.sheetHeightTb.MaxLength = 32767;
            this.sheetHeightTb.Name = "sheetHeightTb";
            this.sheetHeightTb.PasswordChar = '\0';
            this.sheetHeightTb.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.sheetHeightTb.SelectedText = "";
            this.sheetHeightTb.SelectionLength = 0;
            this.sheetHeightTb.SelectionStart = 0;
            this.sheetHeightTb.ShortcutsEnabled = true;
            this.sheetHeightTb.Size = new System.Drawing.Size(138, 23);
            this.sheetHeightTb.TabIndex = 14;
            this.sheetHeightTb.UseSelectable = true;
            this.sheetHeightTb.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.sheetHeightTb.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.sheetHeightTb.Leave += new System.EventHandler(this.sheetHeightTb_TextChanged);
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(278, 39);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(93, 19);
            this.metroLabel7.TabIndex = 13;
            this.metroLabel7.Text = "Height in MM ";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel5.Location = new System.Drawing.Point(233, 3);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(54, 25);
            this.metroLabel5.TabIndex = 12;
            this.metroLabel5.Text = "Sheet";
            this.metroLabel5.UseStyleColors = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(124, 135);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(103, 19);
            this.metroLabel4.TabIndex = 11;
            this.metroLabel4.Text = "Stickers to place";
            // 
            // stickerCountTb
            // 
            // 
            // 
            // 
            this.stickerCountTb.CustomButton.Image = null;
            this.stickerCountTb.CustomButton.Location = new System.Drawing.Point(116, 1);
            this.stickerCountTb.CustomButton.Name = "";
            this.stickerCountTb.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.stickerCountTb.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.stickerCountTb.CustomButton.TabIndex = 1;
            this.stickerCountTb.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.stickerCountTb.CustomButton.UseSelectable = true;
            this.stickerCountTb.CustomButton.Visible = false;
            this.stickerCountTb.Lines = new string[0];
            this.stickerCountTb.Location = new System.Drawing.Point(89, 157);
            this.stickerCountTb.MaxLength = 32767;
            this.stickerCountTb.Name = "stickerCountTb";
            this.stickerCountTb.PasswordChar = '\0';
            this.stickerCountTb.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.stickerCountTb.SelectedText = "";
            this.stickerCountTb.SelectionLength = 0;
            this.stickerCountTb.SelectionStart = 0;
            this.stickerCountTb.ShortcutsEnabled = true;
            this.stickerCountTb.Size = new System.Drawing.Size(138, 23);
            this.stickerCountTb.TabIndex = 10;
            this.stickerCountTb.UseSelectable = true;
            this.stickerCountTb.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.stickerCountTb.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.stickerCountTb.Leave += new System.EventHandler(this.stickerCountTb_TextChanged);
            // 
            // paddingMmTb
            // 
            // 
            // 
            // 
            this.paddingMmTb.CustomButton.Image = null;
            this.paddingMmTb.CustomButton.Location = new System.Drawing.Point(116, 1);
            this.paddingMmTb.CustomButton.Name = "";
            this.paddingMmTb.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.paddingMmTb.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.paddingMmTb.CustomButton.TabIndex = 1;
            this.paddingMmTb.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.paddingMmTb.CustomButton.UseSelectable = true;
            this.paddingMmTb.CustomButton.Visible = false;
            this.paddingMmTb.Lines = new string[0];
            this.paddingMmTb.Location = new System.Drawing.Point(89, 109);
            this.paddingMmTb.MaxLength = 32767;
            this.paddingMmTb.Name = "paddingMmTb";
            this.paddingMmTb.PasswordChar = '\0';
            this.paddingMmTb.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.paddingMmTb.SelectedText = "";
            this.paddingMmTb.SelectionLength = 0;
            this.paddingMmTb.SelectionStart = 0;
            this.paddingMmTb.ShortcutsEnabled = true;
            this.paddingMmTb.Size = new System.Drawing.Size(138, 23);
            this.paddingMmTb.TabIndex = 9;
            this.paddingMmTb.UseSelectable = true;
            this.paddingMmTb.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.paddingMmTb.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.paddingMmTb.Leave += new System.EventHandler(this.paddingMmTb_TextChanged);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(127, 87);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(99, 19);
            this.metroLabel3.TabIndex = 7;
            this.metroLabel3.Text = "Padding in MM";
            // 
            // imgHeightTb
            // 
            // 
            // 
            // 
            this.imgHeightTb.CustomButton.Image = null;
            this.imgHeightTb.CustomButton.Location = new System.Drawing.Point(116, 1);
            this.imgHeightTb.CustomButton.Name = "";
            this.imgHeightTb.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.imgHeightTb.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.imgHeightTb.CustomButton.TabIndex = 1;
            this.imgHeightTb.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.imgHeightTb.CustomButton.UseSelectable = true;
            this.imgHeightTb.CustomButton.Visible = false;
            this.imgHeightTb.Lines = new string[0];
            this.imgHeightTb.Location = new System.Drawing.Point(89, 61);
            this.imgHeightTb.MaxLength = 32767;
            this.imgHeightTb.Name = "imgHeightTb";
            this.imgHeightTb.PasswordChar = '\0';
            this.imgHeightTb.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.imgHeightTb.SelectedText = "";
            this.imgHeightTb.SelectionLength = 0;
            this.imgHeightTb.SelectionStart = 0;
            this.imgHeightTb.ShortcutsEnabled = true;
            this.imgHeightTb.Size = new System.Drawing.Size(138, 23);
            this.imgHeightTb.TabIndex = 6;
            this.imgHeightTb.UseSelectable = true;
            this.imgHeightTb.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.imgHeightTb.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.imgHeightTb.Leave += new System.EventHandler(this.imgHeightTb_TextChanged);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(134, 39);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(93, 19);
            this.metroLabel2.TabIndex = 5;
            this.metroLabel2.Text = "Height in MM ";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(0, 3);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(61, 25);
            this.metroLabel1.TabIndex = 4;
            this.metroLabel1.Text = "Sticker";
            this.metroLabel1.UseStyleColors = true;
            // 
            // viewBtn
            // 
            this.viewBtn.ActiveControl = null;
            this.viewBtn.Location = new System.Drawing.Point(3, 117);
            this.viewBtn.Name = "viewBtn";
            this.viewBtn.Size = new System.Drawing.Size(80, 80);
            this.viewBtn.TabIndex = 3;
            this.viewBtn.Text = "View \r\nImage";
            this.viewBtn.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.viewBtn.UseSelectable = true;
            this.viewBtn.Click += new System.EventHandler(this.viewBtn_Click);
            // 
            // loadBtn
            // 
            this.loadBtn.ActiveControl = null;
            this.loadBtn.Location = new System.Drawing.Point(3, 31);
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(80, 80);
            this.loadBtn.TabIndex = 2;
            this.loadBtn.Text = "Load \r\nImage";
            this.loadBtn.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.loadBtn.UseSelectable = true;
            this.loadBtn.Click += new System.EventHandler(this.loadBtn_Click);
            // 
            // metroTabPage3
            // 
            this.metroTabPage3.Controls.Add(this.compressionTb);
            this.metroTabPage3.Controls.Add(this.metroLabel8);
            this.metroTabPage3.Controls.Add(this.metroLabel9);
            this.metroTabPage3.Controls.Add(this.mutationTb);
            this.metroTabPage3.Controls.Add(this.metroLabel14);
            this.metroTabPage3.Controls.Add(this.GenerationsTb);
            this.metroTabPage3.Controls.Add(this.metroLabel11);
            this.metroTabPage3.Controls.Add(this.individuesTb);
            this.metroTabPage3.Controls.Add(this.metroLabel12);
            this.metroTabPage3.Controls.Add(this.metroLabel13);
            this.metroTabPage3.HorizontalScrollbarBarColor = true;
            this.metroTabPage3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.HorizontalScrollbarSize = 10;
            this.metroTabPage3.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage3.Name = "metroTabPage3";
            this.metroTabPage3.Size = new System.Drawing.Size(389, 220);
            this.metroTabPage3.TabIndex = 2;
            this.metroTabPage3.Text = "Algorythm";
            this.metroTabPage3.VerticalScrollbarBarColor = true;
            this.metroTabPage3.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.VerticalScrollbarSize = 10;
            // 
            // compressionTb
            // 
            // 
            // 
            // 
            this.compressionTb.CustomButton.Image = null;
            this.compressionTb.CustomButton.Location = new System.Drawing.Point(116, 1);
            this.compressionTb.CustomButton.Name = "";
            this.compressionTb.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.compressionTb.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.compressionTb.CustomButton.TabIndex = 1;
            this.compressionTb.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.compressionTb.CustomButton.UseSelectable = true;
            this.compressionTb.CustomButton.Visible = false;
            this.compressionTb.Lines = new string[0];
            this.compressionTb.Location = new System.Drawing.Point(248, 50);
            this.compressionTb.MaxLength = 32767;
            this.compressionTb.Name = "compressionTb";
            this.compressionTb.PasswordChar = '\0';
            this.compressionTb.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.compressionTb.SelectedText = "";
            this.compressionTb.SelectionLength = 0;
            this.compressionTb.SelectionStart = 0;
            this.compressionTb.ShortcutsEnabled = true;
            this.compressionTb.Size = new System.Drawing.Size(138, 23);
            this.compressionTb.TabIndex = 26;
            this.compressionTb.UseSelectable = true;
            this.compressionTb.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.compressionTb.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.compressionTb.Leave += new System.EventHandler(this.compressionTb_TextChanged);
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(319, 28);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(67, 19);
            this.metroLabel8.TabIndex = 25;
            this.metroLabel8.Text = "Px to Mm";
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel9.Location = new System.Drawing.Point(233, 3);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(111, 25);
            this.metroLabel9.TabIndex = 24;
            this.metroLabel9.Text = "Compression";
            this.metroLabel9.UseStyleColors = true;
            // 
            // mutationTb
            // 
            // 
            // 
            // 
            this.mutationTb.CustomButton.Image = null;
            this.mutationTb.CustomButton.Location = new System.Drawing.Point(116, 1);
            this.mutationTb.CustomButton.Name = "";
            this.mutationTb.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mutationTb.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mutationTb.CustomButton.TabIndex = 1;
            this.mutationTb.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mutationTb.CustomButton.UseSelectable = true;
            this.mutationTb.CustomButton.Visible = false;
            this.mutationTb.Lines = new string[0];
            this.mutationTb.Location = new System.Drawing.Point(13, 146);
            this.mutationTb.MaxLength = 32767;
            this.mutationTb.Name = "mutationTb";
            this.mutationTb.PasswordChar = '\0';
            this.mutationTb.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mutationTb.SelectedText = "";
            this.mutationTb.SelectionLength = 0;
            this.mutationTb.SelectionStart = 0;
            this.mutationTb.ShortcutsEnabled = true;
            this.mutationTb.Size = new System.Drawing.Size(138, 23);
            this.mutationTb.TabIndex = 23;
            this.mutationTb.UseSelectable = true;
            this.mutationTb.Visible = false;
            this.mutationTb.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mutationTb.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.mutationTb.Leave += new System.EventHandler(this.mutationTb_TextChanged);
            // 
            // metroLabel14
            // 
            this.metroLabel14.AutoSize = true;
            this.metroLabel14.Location = new System.Drawing.Point(47, 124);
            this.metroLabel14.Name = "metroLabel14";
            this.metroLabel14.Size = new System.Drawing.Size(104, 19);
            this.metroLabel14.TabIndex = 22;
            this.metroLabel14.Text = "Mutation Divisor";
            this.metroLabel14.Visible = false;
            // 
            // GenerationsTb
            // 
            // 
            // 
            // 
            this.GenerationsTb.CustomButton.Image = null;
            this.GenerationsTb.CustomButton.Location = new System.Drawing.Point(116, 1);
            this.GenerationsTb.CustomButton.Name = "";
            this.GenerationsTb.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.GenerationsTb.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.GenerationsTb.CustomButton.TabIndex = 1;
            this.GenerationsTb.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.GenerationsTb.CustomButton.UseSelectable = true;
            this.GenerationsTb.CustomButton.Visible = false;
            this.GenerationsTb.Lines = new string[0];
            this.GenerationsTb.Location = new System.Drawing.Point(13, 98);
            this.GenerationsTb.MaxLength = 32767;
            this.GenerationsTb.Name = "GenerationsTb";
            this.GenerationsTb.PasswordChar = '\0';
            this.GenerationsTb.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.GenerationsTb.SelectedText = "";
            this.GenerationsTb.SelectionLength = 0;
            this.GenerationsTb.SelectionStart = 0;
            this.GenerationsTb.ShortcutsEnabled = true;
            this.GenerationsTb.Size = new System.Drawing.Size(138, 23);
            this.GenerationsTb.TabIndex = 21;
            this.GenerationsTb.UseSelectable = true;
            this.GenerationsTb.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.GenerationsTb.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.GenerationsTb.Leave += new System.EventHandler(this.GenerationsTb_TextChanged);
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.Location = new System.Drawing.Point(73, 76);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(78, 19);
            this.metroLabel11.TabIndex = 20;
            this.metroLabel11.Text = "Generations";
            // 
            // individuesTb
            // 
            // 
            // 
            // 
            this.individuesTb.CustomButton.Image = null;
            this.individuesTb.CustomButton.Location = new System.Drawing.Point(116, 1);
            this.individuesTb.CustomButton.Name = "";
            this.individuesTb.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.individuesTb.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.individuesTb.CustomButton.TabIndex = 1;
            this.individuesTb.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.individuesTb.CustomButton.UseSelectable = true;
            this.individuesTb.CustomButton.Visible = false;
            this.individuesTb.Lines = new string[0];
            this.individuesTb.Location = new System.Drawing.Point(13, 50);
            this.individuesTb.MaxLength = 32767;
            this.individuesTb.Name = "individuesTb";
            this.individuesTb.PasswordChar = '\0';
            this.individuesTb.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.individuesTb.SelectedText = "";
            this.individuesTb.SelectionLength = 0;
            this.individuesTb.SelectionStart = 0;
            this.individuesTb.ShortcutsEnabled = true;
            this.individuesTb.Size = new System.Drawing.Size(138, 23);
            this.individuesTb.TabIndex = 19;
            this.individuesTb.UseSelectable = true;
            this.individuesTb.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.individuesTb.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.individuesTb.Leave += new System.EventHandler(this.individuesTb_TextChanged);
            // 
            // metroLabel12
            // 
            this.metroLabel12.AutoSize = true;
            this.metroLabel12.Location = new System.Drawing.Point(85, 28);
            this.metroLabel12.Name = "metroLabel12";
            this.metroLabel12.Size = new System.Drawing.Size(66, 19);
            this.metroLabel12.TabIndex = 18;
            this.metroLabel12.Text = "Individues";
            // 
            // metroLabel13
            // 
            this.metroLabel13.AutoSize = true;
            this.metroLabel13.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel13.Location = new System.Drawing.Point(0, 3);
            this.metroLabel13.Name = "metroLabel13";
            this.metroLabel13.Size = new System.Drawing.Size(152, 25);
            this.metroLabel13.TabIndex = 17;
            this.metroLabel13.Text = "Genetic algorythm";
            this.metroLabel13.UseStyleColors = true;
            // 
            // goBtn
            // 
            this.goBtn.ActiveControl = null;
            this.goBtn.Location = new System.Drawing.Point(443, 63);
            this.goBtn.Name = "goBtn";
            this.goBtn.Size = new System.Drawing.Size(80, 261);
            this.goBtn.TabIndex = 3;
            this.goBtn.Text = "Go!";
            this.goBtn.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.goBtn.UseSelectable = true;
            this.goBtn.UseStyleColors = true;
            this.goBtn.Click += new System.EventHandler(this.goBtn_Click);
            // 
            // ofd
            // 
            this.ofd.Filter = "Imágen |*png";
            // 
            // MainForm
            // 
            this.ApplyImageInvert = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 335);
            this.Controls.Add(this.goBtn);
            this.Controls.Add(this.metroTabControl1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(546, 335);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(546, 335);
            this.Name = "MainForm";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.Text = "Sticker Placer";
            this.Load += new System.EventHandler(this.MetroMainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).EndInit();
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage2.ResumeLayout(false);
            this.metroTabPage2.PerformLayout();
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage1.PerformLayout();
            this.metroTabPage3.ResumeLayout(false);
            this.metroTabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private MetroFramework.Controls.MetroTile styleBtn;
        private MetroFramework.Controls.MetroTile themeBtn;
        private MetroFramework.Controls.MetroTile loadBtn;
        private MetroFramework.Controls.MetroTile viewBtn;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox imgHeightTb;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox sheetWidthTb;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroTextBox sheetHeightTb;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox stickerCountTb;
        private MetroFramework.Controls.MetroTextBox paddingMmTb;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroTabPage metroTabPage3;
        private MetroFramework.Controls.MetroTextBox GenerationsTb;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private MetroFramework.Controls.MetroTextBox individuesTb;
        private MetroFramework.Controls.MetroLabel metroLabel12;
        private MetroFramework.Controls.MetroLabel metroLabel13;
        private MetroFramework.Controls.MetroTile goBtn;
        private MetroFramework.Controls.MetroTextBox mutationTb;
        private MetroFramework.Controls.MetroLabel metroLabel14;
        private System.Windows.Forms.OpenFileDialog ofd;
        private MetroFramework.Controls.MetroTextBox compressionTb;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroLabel metroLabel9;
    }
}