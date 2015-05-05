using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MangaReader.PicLoadMethods {

    public class NoThreading : PicLoadMethod {

        private List<String> ImageNames;

        public NoThreading(List<String> pathnames) {
            ImageNames = pathnames;
            isTouched = true;
        }

        public override Image getImage(int position) {
            return new Bitmap(ImageNames[position]);
        }

        public override void LoadImages(int postion) { }
    }
}
