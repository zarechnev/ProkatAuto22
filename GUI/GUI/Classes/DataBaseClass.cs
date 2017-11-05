using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;


namespace ProkatAuto22.Classes
{
    class DataBaseClass
    {
        private string DBFileName = @"DBFile.sqlite3";
        private string CreateBDCommand = @"";

        public DataBaseClass()
        {
            if (!System.IO.File.Exists(DBFileName)){
                Console.WriteLine("BD-file doesn't exist.");
                SQLiteConnection.CreateFile(DBFileName);
                using (SQLiteConnection DBConnection = new SQLiteConnection("data source=" + DBFileName))
                {
                    using (SQLiteCommand CreateCommand = new SQLiteCommand(DBConnection))
                    {
                        DBConnection.Open();
                        CreateCommand.CommandText = CreateBDCommand;
                        CreateCommand.ExecuteNonQuery();
                    }
                }
            }
            else { Console.WriteLine("BD-file exist."); }
        }

        // Ниже необходимо указать перечень необходимых методов!!!



    }
}
