using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MangaReader.Modes {
    public class DualMode : Mode {

        public int getNextPos(ref int currentpos) {
            return (currentpos += 2);
        }

        public int getPrevPos(ref int currentpos) {
            return (currentpos -= 2);
        }
    }
}
