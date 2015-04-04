using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SQLite;

namespace MangaReader.Database {
    /*
     * Mode  
     */
    class SessionDBConnCreator {

        private String pathnameToDB = Environment.GetEnvironmentVariable("AppData") + "\\MangaReader";

        private SQLiteConnection createSessionDB() {

            try{ Directory.CreateDirectory(pathnameToDB); } catch(IOException a) {}

            SQLiteConnection.CreateFile(pathnameToDB + "\\Session.db");
            SQLiteConnection dbConnection = new SQLiteConnection("Data Source=Session.db;Version=3");
            dbConnection.Open();


            String createTableStmt = "CREATE TABLE Sessions (Pathname VARCHAR(260), StoppedPos INT, Mode INT)"; //Not sure if 260 characters is enough
            SQLiteCommand createTableComm = new SQLiteCommand(createTableStmt, dbConnection);
            createTableComm.ExecuteNonQuery();

            return dbConnection; //We close the dbConnection at the EndRoutines
        }

         public SQLiteConnection getSessionDBConn() {
             return File.Exists(pathnameToDB + "\\Session.db") ? new SQLiteConnection("Data Source=Session.db;Version=3") :
                                               createSessionDB();
        }
    }
}
