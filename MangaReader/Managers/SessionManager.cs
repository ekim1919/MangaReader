using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MangaReader.Modes;
namespace MangaReader.Managers {

    public static class SessionManager {

        private static WindowManager WinMan;

        public static void CreateWinMan(PictureManager picman) {
            WinMan = new WindowManager(picman);
        }

        /*
         * This method is to intialize a new file manager and initialize through a dialog where the user can choose his/her file.
         */
        public static void newFileManagerThroughDialog() {
            FileManager newSession = new FileManager();
            int chosen_file_index = newSession.InitializeThroughDialog();

            if ((chosen_file_index >= 0) && (WinMan != null)) {
                WinMan.ChangeFileManager(newSession, chosen_file_index);
            }
        }

        public static void newFileManager(String pathName, int posToInit) {
            FileManager newSession = new FileManager();
            int chosen_file_index = newSession.InitializeThroughPathName(pathName);

            WinMan.ChangeFileManager(newSession, posToInit);
        }

        public static void NextPicture() {
            if (WinMan != null) {
                WinMan.Next();
            }
        }

        public static void PrevPicture() {
            if (WinMan != null) {
                WinMan.Back();
            }
        }

        public static void ChangeFullScreenMode() {
            if(WinMan != null) {
                WinMan.ChangeFullScreenAll();
            }
        }

        public static void CreateBeforeClone(PictureManager picman) {
            if (picman != null) {   // Do not create clone if session is not initialized 
                WinMan.CreateNextBefore(picman, new DefaultMode());
            }
        }

        public static void CreateAfterClone(PictureManager picman) {
            if (picman != null) {
                WinMan.CreateNextAfter(picman, new DefaultMode());
            }
        }

        public static void RemoveClonePicMan(PictureManager picman) {
            WinMan.RemoveClone(picman);
        }

        public static bool WinManNotInit {
            get {
                return (WinMan == null);
            }
        }
    }
}
