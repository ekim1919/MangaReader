using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MangaReader {
    internal partial class BasicReader : Form {

        protected WindowManager WinMan;
        protected PictureManager PicMan;

        public BasicReader() {
            InitializeComponent();
            WinMan = null;
            PicMan = null;
        }

        public BasicReader(WindowManager winman, FileManager mana, int pos_to_start, int formnumber) {
            InitializeComponent();
            WinMan = winman;
            PicMan = new PictureManager(mana, this, pos_to_start, formnumber);
        }

        public void LoadPic(String pathname) {
            PictureBox.Load(pathname);
        }

        public void ChangeDirectoryTextBox(String text) {
            FullDirectory.Text = text;
        }

    }
}
