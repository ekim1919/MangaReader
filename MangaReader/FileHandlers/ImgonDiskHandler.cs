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
        private ImagePreload Images;

        public ImgonDiskHandler(String pathnameToFile) {
            SelectedFilePathName = pathnameToFile;
            DirPathName = Path.GetDirectoryName(SelectedFilePathName);
        }

        public override int initializeImgList() {
            FileNames = new List<String>(); 
            String[] Temp = Directory.GetFiles(DirPathName);
            int chosenIndex = 0;

            for (int i = 0; i < Temp.Length; i++) {
                String file = Temp[i];
                if ((Path.GetExtension(file) == ".jpg") || 
                    (Path.GetExtension(file) == ".bmp") || 
                    (Path.GetExtension(file) == ".gif") || 
                    (Path.GetExtension(file) == ".png")) {
                    FileNames.Add(file);
              
                    if(SelectedFilePathName.Equals(file)) {
                        chosenIndex = i;
                    }
                }
            }
            initializePreload(FileNames);
            return chosenIndex;
        }

        public override Image getImage(int position) {
            return Images.getImage(position);
        }

        private void initializePreload(List<String> fileNames) {
            Images = new ImagePreload(fileNames);
            Images.LoadImages();
        }
    }
}
