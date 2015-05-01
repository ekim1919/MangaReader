using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MangaReader.Structs;

namespace MangaReader.Database.Tests
{
    class DbTests {
        /*
         * A simple testing suite for DB queries and table creations. 
         */

        //Simulated Database entry after EndRoutune.

        public DbTests() {}

        public List<DBStruct> testSaveFeature() {
            SessionDB db = new SessionDB();
            db.saveSessionintoDB("C:\\",0,0);
            return db.getSavedSessions();
        }

        public void printResults() {
            foreach( DBStruct a in testSaveFeature())  {
                Console.Write(a.Pathname + "\n" + a.SavedPos + "\n" + a.Mode + "\n");
            }
        }
    }
}
