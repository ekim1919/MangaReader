using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

using MangaReader.Structs;

namespace MangaReader.Database {
    public class SessionDB {

        private SQLiteConnection sessionDB;

        public SessionDB() {
            sessionDB = (new SessionDBConnCreator()).getSessionDBConn();
            sessionDB.Open();
        }

        public void saveSessionintoDB(String pathname, int savedpos, int mode) {
            String insertstmt = "INSERT INTO Sessions (Pathname, StoppedPos, Mode) VALUES (" + buildValuesString(pathname, savedpos, mode) + ")";
            (new SQLiteCommand(insertstmt, sessionDB)).ExecuteNonQuery();
        }

        public List<DBStruct> getSavedSessions() {
            SQLiteDataReader reader = (new SQLiteCommand("SELECT  * FROM Sessions")).ExecuteReader();
            List<DBStruct> dbList = new List<DBStruct>();
            while(reader.Read()) {
                dbList.Add(new DBStruct((String)reader["Pathname"],
                                        (int)reader["StoppedPos"],
                                        (int)reader["Mode"]));
            }
            return dbList;
        }

        private String buildValuesString(String pathname, int savedpos, int mode) {
            return " ' " + pathname + " ' " +
                   " ' " + savedpos + " ' " +
                   " ' " + mode + " ' ";
        }
    }
}
