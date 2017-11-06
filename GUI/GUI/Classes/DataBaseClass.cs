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
        private string CreateBDCommand = @"
                                            PRAGMA foreign_keys = off;
                                            BEGIN TRANSACTION;
                                            CREATE TABLE additionalServices (ID INTEGER PRIMARY KEY AUTOINCREMENT, service VARCHAR (100));
                                            INSERT INTO additionalServices (ID, service) VALUES (2, 'Зимние шины');
                                            INSERT INTO additionalServices (ID, service) VALUES (3, 'Спортивные крепления');
                                            INSERT INTO additionalServices (ID, service) VALUES (4, 'Детские кресла');
                                            INSERT INTO additionalServices (ID, service) VALUES (5, 'GPS-навигатор');
                                            CREATE TABLE additionalServicesBinding (orderID INTEGER REFERENCES orders (ID), additionalServicesID INTEGER REFERENCES additionalServices (ID));
                                            CREATE TABLE cars (ID INTEGER PRIMARY KEY AUTOINCREMENT, model VARCHAR (100), priceForHour NUMERIC (5), typeID INTEGER REFERENCES carTypes (ID), photoFileName VARCHAR (100), carCapacity INTEGER (3), yearOfIssue INTEGER (4), maxSpeed INTEGER (3), carCapacityTrunc INTEGER (5));
                                            CREATE TABLE carTypes (ID INTEGER PRIMARY KEY AUTOINCREMENT, type VARCHAR (100));
                                            INSERT INTO carTypes (ID, type) VALUES (1, 'D');
                                            INSERT INTO carTypes (ID, type) VALUES (2, 'C');
                                            INSERT INTO carTypes (ID, type) VALUES (3, 'B');
                                            CREATE TABLE client (ID INTEGER PRIMARY KEY AUTOINCREMENT, name VARCHAR (100), phoneNumber INTEGER (19), city VARCHAR (100));
                                            CREATE TABLE driverHabits (ID INTEGER PRIMARY KEY AUTOINCREMENT, habit VARCHAR (100));
                                            INSERT INTO driverHabits (ID, habit) VALUES (1, 'Наркоман');
                                            INSERT INTO driverHabits (ID, habit) VALUES (2, 'Пьёт');
                                            INSERT INTO driverHabits (ID, habit) VALUES (3, 'Курит');
                                            CREATE TABLE driverHabitsBinding (driverID INTEGER REFERENCES drivers (ID), driverHabitsID INTEGER REFERENCES driverHabits (ID));
                                            CREATE TABLE drivers (ID INTEGER PRIMARY KEY AUTOINCREMENT, name VARCHAR (100), photoFileName VARCHAR (100), experienceFrom INTEGER (4));
                                            CREATE TABLE orders (ID INTEGER PRIMARY KEY AUTOINCREMENT, data DATETIME, carID INTEGER REFERENCES cars (ID), driverID INTEGER REFERENCES drivers (ID), duration INTEGER (2), clientID INTEGER REFERENCES client (ID), address VARCHAR (100));
                                            COMMIT TRANSACTION;
                                            PRAGMA foreign_keys = on;
                                        ";

        public DataBaseClass()
        {
            if (!System.IO.File.Exists(DBFileName)){
                // Файла БД нет - создаём его
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
            else{
                // Файла БД присутствует
                Console.WriteLine("BD-file exist.");
            }
        }

        public void AddNewDriverDB(DriverClass NewDriverAdd) {
            
        }

        public void EditDriverDB(DriverClass NewDriverEdit)
        {

        }

        public void ReadDriversDB(DriverClass NewDriverRead)
        {

        }


        public void DeleteDriverDB(DriverClass NewDriverDelete)
        {

        }




    }
}
