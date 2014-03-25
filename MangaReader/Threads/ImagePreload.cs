using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MangaReader.Threads {

    internal class ImagePreload {
        protected Image[] imgArray;
        protected Task[] taskArray;
        protected readonly List<String> ImageNames;

        public ImagePreload(List<String> pathnames) {
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

        internal virtual void LoadImages() {
            int count = 0;

            foreach (String names in ImageNames) {
                taskArray[count] = createTask(names, count);
                count++;
            }
            Task.WaitAll(taskArray);
        }

        internal virtual Image getImage(int position) {
            return imgArray[position];
        }
    }
}