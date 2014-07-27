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
/*  
 * 
 * FileManager Class: The class responsible for 
 */
namespace MangaReader.Managers {

    internal class FileManager {

        private  FileHandler FileHand;
        private int FileHandLength;

        internal int Initialize() {
            OpenFileDialog fileresult = new OpenFileDialog();
            fileresult.Filter = "Image Files (*.JPG;*.BMP;*.GIF;*.PNG)|*.JPG;*.BMP;*.GIF;*.PNG|Zip Files (*.ZIP)|*.ZIP"; 
            fileresult.FilterIndex = 2;
            fileresult.RestoreDirectory = true;
            int FileIndex = -1;

            if (fileresult.ShowDialog() == DialogResult.OK) {
                try {
                    FileHand = (Path.GetExtension(fileresult.FileName).Equals(".zip")) ? (FileHandler) new ZipHandler(fileresult.FileName) :
                                                                                         (FileHandler) new ImgonDiskHandler(fileresult.FileName);
                    FileIndex = FileHand.initializeImgList();
                    FileHandLength = FileHand.getImgListLen();

                } catch (Exception a) { //More specific ?
                    MessageBox.Show("Error: " + a.Message);
                }
            } 

            return FileIndex;
        }

        internal ImgStruct GetNextPos(ref int CurrentPosition) {
            if (CurrentPosition < FileHandLength - 1) {
                CurrentPosition++;
            } else {
                CurrentPosition = 0; //Start from the beginning  
            }

            bool isLast = (CurrentPosition == 0);

            return new ImgStruct(FileHand.getImage(CurrentPosition),
                                 FileHand.getImagePath(CurrentPosition),
                                 isLast);
        }

        internal ImgStruct GetPrevPos(ref int CurrentPosition) {
            if (CurrentPosition > 0) {
                CurrentPosition--;
            } else {
                CurrentPosition = FileHandLength - 1; //Start from end. 
            }

            bool isFront = (CurrentPosition == FileHandLength - 1);

            return new ImgStruct(FileHand.getImage(CurrentPosition),
                                 FileHand.getImagePath(CurrentPosition),
                                 isFront);
         }
        
        internal ImgStruct getPicAtPos(ref int CurrentPosition) {
            if (CurrentPosition < 0) {
                CurrentPosition = 0;
            }
            else if (CurrentPosition > FileHandLength - 1) {
                CurrentPosition = FileHandLength - 1;
            }

            return new ImgStruct(FileHand.getImage(CurrentPosition),
                                 FileHand.getImagePath(CurrentPosition),
                                 false);
        }

    }
}

