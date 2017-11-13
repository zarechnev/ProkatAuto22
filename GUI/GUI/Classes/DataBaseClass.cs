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
        private bool Debug = true;
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
                                            CREATE TABLE cars (ID INTEGER PRIMARY KEY AUTOINCREMENT, model VARCHAR (100), priceForHour NUMERIC (5), typeID INTEGER REFERENCES carTypes (ID), photoFileName VARCHAR (100), carCapacity INTEGER (3), yearOfIssue INTEGER (4), gosNumber VARCHAR (9), carCapacityTrunc INTEGER (5), deleted BOOLEAN DEFAULT (0));
                                            CREATE TABLE carTypes (ID INTEGER PRIMARY KEY AUTOINCREMENT, type VARCHAR (100));
                                            INSERT INTO carTypes (ID, type) VALUES (1, 'B');
                                            INSERT INTO carTypes (ID, type) VALUES (2, 'C');
                                            INSERT INTO carTypes (ID, type) VALUES (3, 'D');
                                            CREATE TABLE client (ID INTEGER PRIMARY KEY AUTOINCREMENT, name VARCHAR (100), phoneNumber INTEGER (19), city VARCHAR (100), deleted BOOLEAN DEFAULT (0));
                                            CREATE TABLE driverHabits (ID INTEGER PRIMARY KEY AUTOINCREMENT, habit VARCHAR (100));
                                            INSERT INTO driverHabits (ID, habit) VALUES (1, 'Наркоман');
                                            INSERT INTO driverHabits (ID, habit) VALUES (2, 'Пьёт');
                                            INSERT INTO driverHabits (ID, habit) VALUES (3, 'Курит');
                                            CREATE TABLE driverHabitsBinding (driverID INTEGER REFERENCES drivers (ID), driverHabitsID INTEGER REFERENCES driverHabits (ID));
                                            CREATE TABLE drivers (ID INTEGER PRIMARY KEY AUTOINCREMENT, name VARCHAR (100), photoFileName VARCHAR (100), experienceFrom INTEGER (4), deleted BOOLEAN DEFAULT (0));
                                            CREATE TABLE orders (ID INTEGER PRIMARY KEY AUTOINCREMENT, data DATETIME, carID INTEGER REFERENCES cars (ID), driverID INTEGER REFERENCES drivers (ID), duration INTEGER (2), clientID INTEGER REFERENCES client (ID), address VARCHAR (100));
                                            COMMIT TRANSACTION;
                                            PRAGMA foreign_keys = on;
                                        ";

        /// <summary>
        /// Конструктор экземпляра класса.
        /// </summary>
        public DataBaseClass()
        {
            if (!System.IO.File.Exists(DBFileName))
            {
                // Файла БД нет - создаём его
                MyDBLogger("BD-file doesn't exist.");
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
            else
            {
                // Файла БД присутствует
                MyDBLogger("BD-file exist.");
            }
        }

        /// <summary>
        /// Локальный логгер. Вывод в стандартный вывод если (Debug == true).
        /// </summary>
        /// <param name="Message">Сообщение для вывода.</param>
        private void MyDBLogger(string Message)
        {
            if (Debug) System.Console.WriteLine(Message);
        }

        /// <summary>
        /// Считывает водителя из базы по ID.
        /// </summary>
        /// <param name="DriverID"></param>
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
                    MyDBLogger("Select Driver by ID: " + Command.CommandText);
                    using (SQLiteDataReader Reader = Command.ExecuteReader())
                    {
                        Reader.Read();
                        ReadedDriver.FIOdriver = Reader.GetString(0);
                        ReadedDriver.PhotoDriver = Reader.GetString(1);
                        ReadedDriver.ExpirienceDriver = Reader.GetValue(2).ToString();
                    }

                    // Считываем привычки водителя
                    Command.CommandText = @"SELECT driverHabitsID FROM driverHabitsBinding WHERE driverID = '" + ReadedDriver.DriverDBID + "';";
                    MyDBLogger("Select Driver habbits by Driver ID: " + Command.CommandText);
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
        /// <param name="NewDriverAdd"></param>
        public void AddNewDriverDB(DriverClass NewDriverAdd)
        {
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
                    MyDBLogger("Create driver with SQL-command: " + Command.CommandText);
                    Command.ExecuteNonQuery();

                    Command.CommandText = @"SELECT ID from drivers ORDER by ID DESC LIMIT 1;";
                    MyDBLogger("Get last driver with SQL-command: " + Command.CommandText);
                    using (SQLiteDataReader Reader = Command.ExecuteReader())
                    {
                        Reader.Read();
                        AddedDviverID = Reader.GetInt32(0);
                        MyDBLogger("Last record Driver ID is: " + AddedDviverID);
                    }

                    if (NewDriverAdd.DriverHabitSmoke)
                    {
                        Command.CommandText = @"INSERT INTO driverHabitsBinding (driverID, driverHabitsID) VALUES (" + AddedDviverID + "," + 3 + ");";
                        MyDBLogger("Driver habbits (smoke) SQL-command: " + Command.CommandText);
                        Command.ExecuteNonQuery();
                    }

                    if (NewDriverAdd.DriverHabitDrink)
                    {
                        Command.CommandText = @"INSERT INTO driverHabitsBinding (driverID, driverHabitsID) VALUES (" + AddedDviverID + "," + 2 + ");";
                        MyDBLogger("Driver habbits (smoke) SQL-command: " + Command.CommandText);
                        Command.ExecuteNonQuery();
                    }

                    if (NewDriverAdd.DriverHabitDrugs)
                    {
                        Command.CommandText = @"INSERT INTO driverHabitsBinding (driverID, driverHabitsID) VALUES (" + AddedDviverID + "," + 1 + ");";
                        MyDBLogger("Driver habbits (smoke) SQL-command: " + Command.CommandText);
                        Command.ExecuteNonQuery();
                    }
                }
            }
        }

        /// <summary>
        /// Редактирует водителя.
        /// </summary>
        /// <param name="DriverEdit"></param>
        public void EditDriverDB(DriverClass DriverEdit)
        {
            using (SQLiteConnection DBConnection = new SQLiteConnection("data source=" + DBFileName))
            {
                DBConnection.Open();
                using (SQLiteCommand Command = new SQLiteCommand(DBConnection))
                {
                    Command.CommandText = @"UPDATE drivers SET name = '" + DriverEdit.FIOdriver.ToUpper() + "', " +
                        "photoFileName ='" + DriverEdit.PhotoDriver + "', " +
                        "experienceFrom = '" + DriverEdit.ExpirienceDriver + "' " +
                        "WHERE ID = '" + DriverEdit.DriverDBID + "';";
                    MyDBLogger("Edit driver driver whis SQL-command: " + Command.CommandText);
                    Command.ExecuteNonQuery();

                    // Удаляем все упоминания о вредных привычках и заново их устанавливаем
                    Command.CommandText = @"DELETE FROM driverHabitsBinding WHERE driverID = '" + DriverEdit.DriverDBID + "';";
                    MyDBLogger("Delete all habits binding SQL-command: " + Command.CommandText);
                    Command.ExecuteNonQuery();

                    if (DriverEdit.DriverHabitSmoke)
                    {
                        Command.CommandText = @"INSERT INTO driverHabitsBinding (driverID, driverHabitsID) VALUES ('" + DriverEdit.DriverDBID + "','" + 3 + "');";
                        MyDBLogger("Driver habbits (smoke) SQL-command: " + Command.CommandText);
                        Command.ExecuteNonQuery();
                    }

                    if (DriverEdit.DriverHabitDrink)
                    {
                        Command.CommandText = @"INSERT INTO driverHabitsBinding (driverID, driverHabitsID) VALUES ('" + DriverEdit.DriverDBID + "','" + 2 + "');";
                        MyDBLogger("Driver habbits (smoke) SQL-command: " + Command.CommandText);
                        Command.ExecuteNonQuery();
                    }

                    if (DriverEdit.DriverHabitDrugs)
                    {
                        Command.CommandText = @"INSERT INTO driverHabitsBinding (driverID, driverHabitsID) VALUES ('" + DriverEdit.DriverDBID + "','" + 1 + "');";
                        MyDBLogger("Driver habbits (smoke) SQL-command: " + Command.CommandText);
                        Command.ExecuteNonQuery();
                    }
                }
            }
        }

        /// <summary>
        /// Возвращает список всех водителей.
        /// </summary>
        public List<DriverClass> ReadAllDriversDB()
        {
            List<DriverClass> ListOfDrivers = new List<DriverClass>();
            using (SQLiteConnection DBConnection = new SQLiteConnection("data source=" + DBFileName))
            {
                DBConnection.Open();
                using (SQLiteCommand Command = new SQLiteCommand(DBConnection))
                {
                    Command.CommandText = @"SELECT ID FROM drivers WHERE deleted != 1;";
                    MyDBLogger("Select Drivers ID: " + Command.CommandText);
                    using (SQLiteDataReader Reader = Command.ExecuteReader())
                    {
                        while (Reader.Read())
                        {
                            ListOfDrivers.Add(this.ReadDriverDB(Reader.GetInt32(0).ToString()));
                        }
                    }
                }
            }
            return (ListOfDrivers);
        }

        /// <summary>
        /// Помечает водителя как удалённого.
        /// </summary>
        /// <param name="DriverToDelete"></param>
        public void DeleteDriver(DriverClass DriverToDelete)
        {
            using (SQLiteConnection DBConnection = new SQLiteConnection("data source=" + DBFileName))
            {
                DBConnection.Open();
                using (SQLiteCommand Command = new SQLiteCommand(DBConnection))
                {
                    Command.CommandText = @"UPDATE drivers SET deleted = 1 WHERE ID = " + DriverToDelete.DriverDBID + ";";
                    MyDBLogger("Delete driver by ID: " + Command.CommandText);
                    Command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Помечает клиента как удалённого.
        /// </summary>
        /// <param name="CustomerToDelete"></param>
        public void DeleteCustomer(CustomerClass CustomerToDelete)
        {
            using (SQLiteConnection DBConnection = new SQLiteConnection("data source=" + DBFileName))
            {
                DBConnection.Open();
                using (SQLiteCommand Command = new SQLiteCommand(DBConnection))
                {
                    Command.CommandText = @"UPDATE client SET deleted = 1 WHERE ID = " + CustomerToDelete.IDcustomer + ";";
                    MyDBLogger("Delete customer by ID: " + Command.CommandText);
                    Command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Записывает в базу нового клиента.
        /// </summary>
        /// <param name="NewCostomer"></param>
        public void AddNewCustomerDB(CustomerClass NewCostomer)
        {
            using (SQLiteConnection DBConnection = new SQLiteConnection("data source=" + DBFileName))
            {
                DBConnection.Open();
                using (SQLiteCommand Command = new SQLiteCommand(DBConnection))
                {
                    Command.CommandText = @"INSERT INTO client (name, phoneNumber, city) VALUES ('" +
                         NewCostomer.FIOcustomer.ToUpper() + "','" +
                         NewCostomer.PhoneCustomer + "','" +
                         NewCostomer.CityCustomer.ToUpper() + "');";
                    MyDBLogger("Create client with SQL-command: " + Command.CommandText);
                    Command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Считывает из базы клиента. Автор: Марина.
        /// </summary>
        public CustomerClass ReadCustomerDB(string CustomerID)
        {
            CustomerClass ReadedCustomer = new CustomerClass();
            ReadedCustomer.IDcustomer = CustomerID;
            using (SQLiteConnection DBConnection = new SQLiteConnection("data source=" + DBFileName))
            {
                DBConnection.Open();
                using (SQLiteCommand Command = new SQLiteCommand(DBConnection))
                {
                    // Считываем информацию о водителе
                    Command.CommandText = @"SELECT name, phoneNumber, city FROM client WHERE ID = '" + ReadedCustomer.IDcustomer + "';";
                    MyDBLogger("Select Client by ID: " + Command.CommandText);
                    using (SQLiteDataReader Reader = Command.ExecuteReader())
                    {
                        Reader.Read();
                        ReadedCustomer.FIOcustomer = Reader.GetString(0);
                        ReadedCustomer.PhoneCustomer = Reader.GetValue(1).ToString();
                        ReadedCustomer.CityCustomer = Reader.GetString(2);
                    }
                }
            }
            return ReadedCustomer;
        }

        /// <summary>
        /// Редактирует в базе клиента. Автор: Марина.
        /// </summary>
        public void EditCustomerDB(CustomerClass EditCustomer)
        {
            using (SQLiteConnection DBConnection = new SQLiteConnection("data source=" + DBFileName))
            {
                DBConnection.Open();
                using (SQLiteCommand Command = new SQLiteCommand(DBConnection))
                {
                    Command.CommandText = @"UPDATE client SET name = '" + EditCustomer.FIOcustomer.ToUpper() + "', " +
                        "phoneNumber ='" + EditCustomer.PhoneCustomer + "', " +
                        "city = '" + EditCustomer.CityCustomer + "' " +
                        "WHERE ID = '" + EditCustomer.IDcustomer + "';";
                    MyDBLogger("Edit client whis SQL-command: " + Command.CommandText);
                    Command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Возвращает список клиентов. Автор: Марина.
        /// </summary>
        /// <returns></returns>
        public List<CustomerClass> ReadAllCustomersDB()
        {
            List<CustomerClass> ListOfCustomers = new List<CustomerClass>();
            using (SQLiteConnection DBConnection = new SQLiteConnection("data source=" + DBFileName))
            {
                DBConnection.Open();
                using (SQLiteCommand Command = new SQLiteCommand(DBConnection))
                {
                    Command.CommandText = @"SELECT ID FROM client WHERE deleted != 1;";
                    MyDBLogger("Select Client ID: " + Command.CommandText);
                    using (SQLiteDataReader Reader = Command.ExecuteReader())
                    {
                        while (Reader.Read())
                        {
                            ListOfCustomers.Add(this.ReadCustomerDB(Reader.GetValue(0).ToString()));
                        }
                    }
                }
            }
            return (ListOfCustomers);
        }

        /// <summary>
        /// Добавляет новый автомобиль. Не протестировано. Автор: Марина.
        /// </summary>
        /// <param name="NewCar"></param>
        public void AddNewCarDB(AutomobileClass NewCar)
        {
            using (SQLiteConnection DBConnection = new SQLiteConnection("data source=" + DBFileName))
            {
                DBConnection.Open();
                using (SQLiteCommand Command = new SQLiteCommand(DBConnection))
                {
                    Command.CommandText = @"INSERT INTO cars (model, priceForHour, photoFileName, carCapacity, yearOfIssue, gosNumber, carCapacityTrunc, typeID) VALUES ('" +
                        NewCar.ModelCar + "','" +
                        NewCar.PriceHourCar + "','" +
                        NewCar.PhotoCar + "','" +
                        NewCar.CapacityCar + "','" +
                        NewCar.YearIssueCar + "','" +
                        NewCar.GosNumberCar + "','" +
                        NewCar.CarryingCar + "'," +
                        NewCar.CarCategoryID + ");";
                    MyDBLogger("Create car with SQL-command: " + Command.CommandText);
                    Command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Возвращает экземпляр автомобиля по ID. Не протестировано. Автор: Марина.
        /// </summary>
        /// <param name="CarID"></param>
        /// <returns></returns>
        public AutomobileClass ReadCarDB(string CarID)
        {
            AutomobileClass ReadCarDB = new AutomobileClass();

            ReadCarDB.IDCar = CarID;

            using (SQLiteConnection DBConnection = new SQLiteConnection("data source=" + DBFileName))
            {
                DBConnection.Open();
                using (SQLiteCommand Command = new SQLiteCommand(DBConnection))
                {
                    // Считываем информацию о водителе
                    Command.CommandText = @"SELECT model, priceForHour, photoFileName, carCapacity, yearOfIssue, gosNumber, carCapacityTrunc FROM cars WHERE ID = '" + ReadCarDB.IDCar + "';";
                    MyDBLogger("Select Car by ID: " + Command.CommandText);
                    using (SQLiteDataReader Reader = Command.ExecuteReader())
                    {
                        Reader.Read();
                        ReadCarDB.ModelCar = Reader.GetString(0);
                        ReadCarDB.PriceHourCar = Reader.GetValue(1).ToString();
                        ReadCarDB.PhotoCar = Reader.GetString(2);
                        ReadCarDB.CapacityCar = Reader.GetValue(3).ToString();
                        ReadCarDB.YearIssueCar = Reader.GetValue(4).ToString();
                        ReadCarDB.GosNumberCar = Reader.GetValue(5).ToString();
                        ReadCarDB.CarryingCar = Reader.GetValue(6).ToString();
                    }
                }
            }
            return ReadCarDB;
        }

        /// <summary>
        /// Метод для редактирования автомобиля.
        /// </summary>
        /// <param name="CarToEdit"></param>
        public void EditCarDB(AutomobileClass CarToEdit)
        {

        }

        /// <summary>
        /// Возвращает список автомобилей. Не протестировано. Автор: Марина.
        /// </summary>
        /// <returns></returns>
        public List<AutomobileClass> ReadAllCars()
        {
            List<AutomobileClass> AllCars = new List<AutomobileClass>();
            using (SQLiteConnection DBConnection = new SQLiteConnection("data source=" + DBFileName))
            {
                DBConnection.Open();
                using (SQLiteCommand Command = new SQLiteCommand(DBConnection))
                {
                    Command.CommandText = @"SELECT ID FROM cars WHERE deleted != 1;";
                    MyDBLogger("Select Cars ID: " + Command.CommandText);
                    using (SQLiteDataReader Reader = Command.ExecuteReader())
                    {
                        while (Reader.Read())
                        {
                            AllCars.Add(this.ReadCarDB(Reader.GetInt32(0).ToString()));
                        }
                    }
                }
            }
            return AllCars;
        }

        /// <summary>
        /// Помечает автомобиль как удалённый.
        /// </summary>
        /// <param name="CarToDelete"></param>
        public void DeleteCar(AutomobileClass CarToDelete)
        {
            using (SQLiteConnection DBConnection = new SQLiteConnection("data source=" + DBFileName))
            {
                DBConnection.Open();
                using (SQLiteCommand Command = new SQLiteCommand(DBConnection))
                {
                    Command.CommandText = @"UPDATE cars SET deleted = 1 WHERE ID = " + CarToDelete.IDCar + ";";
                    MyDBLogger("Delete car by ID: " + Command.CommandText);
                    Command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Добавляет новый заказ.
        /// </summary>
        /// <param name="NewOrder"></param>
        public void AddNewOrderDB(OrderClass NewOrder)
        {

        }

        /// <summary>
        /// Возвращает экземпляр заказа по ID.
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public OrderClass ReadOrderDB(string OrderID)
        {
            OrderClass ReadOrder= new OrderClass();

            return ReadOrder;
        }

        /// <summary>
        /// Метод для редактирования заказов.
        /// </summary>
        /// <param name="OrderToEdit"></param>
        public void EditOrderDB(OrderClass OrderToEdit)
        {

        }

        /// <summary>
        /// Метод для удаления заказов.
        /// </summary>
        /// <param name="OrderToEdit"></param>
        public void DeleteOrderDB(OrderClass OrderToDelete)
        {

        }

        /// <summary>
        /// Возвращает список заказов.
        /// </summary>
        /// <returns></returns>
        public List<OrderClass> ReadAllOrdersDB()
        {
            List<OrderClass> AllOrders = new List<OrderClass>();

            return AllOrders;
        }
    }
}
 