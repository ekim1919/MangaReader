using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MangaReader.MultiMonitor;
using MangaReader.ReaderForms;
using MangaReader.Initializers;

namespace MangaReader.SettingsForms {

    internal partial class SettingsForm : Form {
        private MainViewer parent;

        public SettingsForm(MainViewer parent) {
            InitializeComponent();
            AlertCheckBox.Checked = Settings.EndBeginAlerts;
            this.parent = parent;
        }

        /*Implement Monitor Autodectection features. May have to bring in c++ dlls*/
        /*
        private void initializePanels() {
            ReaderMover readmov = new ReaderMover();
            Screen[] userscreens = readmov.getScreens();
            foreach(Screen sc in userscreens) {
                Label newcombo = new Label();
                newcombo.AutoSize = true;
                newcombo.Text = "Width: " + sc.WorkingArea.Width +
                                "\nHeight: " + sc.WorkingArea.Height;
                MonitorPanel.Controls.Add(newcombo);
            
        }
        */

        private void AlertCheckBox_CheckedChanged(object sender, EventArgs e) {
            Settings.EndBeginAlerts = AlertCheckBox.Checked;
        }

        private void SaveSessionCheckBox_CheckedChanged(object sender, EventArgs e) {
            Settings.SavedSessionAlerts = SaveSessionCheckBox.Checked;
        }

        private void ThreadFeature_CheckedChanged(object sender, EventArgs e) {
            Settings.DynamicThreading = ThreadFeature.Checked;
        }
    }
 }
