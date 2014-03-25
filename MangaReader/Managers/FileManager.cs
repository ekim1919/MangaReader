using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

using MangaReader.Threads;
using MangaReader.Structs;
/*  
 * 
 * FileManager Class: The class responsible for 
 */
namespace MangaReader {

    internal class FileManager {

        private readonly List<String> FileNames;
        private ImagePreload Images;

        public FileManager() {
            FileNames = new List<String>();
        }

        internal int Initialize() {
            OpenFileDialog fileresult = new OpenFileDialog();
            fileresult.Filter = "Image Files (*.JPG;*.BMP;*.GIF;*.PNG)|*.JPG;*.BMP;*.GIF;*.PNG";
            fileresult.FilterIndex = 2;
            fileresult.RestoreDirectory = true;
            int FileIndex = -1;

            if (fileresult.ShowDialog() == DialogResult.OK) {
                try {
                    FileIndex = FindFiles(Path.GetDirectoryName(fileresult.FileName),fileresult.FileName);
                    initializePreload(FileIndex);
                } catch (Exception a) { //More specific ?
                    MessageBox.Show("Error: " + a.Message);
                }
            } 

            return FileIndex;
        }

        //Add all valid picture files into FileNames List. 
        private int FindFiles(String SourceDirectory, String SourceFile) {
            String[] Temp = Directory.GetFiles(SourceDirectory);
            int ChosenFileIndex = 0; //Defaults to the beginning picture 

            foreach (String file in Temp) {
                if ((Path.GetExtension(file) == ".jpg") || 
                    (Path.GetExtension(file) == ".bmp") || 
                    (Path.GetExtension(file) == ".gif") || 
                    (Path.GetExtension(file) == ".png")) {
                    FileNames.Add(file);
                    
                    if(file.Equals(SourceFile)) {
                        ChosenFileIndex = FileNames.IndexOf(file); //Finds the index of the picture the user chose while going through iteration
                    }
                    
                }
            }

            return ChosenFileIndex;
        }

        private void initializePreload(int FileIndex) {
            Images = new ImagePreload(FileNames);
            Images.LoadImages();
        }

        internal ImgStruct GetNextPos(ref int CurrentPosition) {
            if (CurrentPosition < FileNames.Count - 1) {
                CurrentPosition++;
            } else {
                CurrentPosition = 0; //Start from the beginning  
            }

            return new ImgStruct(Images.getImage(CurrentPosition),
                                 FileNames[CurrentPosition]);
        }

        internal ImgStruct GetPrevPos(ref int CurrentPosition) {
            if (CurrentPosition > 0) {
                CurrentPosition--;
            } else {
                CurrentPosition = FileNames.Count - 1; //Start from end. 
            }

            return new ImgStruct(Images.getImage(CurrentPosition),
                                 FileNames[CurrentPosition]);
         }

        internal ImgStruct getPicAtPos(ref int CurrentPosition) {
            if (CurrentPosition < 0) {
                CurrentPosition = 0;
            } else if (CurrentPosition > FileNames.Count - 1) {
                CurrentPosition = FileNames.Count - 1;
            }

            return new ImgStruct(Images.getImage(CurrentPosition),
                                 FileNames[CurrentPosition]);
        }

    }
}

