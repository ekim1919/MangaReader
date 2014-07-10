using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MangaReader.Managers;

namespace MangaReader.Initializers {

    internal static class SessionInitializer {

        internal static WindowManager WinMan;

        public static void newFileManager() {
            FileManager newSession = new FileManager();
            int chosen_file_index = newSession.Initialize();

            if (chosen_file_index >= 0) {
                WinMan.ChangeFileManager(newSession, chosen_file_index);
            }
        }
    }
}
