using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using Ionic.Zip;

namespace MangaReader.FileHandlers {
    
    public class ZipHandler : FileHandler {

        private ZipFile file;

        public ZipHandler(String pathnameToZip) {
            file = new ZipFile(pathnameToZip);
        }

        public override Image getImage(int position) {
            MemoryStream imageStream = new MemoryStream();
            String imageName = FileNames[position];
            file[imageName].Extract(imageStream);
            return Image.FromStream(imageStream);
        }

        public override int initializeImgList() {
            FileNames = new List<String>();
            foreach(ZipEntry ent in file) {
                FileNames.Add(ent.FileName);
            }
            return 0; //For now, start from beginning of zip file
        }
    }
}
