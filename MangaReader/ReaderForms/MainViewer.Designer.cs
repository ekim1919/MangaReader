namespace MangaReader.ReaderForms {
    partial class Viewer
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cloneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BeforeOption = new System.Windows.Forms.ToolStripMenuItem();
            this.AfterOption = new System.Windows.Forms.ToolStripMenuItem();
            this.scaleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.centerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullScreenModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.cloneToolStripMenuItem,
            this.scaleToolStripMenuItem1,
            this.fullScreenModeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(875, 24);
            this.menuStrip1.TabIndex = 8;
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem1});
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem1.Text = "File";
            // 
            // openFileToolStripMenuItem1
            // 
            this.openFileToolStripMenuItem1.Name = "openFileToolStripMenuItem1";
            this.openFileToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.openFileToolStripMenuItem1.Text = "OpenFile";
            this.openFileToolStripMenuItem1.Click += new System.EventHandler(this.openFileToolStripMenuItem1_Click);
            // 
            // cloneToolStripMenuItem
            // 
            this.cloneToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BeforeOption,
            this.AfterOption});
            this.cloneToolStripMenuItem.Name = "cloneToolStripMenuItem";
            this.cloneToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.cloneToolStripMenuItem.Text = "Clone";
            // 
            // BeforeOption
            // 
            this.BeforeOption.Name = "BeforeOption";
            this.BeforeOption.Size = new System.Drawing.Size(108, 22);
            this.BeforeOption.Text = "Before";
            this.BeforeOption.Click += new System.EventHandler(this.BeforeOption_Click);
            // 
            // AfterOption
            // 
            this.AfterOption.Name = "AfterOption";
            this.AfterOption.Size = new System.Drawing.Size(108, 22);
            this.AfterOption.Text = "After";
            this.AfterOption.Click += new System.EventHandler(this.AfterOption_Click);
            // 
            // scaleToolStripMenuItem1
            // 
            this.scaleToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomToolStripMenuItem,
            this.centerToolStripMenuItem});
            this.scaleToolStripMenuItem1.Name = "scaleToolStripMenuItem1";
            this.scaleToolStripMenuItem1.Size = new System.Drawing.Size(46, 20);
            this.scaleToolStripMenuItem1.Text = "Scale";
            // 
            // zoomToolStripMenuItem
            // 
            this.zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
            this.zoomToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.zoomToolStripMenuItem.Text = "Zoom";
            this.zoomToolStripMenuItem.Click += new System.EventHandler(this.zoomToolStripMenuItem_Click);
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
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // scaleToolStripMenuItem
            // 
            this.scaleToolStripMenuItem.Name = "scaleToolStripMenuItem";
            this.scaleToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Viewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 563);
            this.Controls.Add(this.FullDirectory);
            this.Controls.Add(this.PictureBox);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Viewer";
            this.Text = "MangaViewer";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Viewer_KeyDown);
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

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cloneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BeforeOption;
        private System.Windows.Forms.ToolStripMenuItem AfterOption;
        private System.Windows.Forms.ToolStripMenuItem scaleToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem zoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem centerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullScreenModeToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}

