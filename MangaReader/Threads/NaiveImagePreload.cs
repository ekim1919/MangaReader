using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MangaReader.Threads {

    public class NaiveImagePreload {
        protected Image[] imgArray;
        protected Task[] taskArray;
        protected readonly List<String> ImageNames;
        protected bool isTouched; //A simple flag which tells if one of the windows has requested a picture from the preloader.

        public NaiveImagePreload(List<String> pathnames) {
            imgArray = new Bitmap[pathnames.Count];
            taskArray = new Task[pathnames.Count];
            ImageNames = pathnames;
        }
  
        private void LoadBitMap(String pathname, int index) {
            imgArray[index] = new Bitmap(pathname);
        }

        protected Task createTask(String pathname, int index) {
            Task tsk = new Task(() => LoadBitMap(pathname, index));
            tsk.Start();
            return tsk;
        }

        public virtual void LoadImages(int initialIndex) {
            int count = 0;

            foreach (String names in ImageNames) {
                taskArray[count] = createTask(names, count);
                count++;
            }
            Task.WaitAll(taskArray);
        }

        public virtual Image getImage(int position) {
            return imgArray[position];
        }

        public bool isTouch {
            get{
                return isTouched;
            }
        }
    }
}