using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MangaReader.Structs {

    public struct ImgStruct {
        public Image Img;
        public String Pathname;
        public bool IsLastorFirstImage;

        public ImgStruct(Image img, string pathname, bool islast) {
            Img = img;
            Pathname = pathname;
            IsLastorFirstImage = islast;
        }
    }
}
