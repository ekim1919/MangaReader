using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MangaReader.PicLoadMethods {

    public class NaiveImagePreload : PicLoadMethod {
        protected Task[] taskArray;
        protected Image[] imgArray;
        protected readonly List<String> ImageNames;

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

        public override void LoadImages(int initialIndex) {
            int count = 0;

            foreach (String names in ImageNames) {
                taskArray[count] = createTask(names, count);
                count++;
            }
            Task.WaitAll(taskArray);
        }

        public override Image getImage(int position) {
            return imgArray[position];
        }
    }
}