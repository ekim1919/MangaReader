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

namespace MangaReader.SettingsForms {

    internal partial class Settings : Form {
        private MainViewer parent;

        public Settings(MainViewer parent) {
            InitializeComponent();
            initializePanels();
            this.parent = parent;
        }
        /*Implement Monitor Autodectection features. May have to bring in c++ dlls*/
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

    }
}
}