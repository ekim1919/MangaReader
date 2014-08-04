using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MangaReader.Structs {

    public struct DBStruct {
        public String Pathname;
        public int SavedPos, Mode;

        public DBStruct(String pathname, int savedpos, int mode) {
            Pathname = pathname;
            SavedPos = savedpos;
            Mode = mode;
        }
    }
}
