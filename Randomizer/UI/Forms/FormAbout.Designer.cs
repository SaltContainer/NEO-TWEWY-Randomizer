
namespace NEO_TWEWY_Randomizer
{
    partial class FormAbout
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
            this.picPin = new System.Windows.Forms.PictureBox();
            this.lbTitle = new System.Windows.Forms.Label();
            this.lbCreator = new System.Windows.Forms.Label();
            this.lbVersion = new System.Windows.Forms.Label();
            this.linkSource = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picPin)).BeginInit();
            this.SuspendLayout();
            // 
            // picPin
            // 
            this.picPin.Image = global::NEO_TWEWY_Randomizer.Properties.Resources.ID001_NoBrand;
            this.picPin.Location = new System.Drawing.Point(12, 12);
            this.picPin.Name = "picPin";
            this.picPin.Size = new System.Drawing.Size(100, 100);
            this.picPin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPin.TabIndex = 0;
            this.picPin.TabStop = false;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.Location = new System.Drawing.Point(118, 12);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(311, 16);
            this.lbTitle.TabIndex = 1;
            this.lbTitle.Text = "NEO: The World Ends With You Randomizer";
            // 
            // lbCreator
            // 
            this.lbCreator.AutoSize = true;
            this.lbCreator.Location = new System.Drawing.Point(118, 78);
            this.lbCreator.Name = "lbCreator";
            this.lbCreator.Size = new System.Drawing.Size(114, 13);
            this.lbCreator.TabIndex = 3;
            this.lbCreator.Text = "Made by SaltContainer";
            // 
            // lbVersion
            // 
            this.lbVersion.AutoSize = true;
            this.lbVersion.Location = new System.Drawing.Point(118, 35);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(45, 13);
            this.lbVersion.TabIndex = 4;
            this.lbVersion.Text = "Version ";
            // 
            // linkSource
            // 
            this.linkSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkSource.AutoSize = true;
            this.linkSource.Location = new System.Drawing.Point(118, 99);
            this.linkSource.Name = "linkSource";
            this.linkSource.Size = new System.Drawing.Size(93, 13);
            this.linkSource.TabIndex = 5;
            this.linkSource.TabStop = true;
            this.linkSource.Text = "GitHub Repository";
            this.linkSource.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSource_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(334, 78);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(98, 34);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // FormAbout
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(444, 124);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.linkSource);
            this.Controls.Add(this.lbVersion);
            this.Controls.Add(this.lbCreator);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.picPin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(460, 163);
            this.MinimumSize = new System.Drawing.Size(460, 163);
            this.Name = "FormAbout";
            this.ShowIcon = false;
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(this.picPin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picPin;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label lbCreator;
        private System.Windows.Forms.Label lbVersion;
        private System.Windows.Forms.LinkLabel linkSource;
        private System.Windows.Forms.Button btnClose;
    }
}