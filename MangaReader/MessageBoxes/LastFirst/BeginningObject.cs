using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MangaReader.MessageBoxes.LastFirst {
    internal class BeginningObject: LastFirstObj {
        public BeginningObject() : base("You are attempting to go to the last page.\n" + 
                                        "Do you want to desire?") { }

        public override bool YesAction() {
            return true;
        }

        public override bool NoAction() {
            return false;
        }
    }
}
