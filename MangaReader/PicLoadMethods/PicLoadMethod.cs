using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MangaReader.PicLoadMethods {
    public abstract class PicLoadMethod {

        protected bool isTouched; //A simple flag which tells if one of the windows has requested a picture from the preloader.

        abstract public Image getImage(int position); //Responsible for returning Image.
        abstract public void LoadImages(int postion); //Is the initialization procedure some methods choose to use to load in some images first.

        public bool isTouch {
            get {
                return isTouched;
            }
        }
    }
}
