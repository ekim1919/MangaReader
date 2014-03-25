using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace MangaReader.Threads {

    /* A Basic implementaion of a Dynamic Threading solution. 
     * Instead of Threading the Disk IO Picture Retrieval all at once like ImagePreload. 
     * It only threads the pictures in a local area (the previous, current, and next picture) 
     * This decreases the session initialization time.
     * TODOs: Add a memory recycling option because it keeps all the pictures (bitmaps) in memory. 
     */
    internal class ImagePreloadDynamic : ImagePreload {
        private int initialIndex;

        public ImagePreloadDynamic(List<String> pathname, int initial_index) : base(pathname) {
            initialIndex = initial_index;
        }

        internal override void LoadImages() {
            LoadThreads(initialIndex);
        }

        internal override Image getImage(int position) {
            Task wantedTsk = taskArray[position];
            if(!wantedTsk.IsCompleted) {
                wantedTsk.Wait();
            }
            LoadThreads(position);
            return base.getImage(position);
        }

        internal void LoadThreads(int position) {
            int[] threadStart = { position - 1, position, position + 1 };
            for (int i = 0; i < 3; i++) {
                int index = threadStart[i];
                if (index >= 0 &&
                     index < ImageNames.Count &&
                     imgArray[index] == null) {
                     taskArray[index] = createTask(ImageNames[index], index);
                } 
            }
        }
    }
}
