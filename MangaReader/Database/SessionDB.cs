using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

using MangaReader.Structs;

namespace MangaReader.Database {
    public class SessionDB {


        /*
         * I must catch some potential exceptions here. going to work on that soon
         */
        private SQLiteConnection sessionDB;

        public SessionDB() {
            sessionDB = (new SessionDBConnCreator()).getSessionDBConn();
            sessionDB.Open();
        }

        public void saveSessionintoDB(String pathname, int savedpos, int mode) {
            String insertstmt = "INSERT INTO Sessions (Pathname, StoppedPos, Mode) VALUES (" + buildValuesString(pathname, savedpos, mode) + ")";

            using (SQLiteCommand comm = new SQLiteCommand(insertstmt, sessionDB)) {
                comm.ExecuteNonQuery();
            }
        }

        public List<DBStruct> getSavedSessions() {
            SQLiteDataReader reader = (new SQLiteCommand("SELECT  * FROM Sessions", sessionDB)).ExecuteReader();
            List<DBStruct> dbList = new List<DBStruct>();
            while(reader.Read()) {
                dbList.Add(new DBStruct((String)reader["Pathname"],
                                        (int)reader["StoppedPos"],
                                        (int)reader["Mode"]));
            }
            return dbList;
        }

        private String buildValuesString(String pathname, int savedpos, int mode) {
            return "'" + pathname + "'," +
                   "'" + savedpos + "'," +
                   "'" + mode + "'";
        }

        public void deleteSession(String sessionName) {
            String deleteStmt = "DELETE From Sessions WHERE Pathname=\"" + sessionName + "\"";

            using (SQLiteCommand comm = new SQLiteCommand(deleteStmt, sessionDB)) {
                comm.ExecuteNonQuery();
            }
        }

        ~SessionDB() {
            sessionDB.Close();
        }
    }
}
