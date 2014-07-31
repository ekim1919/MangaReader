using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MangaReader.Structs {

    public struct ImgStruct {
        Image Img;
        String Pathname;
        bool IsLastorFirstImage;

        public ImgStruct(Image img, string pathname, bool islast) {
            Img = img;
            Pathname = pathname;
            IsLastorFirstImage = islast;
        }

        public Image getImg {
            get {
                return Img;
            }
        }

        public string getPath {
            get {
                return Pathname;
            }
        }

        public bool getLastorFirstImage {
            get {
                return IsLastorFirstImage;
            }
        }
    }
}
