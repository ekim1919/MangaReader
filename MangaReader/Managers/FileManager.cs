using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

using MangaReader.Structs;
using MangaReader.FileHandlers;
using MangaReader.Utility;
/*  
 * 
 * FileManager Class: The class responsible for 
 */
namespace MangaReader.Managers {

    public class FileManager {

        private  FileHandler FileHand;
        private int FileHandLength;

        public int InitializeThroughDialog() {
            OpenFileDialog fileresult = new OpenFileDialog();
            fileresult.Filter = "Image Files (*.JPG;*.BMP;*.GIF;*.PNG)|*.JPG;*.BMP;*.GIF;*.PNG|Zip Files (*.ZIP)|*.ZIP"; 
            fileresult.FilterIndex = 2;
            fileresult.RestoreDirectory = true;
            int FileIndex = -1;

            if (fileresult.ShowDialog() == DialogResult.OK) {
                try {
                    FileHand = getFileHand(fileresult.FileName);
                    FileIndex = FileHand.initializeImgList();
                    FileHandLength = FileHand.getImgListLen();

                } catch (Exception a) { //More specific ?
                    MessageBox.Show("Error: " + a.Message);
                }
            } 

            return FileIndex;
        }

        /*
         *   
         */
        public int InitializeThroughPathName(String pathName) {
            FileHand = getFileHand(pathName);
            int FileIndex = FileHand.initializeImgList();
            FileHandLength = FileHand.getImgListLen();

            return FileIndex;
        }

        private FileHandler getFileHand(String pathName) {
            return (Path.GetExtension(pathName).Equals(".zip")) ? (FileHandler)new ZipHandler(pathName) :
                                                                             (FileHandler)new ImgonDiskHandler(pathName);
        }

        public ImgStruct GetNextPos(ref int CurrentPosition) {
            bool has_reached_end = CurrentPosition > FileHandLength - 1;

            if (has_reached_end && CurrentPosition != FileHandLength - 1) {
                CurrentPosition = Utilities.mod(CurrentPosition, FileHandLength);
            }

            return new ImgStruct(FileHand.getImage(CurrentPosition),
                                 FileHand.getImagePath(CurrentPosition),
                                 has_reached_end);
        }

        public ImgStruct GetPrevPos(ref int CurrentPosition) {
            bool has_reached_beginning = CurrentPosition < 0;

            if (has_reached_beginning && CurrentPosition != 0) {
                CurrentPosition = Utilities.mod(CurrentPosition, FileHandLength);
            }

            return new ImgStruct(FileHand.getImage(CurrentPosition),
                                 FileHand.getImagePath(CurrentPosition),
                                 has_reached_beginning);
         }
        
        public ImgStruct getPicAtPos(ref int CurrentPosition) {
            if ((CurrentPosition < 0) || (CurrentPosition > FileHandLength - 1)) {
                CurrentPosition = Utilities.mod(CurrentPosition, FileHandLength);
            }

            return new ImgStruct(FileHand.getImage(CurrentPosition),
                                 FileHand.getImagePath(CurrentPosition),
                                 false);
        }

        public String getPathNameatPos(int CurrentPosition) {
            return FileHand.getImagePath(CurrentPosition);
        }
    }
}

