using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace MangaReader {

    /*
     * This is the MultiWindow class, the class responsible for tracking multiple forms and loading their corresponding pictures based on the viewing mode.
     * This class only supports two forms for now. Also, responsible for creating new clones and changing the reference of the clones' file managers when a new 
     * session is started 
     */

   internal class WindowManager {
       
        private List<PictureManager> CloneForms; //The Picture Manager of the Clone Form  
        private PictureManager PrimaryViewer;

        public WindowManager(PictureManager PicMan) {
            CloneForms = new List<PictureManager>();
            CloneForms.Add(PicMan); //Add the PictureManager for the first form 
            PrimaryViewer = PicMan; //Store the PrimaryViewer
        }

        internal void ChangeFileManager(FileManager NewFileMana, int main_starting_position) {
            int main_position = PrimaryViewer.CurrentPos;
            foreach(PictureManager mana in CloneForms) {
                int distance =  main_position - mana.CurrentPos;
                mana.FileMana = NewFileMana;
                mana.Initialize(main_starting_position - distance);
            }
        }

        internal void CreateNextBefore(PictureManager ReferenceMan) {
            AddtoCloneListandShow(
                new Clone(
                     ReferenceMan.FileMana, 
                     this, 
                     CloneForms.Count + 1, 
                    "Before Clone: " + ReferenceMan.FormNum, 
                     ReferenceMan.CurrentPos - 1));
        }

        internal void CreateNextAfter(PictureManager ReferenceMan) {
            AddtoCloneListandShow(
                  new Clone(ReferenceMan.FileMana, 
                       this, 
                       CloneForms.Count + 1, 
                      "After Clone: " + ReferenceMan.FormNum, 
                       ReferenceMan.CurrentPos + 1));
        }

        private void AddtoCloneListandShow(Clone newClone) {
            newClone.Show();
            CloneForms.Add(newClone.PicMana);
        }

        internal void RemoveClone(PictureManager ManaToRm) {
            CloneForms.Remove(ManaToRm); //Remove pointer to PictureManager ManatoRm once user disposes of Clone 
        }

        internal void Next() {
            foreach (PictureManager picman in CloneForms) {
                picman.GotoNext();
            }
        }

        internal void Back() {
            foreach (PictureManager picman in CloneForms) {
                picman.GoBack();
            }
        }

    }
   
}
