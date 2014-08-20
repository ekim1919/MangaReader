using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MangaReader.Modes {
    public class DefaultMode : Mode {

        public int getNextPos(ref int currentpos) {
            return ++currentpos;
        }

        public int getPrevPos(ref int currentpos) {
            return --currentpos;
        }
    }
}
