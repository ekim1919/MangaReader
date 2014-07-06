using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MangaReader.Structs {

    internal struct ImgStruct {
        Image Img;
        string Pathname;
        bool IsLastorFirstImage;

        public ImgStruct(Image img, string pathname, bool islast) {
            Img = img;
            Pathname = pathname;
            IsLastorFirstImage = islast;
        }

        internal Image getImg {
            get {
                return Img;
            }
        }

        internal string getPath {
            get {
                return Pathname;
            }
        }

        internal bool getLastorFirstImage {
            get {
                return IsLastorFirstImage;
            }
        }
    }
}
