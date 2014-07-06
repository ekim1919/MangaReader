using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MangaReader.MultiMonitor {

    #warning Code not in use until Screen recognition feature is developed more
 
    internal class ReaderMover {
        Screen[] userScreens = Screen.AllScreens;

        public ReaderMover() {

        }

        internal Screen[] getScreens() {
            return userScreens;
        }

    }
}
