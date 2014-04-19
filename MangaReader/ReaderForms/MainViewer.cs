using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

using MangaReader.Managers;
using MangaReader.SettingsForms;

namespace MangaReader.ReaderForms {
 
   internal partial class Viewer : BasicReader {
 
        public Viewer() : base() { 
            InitializeComponent();
            PictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            this.Text = "MangaReader Form: 1";
        }

        private void InitializeSession() { //Work on initializatrion
            FileManager SessionMana = new FileManager();
            int chosen_file_index = SessionMana.Initialize();
         
            //Create Picture Manager for the Main Viewer  
            if(chosen_file_index >= 0) {           
                PicMan = new PictureManager(SessionMana,
                        this,
                        chosen_file_index,
                        1);
                WinMan = new WindowManager(PicMan); //Create Window Manager for Current Session
            }
        }

       /* ------------------- Form Event Methods --------------------*/

        private void openFileToolStripMenuItem1_Click(object sender, EventArgs e) { //Figure out a way to stop duplicating this code 
            if (PicMan == null) {
                InitializeSession();
            } else {
                FileManager newSession = new FileManager();
                int chosen_file_index = newSession.Initialize();

                if(chosen_file_index >= 0) {
                    WinMan.ChangeFileManager(newSession, chosen_file_index);
                }
            }
        }

        private void BeforeOption_Click(object sender, EventArgs e) {
            if (PicMan != null) { // Do not create clone if session is not initialized 
                WinMan.CreateNextBefore(PicMan);
            } 
        }

        private void AfterOption_Click(object sender, EventArgs e) {
            if (PicMan != null) {
                WinMan.CreateNextAfter(PicMan);
            }
        }

        private void zoomToolStripMenuItem_Click(object sender, EventArgs e) {
            PictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void centerToolStripMenuItem_Click(object sender, EventArgs e) {
            PictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void Viewer_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode.Equals(Keys.Space) && WinMan != null){
                WinMan.Next();
            } else if (e.KeyCode.Equals(Keys.Back) && WinMan != null) {
                WinMan.Back();
            }
        }

        private void fullScreenModeToolStripMenuItem_Click(object sender, EventArgs e) {
            if(WinMan != null) {
                WinMan.ChangeFullScreenAll();
            }
        }

    }

}