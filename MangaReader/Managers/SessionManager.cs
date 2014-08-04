using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MangaReader.Managers {

    public static class SessionManager {

        private static WindowManager WinMan;

        public static void CreateWinMan(PictureManager picman) {
            WinMan = new WindowManager(picman);
        }

        public static void newFileManager() {
            FileManager newSession = new FileManager();
            int chosen_file_index = newSession.Initialize();

            if (chosen_file_index >= 0) {
                WinMan.ChangeFileManager(newSession, chosen_file_index);
            }
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
                WinMan.CreateNextBefore(picman);
            }
        }

        public static void CreateAfterClone(PictureManager picman) {
            if (picman != null) {
                WinMan.CreateNextAfter(picman);
            }
        }

        public static void RemoveClonePicMan(PictureManager picman) {
            WinMan.RemoveClone(picman);
        }
    }
}
