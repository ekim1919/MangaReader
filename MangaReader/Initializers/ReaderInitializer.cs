using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MangaReader.Database;

namespace MangaReader.Initializers
{

    /*
     *  In charge of running routuines for general initialization of the program (DB routines, etc) 
     * 
     * 
     */ 
    public class ReaderInitializer {

        public ReaderInitializer () {}

        public void PrepareDatabase() {
            //Database sanity checkign and/or initialization techniques.
            SessionDB database = new SessionDB();
        }
       
    }
}