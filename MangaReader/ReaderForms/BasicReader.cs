using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MangaReader.Managers;
using MangaReader.Events;
using MangaReader.Modes;

namespace MangaReader.ReaderForms {

    public partial class BasicReader : Form {

        protected PictureManager PicMan;
        protected bool FullScreenMode;

        private ZoomManager ThisFormZoom;

        public BasicReader() {
            InitializeComponent();
            PicMan = null;
            ThisFormZoom = null;
            FullScreenMode = false;
        }

        public BasicReader(FileManager mana, int pos_to_start, int formnumber, Mode pageMode) {
            InitializeComponent();
            PicMan = new PictureManager(mana, this, pos_to_start, formnumber, pageMode);
        }

        public void LoadPic(Image img) {
            PictureBox.Image = img;
            ThisFormZoom = new ZoomManager(img, img.Width, img.Height);
        }

        public void ChangeDirectoryTextBox(String pathname) {
            FullDirectory.Text = pathname;
        }

        /* Method that changes the window form to go full screen or normal mode */
        public void ChangeFullScreen() { 
            if(FullScreenMode) {
               WindowState = FormWindowState.Maximized;
                FormBorderStyle = FormBorderStyle.None;
            } else {
                WindowState = FormWindowState.Normal;
                FormBorderStyle = FormBorderStyle.Fixed3D;
            }
            FullScreenMode = !FullScreenMode;
       }

       protected void Reader_MouseWheel(object sender, MouseEventArgs e) {
           try{
                ThisFormZoom.setZoomedImage(PictureBox, e.Delta, e.X, e.Y);
           } catch (NullReferenceException a) { }
       }
    }
}