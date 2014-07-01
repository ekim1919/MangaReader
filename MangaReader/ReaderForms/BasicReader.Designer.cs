namespace MangaReader.ReaderForms {
    
    partial class BasicReader
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
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.FullDirectory = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBox
            // 
            this.PictureBox.BackColor = System.Drawing.SystemColors.ControlText;
            this.PictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureBox.Location = new System.Drawing.Point(0, 24);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(875, 539);
            this.PictureBox.TabIndex = 0;
            this.PictureBox.TabStop = false;
            // 
            // FullDirectory
            // 
            this.FullDirectory.AutoSize = true;
            this.FullDirectory.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FullDirectory.Location = new System.Drawing.Point(0, 550);
            this.FullDirectory.Name = "FullDirectory";
            this.FullDirectory.Size = new System.Drawing.Size(65, 13);
            this.FullDirectory.TabIndex = 2;
            this.FullDirectory.Text = "FullDirectory";
            // 
            // BasicReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 377);
            this.Name = "BasicReader";
            this.Text = "BasicReader";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        protected System.Windows.Forms.PictureBox PictureBox;
        protected System.Windows.Forms.Label FullDirectory;
    }
}