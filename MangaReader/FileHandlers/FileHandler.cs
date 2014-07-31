using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MangaReader.FileHandlers {
   public abstract class FileHandler {
        protected List<String> FileNames;
        
        public String getImagePath(int position) {
            return FileNames[position];
        }

        public int getImgListLen() {
            return FileNames.Count;
        }

        abstract public int initializeImgList();
        abstract public Image getImage(int position);
    }


}
