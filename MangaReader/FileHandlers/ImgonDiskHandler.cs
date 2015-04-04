using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

using MangaReader.Threads;
namespace MangaReader.FileHandlers {
    public class ImgonDiskHandler : FileHandler {

        private String DirPathName;
        private String SelectedFilePathName;
        private NaiveImagePreload Images;

        public ImgonDiskHandler(String pathnameToFile) {
            SelectedFilePathName = pathnameToFile;
            DirPathName = Path.GetDirectoryName(SelectedFilePathName);
        }

        public override int initializeImgList() {
            FileNames = new List<String>(); 
            String[] Temp = Directory.GetFiles(DirPathName);

            foreach (String file in Temp) {
                if ((Path.GetExtension(file) == ".jpg") || 
                    (Path.GetExtension(file) == ".bmp") || 
                    (Path.GetExtension(file) == ".gif") || 
                    (Path.GetExtension(file) == ".png")) {
                    FileNames.Add(file);
                }
            }
            initializePreload(FileNames);
            return FileNames.IndexOf(SelectedFilePathName);
        }

        public override Image getImage(int position) {
            if (!Images.isTouch) { Images.LoadImages(position);} //We load the initial set of images when a picture manager ask for one. 
            return Images.getImage(position);
        }

        private void initializePreload(List<String> fileNames) {
            Images = new ImagePreloadDynamic(fileNames); //Testing for now
        }
    }
}
