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
using MangaReader.Initializers;
using MangaReader.SettingsForms;
using MangaReader.Modes;

namespace MangaReader.ReaderForms {
 
   public partial class MainViewer : BasicReader {
 
        public MainViewer() : base() { 
            InitializeComponent();
            this.MouseWheel += new MouseEventHandler(Reader_MouseWheel);
            PictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            this.Text = "MangaReader Form: 1";
        }

        private void InitializeSession() { //Work on initialization
            FileManager SessionMana = new FileManager();
            int chosen_file_index = SessionMana.Initialize();
         
            //Create Picture Manager for the Main Viewer  
            if(chosen_file_index >= 0) {           
                PicMan = new PictureManager(SessionMana,
                                            this,
                                            chosen_file_index,
                                            1,
                                            new DefaultMode());
                SessionManager.CreateWinMan(PicMan); //Set WindowsManager for Static class responsible for reinitialization
            }
        }

       /* ------------------- Form Event Methods --------------------*/

        private void openFileToolStripMenuItem1_Click(object sender, EventArgs e) { //Figure out a way to stop duplicating this code 
            if (PicMan == null) {
                InitializeSession();
            } else {
                SessionManager.newFileManager();
            }
        }

        private void BeforeOption_Click(object sender, EventArgs e) {
            SessionManager.CreateBeforeClone(PicMan);
        }

        private void AfterOption_Click(object sender, EventArgs e) {
            SessionManager.CreateAfterClone(PicMan);
        }

        private void zoomToolStripMenuItem_Click(object sender, EventArgs e) {
            PictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void centerToolStripMenuItem_Click(object sender, EventArgs e) {
            PictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void Viewer_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode.Equals(Keys.Space)) {
                SessionManager.NextPicture();
            } else if (e.KeyCode.Equals(Keys.Back)) {
                SessionManager.PrevPicture();
            }
        }

        private void fullScreenModeToolStripMenuItem_Click(object sender, EventArgs e) {
            SessionManager.ChangeFullScreenMode();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e) {
            SettingsForm newSettings = new SettingsForm(this);
            newSettings.Show();
            Enabled = false;
        }

    }

}