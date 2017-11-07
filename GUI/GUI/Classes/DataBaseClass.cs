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
                                            CREATE TABLE cars (ID INTEGER PRIMARY KEY AUTOINCREMENT, model VARCHAR (100), priceForHour NUMERIC (5), typeID INTEGER REFERENCES carTypes (ID), photoFileName VARCHAR (100), carCapacity INTEGER (3), yearOfIssue INTEGER (4), gosNumber VARCHAR (9), carCapacityTrunc INTEGER (5));
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
                    DBConnection.Open();
                    using (SQLiteCommand CreateCommand = new SQLiteCommand(DBConnection))
                    {
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

        /// <summary>
        /// Не протестирован!!!
        /// Считывает водителя из базы по ID.
        /// </summary>
        public DriverClass ReadDriverDB(string DriverID)
        {
            DriverClass ReadedDriver = new DriverClass();
            ReadedDriver.DriverDBID = DriverID;

            using (SQLiteConnection DBConnection = new SQLiteConnection("data source=" + DBFileName))
            {
                DBConnection.Open();
                using (SQLiteCommand Command = new SQLiteCommand(DBConnection))
                {
                    // Считываем информацию о водителе
                    Command.CommandText = @"SELECT name, photoFileName, experienceFrom FROM drivers WHERE ID = '" + ReadedDriver.DriverDBID + "';";
                    Console.WriteLine("Select Driver by ID: " + Command.CommandText);
                    using (SQLiteDataReader Reader = Command.ExecuteReader())
                    {
                        Reader.Read();
                        ReadedDriver.FIOdriver = Reader.GetString(0);
                        ReadedDriver.PhotoDriver = Reader.GetString(1);
                        ReadedDriver.ExpirienceDriver = Reader.GetString(2);
                    }

                    // Считываем привычки водителя
                    Command.CommandText = @"SELECT driverHabitsID FROM driverHabitsBinding WHERE driverID = '" + ReadedDriver.DriverDBID + "';";
                    Console.WriteLine("Select Driver habbits by Driver ID: " + Command.CommandText);
                    using (SQLiteDataReader Reader = Command.ExecuteReader())
                    {
                        while (Reader.Read())
                        {
                            if (Reader.GetInt32(0) == 1) { ReadedDriver.DriverHabitDrugs = true; }
                            if (Reader.GetInt32(0) == 2) { ReadedDriver.DriverHabitDrink = true; }
                            if (Reader.GetInt32(0) == 3) { ReadedDriver.DriverHabitSmoke = true; }
                        }
                    }
                }
            }

            return ReadedDriver;
        }

        /// <summary>
        /// Записывает в базу нового водителя.
        /// </summary>
        public void AddNewDriverDB(DriverClass NewDriverAdd) {
            using (SQLiteConnection DBConnection = new SQLiteConnection("data source=" + DBFileName))
            {
                DBConnection.Open();
                using (SQLiteCommand Command = new SQLiteCommand(DBConnection))
                {
                    int AddedDviverID;
                    Command.CommandText = @"INSERT INTO drivers (name, photoFileName, experienceFrom) VALUES ('" +
                         NewDriverAdd.FIOdriver.ToUpper() + "','" +
                         NewDriverAdd.PhotoDriver + "','" +
                         NewDriverAdd.ExpirienceDriver + "');";
                    Console.WriteLine("Create driver whis SQL-command: " + Command.CommandText);
                    Command.ExecuteNonQuery();

                    Command.CommandText = @"SELECT ID from drivers ORDER by ID DESC LIMIT 1;";
                    using (SQLiteDataReader Reader = Command.ExecuteReader())
                    {
                        Reader.Read();
                        AddedDviverID = Reader.GetInt32(0);
                        Console.WriteLine("Last record Driver ID is: " + AddedDviverID);
                    }

                    if (NewDriverAdd.DriverHabitSmoke)
                    {
                        Command.CommandText = @"INSERT INTO driverHabitsBinding (driverID, driverHabitsID) VALUES (" + AddedDviverID + "," + 3 + ");";
                        Console.WriteLine("Driver habbits (smoke) SQL-command: " + Command.CommandText);
                        Command.ExecuteNonQuery();
                    }

                    if (NewDriverAdd.DriverHabitDrink)
                    {
                        Command.CommandText = @"INSERT INTO driverHabitsBinding (driverID, driverHabitsID) VALUES (" + AddedDviverID + "," + 2 + ");";
                        Console.WriteLine("Driver habbits (smoke) SQL-command: " + Command.CommandText);
                        Command.ExecuteNonQuery();
                    }

                    if (NewDriverAdd.DriverHabitDrugs)
                    {
                        Command.CommandText = @"INSERT INTO driverHabitsBinding (driverID, driverHabitsID) VALUES (" + AddedDviverID + "," + 1 + ");";
                        Console.WriteLine("Driver habbits (smoke) SQL-command: " + Command.CommandText);
                        Command.ExecuteNonQuery();
                    }
                }
            }
        }

        /// <summary>
        /// Не протестирован!!!
        /// Редактирует водителя.
        /// </summary>
        public void EditDriverDB(DriverClass DriverEdit){
            using (SQLiteConnection DBConnection = new SQLiteConnection("data source=" + DBFileName))
            {
                DBConnection.Open();
                using (SQLiteCommand Command = new SQLiteCommand(DBConnection))
                {
                    Command.CommandText = @"UPDATE drivers SET name = '" + DriverEdit.FIOdriver.ToUpper() +
                        "', photoFileName ='" + DriverEdit.PhotoDriver +
                        "', experienceFrom = '" + DriverEdit.ExpirienceDriver +
                        "' WHERE ID = '" + DriverEdit.DriverDBID +
                        ";";
                    Console.WriteLine("Edit driver driver whis SQL-command: " + Command.CommandText);
                    Command.ExecuteNonQuery();

                    // Удаляем все упоминания о вредных привычках и заново их устанавливаем
                    Command.CommandText = @"DELETE FROM drivers WHERE driverID = '" + DriverEdit.DriverDBID + ";";
                    Console.WriteLine("Delete all habits binding SQL-command: " + Command.CommandText);
                    Command.ExecuteNonQuery();

                    if (DriverEdit.DriverHabitSmoke)
                    {
                        Command.CommandText = @"INSERT INTO driverHabitsBinding (driverID, driverHabitsID) VALUES (" + DriverEdit + "," + 3 + ");";
                        Console.WriteLine("Driver habbits (smoke) SQL-command: " + Command.CommandText);
                        Command.ExecuteNonQuery();
                    }

                    if (DriverEdit.DriverHabitDrink)
                    {
                        Command.CommandText = @"INSERT INTO driverHabitsBinding (driverID, driverHabitsID) VALUES (" + DriverEdit + "," + 2 + ");";
                        Console.WriteLine("Driver habbits (smoke) SQL-command: " + Command.CommandText);
                        Command.ExecuteNonQuery();
                    }

                    if (DriverEdit.DriverHabitDrugs)
                    {
                        Command.CommandText = @"INSERT INTO driverHabitsBinding (driverID, driverHabitsID) VALUES (" + DriverEdit + "," + 1 + ");";
                        Console.WriteLine("Driver habbits (smoke) SQL-command: " + Command.CommandText);
                        Command.ExecuteNonQuery();
                    }
                }
            }
        }

        /// <summary>
        /// Не протестирован!!!
        /// Возвращает список всех водителей.
        /// </summary>
        public List<DriverClass> ReadAllDriversDB()
        {
            List<DriverClass> ListOfDrivers = new List<DriverClass>();

            return (ListOfDrivers);
        }

        public void AddNewCustomerDB(CustomerClass NewCostomer)
        {

        }

        public void ReadCustomerDB(CustomerClass ReadCustomer)
        {

        }
    }
}
