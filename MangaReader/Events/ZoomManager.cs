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
        private const int NUM_OF_ZOOM_PIXELS = 10;
                
        private int ThisPicWidth = 0;
        private int ThisPicHeight = 0;
        private Image ThisPic;

        public ZoomManager(Image pic, int picwidth, int picheight) {
           ThisPic = pic;
           ThisPicWidth = picwidth;
           ThisPicHeight = picheight;
        }

        public void setZoomedImage(PictureBox reader, ref int zoomFactor, int delta) {
            if(reader.Image != null) {
                zoomFactor += delta / 120;

                Bitmap newMap = new Bitmap(ThisPicWidth, ThisPicHeight, PixelFormat.Format24bppRgb);
                Graphics tempGraphics = Graphics.FromImage(newMap);

                int pixelTranslationNum = NUM_OF_ZOOM_PIXELS*zoomFactor;
                tempGraphics.DrawImage(ThisPic,
                                       new Rectangle(0, 0, ThisPicWidth, ThisPicHeight),
                                       new Rectangle(pixelTranslationNum,
                                                     pixelTranslationNum,
                                                     ThisPicWidth - pixelTranslationNum,
                                                     ThisPicHeight - pixelTranslationNum),
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
