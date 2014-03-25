namespace MangaReader
{
    partial class Clone {
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
            WinMan.RemoveClone(PicMan); //Remove Pointer from WindowManager 

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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.scaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.centerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullScreenModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PictureBox
            // 
            this.PictureBox.Size = new System.Drawing.Size(838, 545);
            // 
            // FullDirectory
            // 
            this.FullDirectory.Location = new System.Drawing.Point(0, 556);
            this.FullDirectory.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scaleToolStripMenuItem,
            this.fullScreenModeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(838, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // scaleToolStripMenuItem
            // 
            this.scaleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoSizeToolStripMenuItem,
            this.centerToolStripMenuItem});
            this.scaleToolStripMenuItem.Name = "scaleToolStripMenuItem";
            this.scaleToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.scaleToolStripMenuItem.Text = "Scale";
            // 
            // autoSizeToolStripMenuItem
            // 
            this.autoSizeToolStripMenuItem.Name = "autoSizeToolStripMenuItem";
            this.autoSizeToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.autoSizeToolStripMenuItem.Text = "Zoom";
            this.autoSizeToolStripMenuItem.Click += new System.EventHandler(this.autoSizeToolStripMenuItem_Click);
            // 
            // centerToolStripMenuItem
            // 
            this.centerToolStripMenuItem.Name = "centerToolStripMenuItem";
            this.centerToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.centerToolStripMenuItem.Text = "Center";
            this.centerToolStripMenuItem.Click += new System.EventHandler(this.centerToolStripMenuItem_Click);
            // 
            // fullScreenModeToolStripMenuItem
            // 
            this.fullScreenModeToolStripMenuItem.Name = "fullScreenModeToolStripMenuItem";
            this.fullScreenModeToolStripMenuItem.Size = new System.Drawing.Size(110, 20);
            this.fullScreenModeToolStripMenuItem.Text = "Full Screen Mode";
            this.fullScreenModeToolStripMenuItem.Click += new System.EventHandler(this.fullScreenModeToolStripMenuItem_Click);
            // 
            // Clone
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(838, 569);
            this.Controls.Add(this.FullDirectory);
            this.Controls.Add(this.PictureBox);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Clone";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Clone_KeyDown);
            this.Controls.SetChildIndex(this.menuStrip1, 0);
            this.Controls.SetChildIndex(this.PictureBox, 0);
            this.Controls.SetChildIndex(this.FullDirectory, 0);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem scaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem centerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullScreenModeToolStripMenuItem;
    }
}