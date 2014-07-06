using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MangaReader.MessageBoxes.LastFirst {
   abstract class LastFirstObj {
        protected String Message;
        
        public LastFirstObj(String message) {
            Message = message;
        }
        
        public String getMessage() {
            return Message;
        }

        public abstract bool YesAction();
        public abstract bool NoAction();
    }
}
