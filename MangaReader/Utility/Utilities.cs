using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MangaReader.Utility
{
    public static class Utilities {

        public static int mod(int x, int y) {
            int result = x % y;
            return (result < 0) ? result + y :  result;
        }
    }
}
