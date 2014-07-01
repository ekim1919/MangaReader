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

namespace MangaReader.ReaderForms {

    internal partial class BasicReader : Form {

        protected WindowManager WinMan;
        protected PictureManager PicMan;
        protected bool FullScreenMode;

        private ZoomManager ThisFormZoom;
        public int CurrentZoomFactor = 1;

        public BasicReader() {
            InitializeComponent();
            WinMan = null;
            PicMan = null;
            ThisFormZoom = null;
            FullScreenMode = false;
        }

        public BasicReader(WindowManager winman, FileManager mana, int pos_to_start, int formnumber) {
            InitializeComponent();
            WinMan = winman;
            PicMan = new PictureManager(mana, this, pos_to_start, formnumber);
        }

        public void LoadPic(Image img) {
            PictureBox.Image = img;
            ThisFormZoom = new ZoomManager(img, img.Width, img.Height);
        }

        public void ChangeDirectoryTextBox(String pathname) {
            FullDirectory.Text = pathname;
        }

        /* Method that changes the window form to go full screen or normal mode */
        internal void ChangeFullScreen() { 
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
           ThisFormZoom.setZoomedImage(PictureBox, ref CurrentZoomFactor, e.Delta);
       }
    }
}