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

namespace MangaReader.Managers {

    /*
     * PictureManagerClass. The PictureManager class adds another layer of abstraction. It is responsible for keeping track of the current position in the image files list and loading the corresponding file into
     * the PictureBox of the corresponding form
     */
     public class PictureManager {

        private FileManager FM; 
        private BasicReader thisform;  
        private int CurrentPosition;
        private int FormNumber;

        public PictureManager(FileManager FM, 
                              BasicReader thisform, 
                              int CurrentPosition, 
                              int FormNumber) { //Constructor: CurrentPosition is defaulted to the first position. 
            this.FM = FM;
            this.thisform = thisform;
            Initialize(CurrentPosition);
            this.FormNumber = FormNumber;
        }

        /* ------ Initialization Methods ---- */

        public void Initialize(int pos_to_use) {
            CurrentPosition = pos_to_use;
            updatePic((FM.getPicAtPos(ref CurrentPosition)));
        }
  
        /* ------ File Traversal Methods ---- */

        public void GotoNext() {
            ImgStruct thisPic = FM.GetNextPos(ref CurrentPosition);

            if (!Settings.Alerts || 
                !thisPic.getLastorFirstImage ||
                YesNoDialog.AskForAction(new FinishingObject())){
                    updatePic(thisPic);
            } else {
                CurrentPosition--; //Revert back to last picture due to GetNextPos using by reference passing 
            }
        }

        public void GoBack() {
            ImgStruct thisPic = FM.GetPrevPos(ref CurrentPosition);

            if (!Settings.Alerts ||
                !thisPic.getLastorFirstImage ||
                YesNoDialog.AskForAction(new BeginningObject())) {
                    updatePic(thisPic);
            } else {
                CurrentPosition++;
            }
        }
       
        public void updatePic(ImgStruct currentimg) {
            thisform.LoadPic(currentimg.getImg);
            thisform.ChangeDirectoryTextBox(currentimg.getPath);
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
