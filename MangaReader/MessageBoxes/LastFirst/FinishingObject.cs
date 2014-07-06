using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MangaReader.Initializers;
using MangaReader.Managers;

namespace MangaReader.MessageBoxes.LastFirst {
    internal class FinishingObject: LastFirstObj {

        public FinishingObject() : base("You are passing the last page\n" +
                                                             " Do you wish to open a new folder?") {}

        public override bool YesAction() {
            SessionInitializer.newFileManager();
            return false;
        }

        public override bool NoAction() {
            return true;
        }
    }
}
