using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MangaReader.Modes {
    public interface Mode {

        int getNextPos(ref int currentpos);
        int getPrevPos(ref int currentpos);

    }
}
