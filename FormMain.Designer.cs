
namespace NEO_TWEWY_Randomizer
{
    partial class FormMain
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
            this.tabsMain = new System.Windows.Forms.TabControl();
            this.tabDrops = new System.Windows.Forms.TabPage();
            this.grpItems = new System.Windows.Forms.GroupBox();
            this.tabPins = new System.Windows.Forms.TabPage();
            this.tabSocial = new System.Windows.Forms.TabPage();
            this.tabThreads = new System.Windows.Forms.TabPage();
            this.tabEncounter = new System.Windows.Forms.TabPage();
            this.tabFood = new System.Windows.Forms.TabPage();
            this.tabMusic = new System.Windows.Forms.TabPage();
            this.tabMisc = new System.Windows.Forms.TabPage();
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.linkSource = new System.Windows.Forms.LinkLabel();
            this.lbVersion = new System.Windows.Forms.Label();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnPremade = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.picPin = new System.Windows.Forms.PictureBox();
            this.imlistPins = new System.Windows.Forms.ImageList(this.components);
            this.tabsMain.SuspendLayout();
            this.tabDrops.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPin)).BeginInit();
            this.SuspendLayout();
            // 
            // tabsMain
            // 
            this.tabsMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabsMain.Controls.Add(this.tabDrops);
            this.tabsMain.Controls.Add(this.tabPins);
            this.tabsMain.Controls.Add(this.tabSocial);
            this.tabsMain.Controls.Add(this.tabThreads);
            this.tabsMain.Controls.Add(this.tabEncounter);
            this.tabsMain.Controls.Add(this.tabFood);
            this.tabsMain.Controls.Add(this.tabMusic);
            this.tabsMain.Controls.Add(this.tabMisc);
            this.tabsMain.Location = new System.Drawing.Point(12, 167);
            this.tabsMain.Name = "tabsMain";
            this.tabsMain.SelectedIndex = 0;
            this.tabsMain.Size = new System.Drawing.Size(776, 408);
            this.tabsMain.TabIndex = 0;
            // 
            // tabDrops
            // 
            this.tabDrops.Controls.Add(this.grpItems);
            this.tabDrops.Location = new System.Drawing.Point(4, 22);
            this.tabDrops.Name = "tabDrops";
            this.tabDrops.Padding = new System.Windows.Forms.Padding(3);
            this.tabDrops.Size = new System.Drawing.Size(768, 382);
            this.tabDrops.TabIndex = 0;
            this.tabDrops.Text = "Noise Drops";
            this.tabDrops.UseVisualStyleBackColor = true;
            // 
            // grpItems
            // 
            this.grpItems.Location = new System.Drawing.Point(6, 6);
            this.grpItems.Name = "grpItems";
            this.grpItems.Size = new System.Drawing.Size(335, 201);
            this.grpItems.TabIndex = 0;
            this.grpItems.TabStop = false;
            this.grpItems.Text = "Dropped Pins";
            // 
            // tabPins
            // 
            this.tabPins.Location = new System.Drawing.Point(4, 22);
            this.tabPins.Name = "tabPins";
            this.tabPins.Padding = new System.Windows.Forms.Padding(3);
            this.tabPins.Size = new System.Drawing.Size(768, 382);
            this.tabPins.TabIndex = 1;
            this.tabPins.Text = "Pin Stats";
            this.tabPins.UseVisualStyleBackColor = true;
            // 
            // tabSocial
            // 
            this.tabSocial.Location = new System.Drawing.Point(4, 22);
            this.tabSocial.Name = "tabSocial";
            this.tabSocial.Padding = new System.Windows.Forms.Padding(3);
            this.tabSocial.Size = new System.Drawing.Size(768, 382);
            this.tabSocial.TabIndex = 2;
            this.tabSocial.Text = "Social Network";
            this.tabSocial.UseVisualStyleBackColor = true;
            // 
            // tabThreads
            // 
            this.tabThreads.Location = new System.Drawing.Point(4, 22);
            this.tabThreads.Name = "tabThreads";
            this.tabThreads.Padding = new System.Windows.Forms.Padding(3);
            this.tabThreads.Size = new System.Drawing.Size(768, 382);
            this.tabThreads.TabIndex = 3;
            this.tabThreads.Text = "Threads";
            this.tabThreads.UseVisualStyleBackColor = true;
            // 
            // tabEncounter
            // 
            this.tabEncounter.Location = new System.Drawing.Point(4, 22);
            this.tabEncounter.Name = "tabEncounter";
            this.tabEncounter.Padding = new System.Windows.Forms.Padding(3);
            this.tabEncounter.Size = new System.Drawing.Size(768, 382);
            this.tabEncounter.TabIndex = 4;
            this.tabEncounter.Text = "Noise Encounters";
            this.tabEncounter.UseVisualStyleBackColor = true;
            // 
            // tabFood
            // 
            this.tabFood.Location = new System.Drawing.Point(4, 22);
            this.tabFood.Name = "tabFood";
            this.tabFood.Padding = new System.Windows.Forms.Padding(3);
            this.tabFood.Size = new System.Drawing.Size(768, 382);
            this.tabFood.TabIndex = 6;
            this.tabFood.Text = "Food";
            this.tabFood.UseVisualStyleBackColor = true;
            // 
            // tabMusic
            // 
            this.tabMusic.Location = new System.Drawing.Point(4, 22);
            this.tabMusic.Name = "tabMusic";
            this.tabMusic.Padding = new System.Windows.Forms.Padding(3);
            this.tabMusic.Size = new System.Drawing.Size(768, 382);
            this.tabMusic.TabIndex = 7;
            this.tabMusic.Text = "Music";
            this.tabMusic.UseVisualStyleBackColor = true;
            // 
            // tabMisc
            // 
            this.tabMisc.Location = new System.Drawing.Point(4, 22);
            this.tabMisc.Name = "tabMisc";
            this.tabMisc.Padding = new System.Windows.Forms.Padding(3);
            this.tabMisc.Size = new System.Drawing.Size(768, 382);
            this.tabMisc.TabIndex = 5;
            this.tabMisc.Text = "Misc. Tweaks";
            this.tabMisc.UseVisualStyleBackColor = true;
            // 
            // grpInfo
            // 
            this.grpInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpInfo.Location = new System.Drawing.Point(265, 12);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Size = new System.Drawing.Size(246, 128);
            this.grpInfo.TabIndex = 1;
            this.grpInfo.TabStop = false;
            this.grpInfo.Text = "Information";
            // 
            // linkSource
            // 
            this.linkSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkSource.AutoSize = true;
            this.linkSource.Location = new System.Drawing.Point(691, 151);
            this.linkSource.Name = "linkSource";
            this.linkSource.Size = new System.Drawing.Size(93, 13);
            this.linkSource.TabIndex = 2;
            this.linkSource.TabStop = true;
            this.linkSource.Text = "GitHub Repository";
            this.linkSource.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSource_LinkClicked);
            // 
            // lbVersion
            // 
            this.lbVersion.AutoSize = true;
            this.lbVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVersion.Location = new System.Drawing.Point(9, 151);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(391, 13);
            this.lbVersion.TabIndex = 3;
            this.lbVersion.Text = "NEO: The World Ends With You Randomizer - Version 2021.10.21.a";
            // 
            // btnAbout
            // 
            this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbout.Location = new System.Drawing.Point(651, 113);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(133, 27);
            this.btnAbout.TabIndex = 6;
            this.btnAbout.Text = "About...";
            this.btnAbout.UseVisualStyleBackColor = true;
            // 
            // btnPremade
            // 
            this.btnPremade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPremade.Location = new System.Drawing.Point(651, 80);
            this.btnPremade.Name = "btnPremade";
            this.btnPremade.Size = new System.Drawing.Size(133, 27);
            this.btnPremade.TabIndex = 7;
            this.btnPremade.Text = "Premade Seed";
            this.btnPremade.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(651, 45);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(133, 27);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Randomize and Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.Location = new System.Drawing.Point(651, 12);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(133, 27);
            this.btnOpen.TabIndex = 9;
            this.btnOpen.Text = "Open Game Files";
            this.btnOpen.UseVisualStyleBackColor = true;
            // 
            // picPin
            // 
            this.picPin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picPin.Location = new System.Drawing.Point(517, 12);
            this.picPin.Name = "picPin";
            this.picPin.Size = new System.Drawing.Size(128, 128);
            this.picPin.TabIndex = 10;
            this.picPin.TabStop = false;
            // 
            // imlistPins
            // 
            this.imlistPins.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imlistPins.ImageSize = new System.Drawing.Size(16, 16);
            this.imlistPins.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 587);
            this.Controls.Add(this.picPin);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnPremade);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.lbVersion);
            this.Controls.Add(this.linkSource);
            this.Controls.Add(this.grpInfo);
            this.Controls.Add(this.tabsMain);
            this.MinimumSize = new System.Drawing.Size(816, 626);
            this.Name = "FormMain";
            this.Text = "NEO: TWEWY Randomizer";
            this.tabsMain.ResumeLayout(false);
            this.tabDrops.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabsMain;
        private System.Windows.Forms.TabPage tabDrops;
        private System.Windows.Forms.TabPage tabPins;
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.LinkLabel linkSource;
        private System.Windows.Forms.Label lbVersion;
        private System.Windows.Forms.TabPage tabSocial;
        private System.Windows.Forms.TabPage tabThreads;
        private System.Windows.Forms.TabPage tabEncounter;
        private System.Windows.Forms.TabPage tabMisc;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnPremade;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.GroupBox grpItems;
        private System.Windows.Forms.PictureBox picPin;
        private System.Windows.Forms.ImageList imlistPins;
        private System.Windows.Forms.TabPage tabFood;
        private System.Windows.Forms.TabPage tabMusic;
    }
}

