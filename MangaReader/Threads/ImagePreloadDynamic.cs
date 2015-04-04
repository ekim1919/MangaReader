using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Diagnostics;

using MangaReader.Utility;

namespace MangaReader.Threads {

    /* A Basic implementaion of a Dynamic Threading solution. 
     * Instead of Threading the Disk IO Picture Retrieval all at once like ImagePreload. 
     * It only threads the pictures in a local area (the previous, current, and next picture) 
     * This decreases the session initialization time.
     * NOTE: This implementation is very simple. Only supports moving forward and backwards by one picture. I have to think of something more complex later.
     */
    public class ImagePreloadDynamic : NaiveImagePreload {
        private int currentPosition;

        public ImagePreloadDynamic(List<String> pathname) : base(pathname) { isTouched = false; }

        public override void LoadImages(int initialIndex) { //Procedure called directly after creating object
            int BeforeInitial = Utilities.mod(initialIndex-1,ImageNames.Count);
            int AfterInitial = Utilities.mod(initialIndex + 1,ImageNames.Count); 
            taskArray[initialIndex] = createTask(ImageNames[initialIndex], initialIndex);
            taskArray[BeforeInitial] = createTask(ImageNames[BeforeInitial], BeforeInitial);
            taskArray[AfterInitial] = createTask(ImageNames[AfterInitial], AfterInitial);
            isTouched = true; //An access was recorded and the preloader was touched
        }

        public override Image getImage(int position) {
            //Debug.Assert((position == mod(currentPosition + 1) || (position == mod(currentPosition - 1)) || (position == currentPosition))); //This is made for only modes which go one page at a time
           

            Task wantedTsk = taskArray[position];
            if(!wantedTsk.IsCompleted) {
                wantedTsk.Wait();
            }
            LoadThreads(position);
            return base.getImage(position);
        }

        public void LoadThreads(int position) {
            int newPos = 0; 
            if(position == mod(currentPosition + 1)) { //Moved Forward
                imgArray[mod(currentPosition - 1)].Dispose(); //Dynamically Disposing of pictures not in a one picture radius around the position used.
                newPos = mod(position+1);
            }
            else if (position == currentPosition - 1) { //Moved Backwards
                imgArray[mod(currentPosition + 1)].Dispose();
                newPos = mod(position-1);
            }
            taskArray[newPos] = createTask(ImageNames[newPos],newPos); 
            currentPosition = position;
        }

        private int mod(int x) {
            return Utilities.mod(x, ImageNames.Count);
        }
    }

}
