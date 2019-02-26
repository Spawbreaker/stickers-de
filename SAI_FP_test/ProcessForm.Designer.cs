namespace StickerDE
{
    partial class ProcessForm
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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.stickerPb = new MetroFramework.Controls.MetroProgressBar();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroTile2 = new MetroFramework.Controls.MetroTile();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.generationPb = new MetroFramework.Controls.MetroProgressBar();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.generationsLbl = new MetroFramework.Controls.MetroLabel();
            this.stickersLbl = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.doOneBtn = new MetroFramework.Controls.MetroTile();
            this.stopBtn = new MetroFramework.Controls.MetroTile();
            this.runBtn = new MetroFramework.Controls.MetroTile();
            this.seeBtn = new MetroFramework.Controls.MetroTile();
            this.fitnessLbl = new MetroFramework.Controls.MetroLabel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.seeCb = new MetroFramework.Controls.MetroComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).BeginInit();
            this.SuspendLayout();
            // 
            // metroStyleManager
            // 
            this.metroStyleManager.Owner = this;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(23, 60);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(77, 25);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Progress";
            this.metroLabel1.UseStyleColors = true;
            // 
            // stickerPb
            // 
            this.stickerPb.Location = new System.Drawing.Point(23, 116);
            this.stickerPb.Name = "stickerPb";
            this.stickerPb.Size = new System.Drawing.Size(244, 30);
            this.stickerPb.TabIndex = 1;
            // 
            // metroTile1
            // 
            this.metroTile1.ActiveControl = null;
            this.metroTile1.Enabled = false;
            this.metroTile1.Location = new System.Drawing.Point(273, 60);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(1, 250);
            this.metroTile1.TabIndex = 2;
            this.metroTile1.Text = "metroTile1";
            this.metroTile1.UseSelectable = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(215, 94);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(52, 19);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "Stickers";
            // 
            // metroTile2
            // 
            this.metroTile2.ActiveControl = null;
            this.metroTile2.Enabled = false;
            this.metroTile2.Location = new System.Drawing.Point(23, 163);
            this.metroTile2.Name = "metroTile2";
            this.metroTile2.Size = new System.Drawing.Size(244, 1);
            this.metroTile2.TabIndex = 4;
            this.metroTile2.Text = "metroTile2";
            this.metroTile2.UseSelectable = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(189, 176);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(78, 19);
            this.metroLabel3.TabIndex = 6;
            this.metroLabel3.Text = "Generations";
            // 
            // generationPb
            // 
            this.generationPb.Location = new System.Drawing.Point(23, 198);
            this.generationPb.Name = "generationPb";
            this.generationPb.Size = new System.Drawing.Size(244, 30);
            this.generationPb.TabIndex = 5;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(215, 231);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(50, 19);
            this.metroLabel4.TabIndex = 8;
            this.metroLabel4.Text = "Quality";
            // 
            // generationsLbl
            // 
            this.generationsLbl.AutoSize = true;
            this.generationsLbl.FontSize = MetroFramework.MetroLabelSize.Small;
            this.generationsLbl.Location = new System.Drawing.Point(23, 180);
            this.generationsLbl.Name = "generationsLbl";
            this.generationsLbl.Size = new System.Drawing.Size(32, 15);
            this.generationsLbl.TabIndex = 9;
            this.generationsLbl.Text = "0 / 0 ";
            // 
            // stickersLbl
            // 
            this.stickersLbl.AutoSize = true;
            this.stickersLbl.FontSize = MetroFramework.MetroLabelSize.Small;
            this.stickersLbl.Location = new System.Drawing.Point(23, 98);
            this.stickersLbl.Name = "stickersLbl";
            this.stickersLbl.Size = new System.Drawing.Size(32, 15);
            this.stickersLbl.TabIndex = 11;
            this.stickersLbl.Text = "0 / 0 ";
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel8.Location = new System.Drawing.Point(276, 60);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(68, 25);
            this.metroLabel8.TabIndex = 12;
            this.metroLabel8.Text = "Control";
            this.metroLabel8.UseStyleColors = true;
            // 
            // doOneBtn
            // 
            this.doOneBtn.ActiveControl = null;
            this.doOneBtn.Location = new System.Drawing.Point(281, 109);
            this.doOneBtn.Name = "doOneBtn";
            this.doOneBtn.Size = new System.Drawing.Size(80, 80);
            this.doOneBtn.TabIndex = 13;
            this.doOneBtn.Text = "Do One\r\nGen";
            this.doOneBtn.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.doOneBtn.UseSelectable = true;
            this.doOneBtn.Click += new System.EventHandler(this.doOneBtn_Click);
            // 
            // stopBtn
            // 
            this.stopBtn.ActiveControl = null;
            this.stopBtn.Location = new System.Drawing.Point(453, 109);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(80, 80);
            this.stopBtn.TabIndex = 14;
            this.stopBtn.Text = "Stop\r\nAuto";
            this.stopBtn.UseSelectable = true;
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // runBtn
            // 
            this.runBtn.ActiveControl = null;
            this.runBtn.Location = new System.Drawing.Point(367, 109);
            this.runBtn.Name = "runBtn";
            this.runBtn.Size = new System.Drawing.Size(80, 80);
            this.runBtn.TabIndex = 15;
            this.runBtn.Text = "Auto\r\nRun";
            this.runBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.runBtn.UseSelectable = true;
            this.runBtn.Click += new System.EventHandler(this.runBtn_Click);
            // 
            // seeBtn
            // 
            this.seeBtn.ActiveControl = null;
            this.seeBtn.Location = new System.Drawing.Point(453, 198);
            this.seeBtn.Name = "seeBtn";
            this.seeBtn.Size = new System.Drawing.Size(80, 80);
            this.seeBtn.TabIndex = 16;
            this.seeBtn.Text = "See best";
            this.seeBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.seeBtn.UseSelectable = true;
            this.seeBtn.Click += new System.EventHandler(this.seeBtn_Click);
            // 
            // fitnessLbl
            // 
            this.fitnessLbl.AutoSize = true;
            this.fitnessLbl.FontSize = MetroFramework.MetroLabelSize.Small;
            this.fitnessLbl.Location = new System.Drawing.Point(23, 235);
            this.fitnessLbl.Name = "fitnessLbl";
            this.fitnessLbl.Size = new System.Drawing.Size(13, 15);
            this.fitnessLbl.TabIndex = 17;
            this.fitnessLbl.Text = "0";
            // 
            // timer
            // 
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.MainTimer_Tick);
            // 
            // seeCb
            // 
            this.seeCb.FormattingEnabled = true;
            this.seeCb.ItemHeight = 23;
            this.seeCb.Location = new System.Drawing.Point(281, 281);
            this.seeCb.Name = "seeCb";
            this.seeCb.Size = new System.Drawing.Size(252, 29);
            this.seeCb.TabIndex = 18;
            this.seeCb.UseSelectable = true;
            this.seeCb.UseStyleColors = true;
            this.seeCb.SelectedIndexChanged += new System.EventHandler(this.seeCb_SelectedIndexChanged);
            // 
            // ProcessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 335);
            this.Controls.Add(this.seeCb);
            this.Controls.Add(this.fitnessLbl);
            this.Controls.Add(this.seeBtn);
            this.Controls.Add(this.runBtn);
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.doOneBtn);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.stickersLbl);
            this.Controls.Add(this.generationsLbl);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.generationPb);
            this.Controls.Add(this.metroTile2);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroTile1);
            this.Controls.Add(this.stickerPb);
            this.Controls.Add(this.metroLabel1);
            this.MaximumSize = new System.Drawing.Size(546, 335);
            this.MinimumSize = new System.Drawing.Size(546, 335);
            this.Name = "ProcessForm";
            this.Resizable = false;
            this.Text = "Processing";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProcessForm_FormClosing);
            this.Load += new System.EventHandler(this.MetroProcessingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager;
        private MetroFramework.Controls.MetroProgressBar stickerPb;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTile seeBtn;
        private MetroFramework.Controls.MetroTile runBtn;
        private MetroFramework.Controls.MetroTile stopBtn;
        private MetroFramework.Controls.MetroTile doOneBtn;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroLabel stickersLbl;
        private MetroFramework.Controls.MetroLabel generationsLbl;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroProgressBar generationPb;
        private MetroFramework.Controls.MetroTile metroTile2;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTile metroTile1;
        private MetroFramework.Controls.MetroLabel fitnessLbl;
        private System.Windows.Forms.Timer timer;
        private MetroFramework.Controls.MetroComboBox seeCb;
    }
}