using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;

using MangaReader.ReaderForms;

namespace MangaReader.Events {


    internal class ZoomManager {
        private readonly int NUM_OF_ZOOM_PIXELS = 5;
                
        private int ThisPicWidth = 0;
        private int ThisPicHeight = 0;
        private Image ThisPic;
        private int CurrentZoomFactor;

        public ZoomManager(Image pic, int picwidth, int picheight) {
           ThisPic = pic;
           ThisPicWidth = picwidth;
           ThisPicHeight = picheight;
           CurrentZoomFactor = 1;
        }

        public void setZoomedImage(PictureBox reader, int delta, int X, int Y) {
            int pixelTranslationNum = NUM_OF_ZOOM_PIXELS * (CurrentZoomFactor + delta / 120);
            int newZoomWidth =  (int)(ThisPicWidth + 30 * pixelTranslationNum);
            int newZoomHeight = (int)(ThisPicHeight + 30 *pixelTranslationNum);

            if(reader.Image != null &&
                newZoomWidth >= ThisPicWidth &&
                newZoomHeight >= ThisPicHeight) {

                CurrentZoomFactor += delta / 120;

                Bitmap newMap = new Bitmap(newZoomWidth,
                                           newZoomHeight, 
                                           PixelFormat.Format24bppRgb);
                Graphics tempGraphics = Graphics.FromImage(newMap);

                tempGraphics.DrawImage(ThisPic,
                                       new Rectangle(new Point(0,0), 
                                                     new Size(newZoomWidth,newZoomHeight)),

                                       new Rectangle(new Point(pixelTranslationNum,
                                                               pixelTranslationNum), 
                                                     new Size(ThisPicWidth - 2*pixelTranslationNum ,
                                                              ThisPicHeight - 2*pixelTranslationNum)),
                                                              GraphicsUnit.Pixel);
                tempGraphics.Dispose();

                Image oldPic = reader.Image;
                if(oldPic != ThisPic) {
                    oldPic.Dispose();
                }
                reader.Image = newMap;
            }
        }

    }
}
