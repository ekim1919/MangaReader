using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.IO;

/*  
 * 
 * FileManager Class: The class responsible for 
 */
namespace MangaReader {

    internal class FileManager {

        private readonly List<String> FileNames;

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
                    Console.Write(fileresult.FileName);
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

        internal String GetNextPos(ref int CurrentPosition) {
            if (CurrentPosition < FileNames.Count - 1) {
                CurrentPosition++;
            } else {
                CurrentPosition = 0; //Start from the beginning  
            }

            return FileNames[CurrentPosition];
        }

        internal String GetPrevPos(ref int CurrentPosition) {
            if (CurrentPosition > 0) {
                CurrentPosition--;
            } else {
                CurrentPosition = FileNames.Count - 1; //Start from end. 
            }

            return FileNames[CurrentPosition];
         }

        internal String getPicAtPos(ref int CurrentPosition) {
            if (CurrentPosition < 0) {
                CurrentPosition = 0;
            } else if (CurrentPosition > FileNames.Count - 1) {
                CurrentPosition = FileNames.Count - 1;
            }

            return FileNames[CurrentPosition];
        }

    }
}

