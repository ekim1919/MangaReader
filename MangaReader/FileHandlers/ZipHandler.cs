using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using Ionic.Zip;

/*
 *  The Ionic.Zip.dll is redistributed under the Microsoft Public License. 
 * 
 */
namespace MangaReader.FileHandlers {

    /*
     * This class utilizes the Ionic,Zip.dll from the DotNetZip  Library project
     * Site: http://dotnetzip.codeplex.com/
     * Legal use is guarenteed by the Microsoft Public License (Ms-PL)
     * License: http://dotnetzip.codeplex.com/license
     */

    public class ZipHandler : FileHandler {

        private ZipFile file;

        public ZipHandler(String pathnameToZip) {
            file = new ZipFile(pathnameToZip);
        }

        public override Image getImage(int position) {
            using (MemoryStream imageStream = new MemoryStream()) {
                String imageName = FileNames[position];
                file[imageName].Extract(imageStream);
                return Image.FromStream(imageStream);
            }
        }

        public override int initializeImgList() {
            FileNames = new List<String>();
            foreach(ZipEntry ent in file) {
                FileNames.Add(ent.FileName);
            }
            return 0; //For now, start from beginning of zip file
        }

        ~ZipHandler() {
            file.Dispose(); //Ensure disposal of IDisposable object, ZipFile
        }
    }
}
