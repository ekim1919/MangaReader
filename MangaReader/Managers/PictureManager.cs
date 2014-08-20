using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

using MangaReader.Structs;
using MangaReader.ReaderForms;
using MangaReader.MessageBoxes;
using MangaReader.MessageBoxes.LastFirst;
using MangaReader.Initializers;
using MangaReader.Modes;

namespace MangaReader.Managers {

    /*
     * PictureManagerClass. The PictureManager class adds another layer of abstraction. It is responsible for keeping track of the current position in the image files list and loading the corresponding file into
     * the PictureBox of the corresponding form
     */
     public class PictureManager {

        private FileManager FM; 
        private BasicReader thisform;  
        private int FormNumber;
        private int CurrentPosition;
        private Mode PageMode;

        public PictureManager(FileManager FM,
                               BasicReader thisform,
                               int currentposition, //Constructor: CurrentPosition is defaulted to the first position.
                               int formnumber,
                               Mode pageMode) {
            this.FM = FM;
            this.thisform = thisform;
            PageMode = pageMode;
            CurrentPosition = currentposition;
            Initialize(currentposition);
            this.FormNumber = formnumber;
         }

        /* ------ Initialization Methods ---- */

        public void Initialize(int pos_to_use) {
            updatePic((FM.getPicAtPos(ref pos_to_use)));
        }
  
        /* ------ File Traversal Methods ---- */

        public void GotoNext() {
            PageMode.getNextPos(ref CurrentPosition);
            ImgStruct thisPic = FM.GetNextPos(ref CurrentPosition);

            if (!Settings.EndBeginAlerts || //This must be simplified and cleaned
                !thisPic.IsLastorFirstImage ||
                YesNoDialog.AskForAction(new FinishingObject())) {
                    updatePic(thisPic);
            } else {
                PageMode.getPrevPos(ref CurrentPosition); //Revert back to last picture 
            }
            System.Diagnostics.Debug.Write(CurrentPosition);
        }

        public void GoBack() {
            PageMode.getPrevPos(ref CurrentPosition);
            ImgStruct thisPic = FM.GetPrevPos(ref CurrentPosition);

            if (!Settings.EndBeginAlerts ||
                !thisPic.IsLastorFirstImage ||
                YesNoDialog.AskForAction(new BeginningObject())) {
                    updatePic(thisPic);
            } else {
                PageMode.getNextPos(ref CurrentPosition);
            }
            System.Diagnostics.Debug.Write(CurrentPosition);
        }
       
        public void updatePic(ImgStruct currentimg) {
            thisform.LoadPic(currentimg.Img);
            thisform.ChangeDirectoryTextBox(currentimg.Pathname);
        }

        public void ChangeReaderFullScreen() {
            thisform.ChangeFullScreen();
        }

        /* ------ Accessor Methods ---------- */

        public FileManager FileMana {
            get {
                return FM;
            }

            set {
                FM = value;
            }
        }

        public int CurrentPos {
            get {
                return CurrentPosition;
            }
        }

        public int FormNum {
            get {
                return FormNumber;
            }
        }
    }
}
