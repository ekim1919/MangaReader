using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MangaReader.Structs {

    internal struct ImgStruct {
        Image img;
        String pathname;

        public ImgStruct(Image img, String pathname) {
            this.img = img;
            this.pathname = pathname;
        }

        internal Image getImg {
            get {
                return img;
            }
        }

        internal string getPath {
            get {
                return pathname;
            }
        }
    }
}
