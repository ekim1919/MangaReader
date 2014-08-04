using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MangaReader.Managers;

namespace MangaReader.ReaderForms {

    public partial class Clone : BasicReader {
       
        public Clone(FileManager FileMana,  
                     int clonenum,  
                     String headeraddon,
                     int pos_to_start = 0)
            : base(FileMana ,pos_to_start, clonenum) {
            this.MouseWheel += new MouseEventHandler(Reader_MouseWheel);
            InitializeComponent();
            this.Text = "MangaViewer Clone: " + clonenum + " " + headeraddon;
            PictureBox.SizeMode = PictureBoxSizeMode.Zoom;

        }

        /*-------------Interface methods ------------------- */

        public PictureManager PicMana {
            get {
                return PicMan;
            }
        }
        private void autoSizeToolStripMenuItem_Click(object sender, EventArgs e) {
            PictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        }

        /*---------------------- Form Event Methods ----------------------*/

        private void centerToolStripMenuItem_Click(object sender, EventArgs e) {
            PictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void Clone_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode.Equals(Keys.Space)) {
                SessionManager.NextPicture();
            } else if (e.KeyCode.Equals(Keys.Back)) {
                SessionManager.PrevPicture();
            }
        }

        private void fullScreenModeToolStripMenuItem_Click(object sender, EventArgs e) {
            SessionManager.ChangeFullScreenMode();
        }
    }
}
