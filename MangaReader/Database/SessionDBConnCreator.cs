using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SQLite;

namespace MangaReader.Database {
    class SessionDBConnCreator {

        private String pathnameToDB = Environment.GetEnvironmentVariable("AppData") + "\\" + "Session.db";

        private SQLiteConnection createSessionDB() {

            SQLiteConnection.CreateFile(pathnameToDB);
            SQLiteConnection dbConnection = new SQLiteConnection("Data Source=Session.db;Version=3");
            dbConnection.Open();

            String createTableStmt = "CREATE TABLE Sessions (Pathname VARCHAR(260), StoppedPos INT, Mode INT)"; //Not sure if 260 characters is enough
            SQLiteCommand createTableComm = new SQLiteCommand(createTableStmt, dbConnection);
            createTableComm.ExecuteNonQuery();

            dbConnection.Close();
            return dbConnection;
        }

         public SQLiteConnection getSessionDBConn() {
            return File.Exists(pathnameToDB) ? new SQLiteConnection("Data Source=Session.db;Version=3") :
                                               createSessionDB();
        }
    }
}
