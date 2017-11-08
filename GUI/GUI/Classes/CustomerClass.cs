using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProkatAuto22.Classes
{
    class CustomerClass
    {
<<<<<<< HEAD
=======

>>>>>>> remotes/procat22/master
        public string IDcustomer { get; set; }
        public string FIOcustomer { get; set; }
        public string PhoneCustomer { get; set; }
        public string CityCustomer { get; set; }

        private DataBaseClass DB;

<<<<<<< HEAD
        /// <summary>
        /// Конструктор класса CustomerClass.
=======

        /// <summary>
        /// Метод класса. Возвращает список (классов) клиентов.
        /// </summary>
        /// <returns></returns>
        public static List<CustomerClass> ReadAllCustomers()
        {
            DataBaseClass DB = new DataBaseClass();
            return DB.ReadAllCustomersDB();
        }


        /// <summary>
        /// Конструктор класса.
>>>>>>> remotes/procat22/master
        /// </summary>
        public CustomerClass()
        {
            DB = new DataBaseClass();
        }

<<<<<<< HEAD
        /// <summary>
        /// Метод класса выводит список всех клиентов.
        /// </summary>
        /// <returns></returns>
        public static List<CustomerClass> ReadAllCustomers()
        {
            DataBaseClass DB = new DataBaseClass();
            return DB.ReadAllCustomersDB();
        }

        public void InsertCustomer()
        {
            DB.AddNewCustomerDB(this);
        }

        public void EditCustomer()
=======

        /// <summary>
        /// Добавление клиента.
        /// </summary>
        public void InsertCustomer()
        {
            DB.AddNewCustomerDB(this);
        }


        /// <summary>
        /// Редактирование клиента.
        /// </summary>
        public void EditCustomer()
        {
            DB.EditCustomerDB(this);
        }


        /// <summary>
        /// Выводит информацию о экземпляре в читаемом виде.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
>>>>>>> remotes/procat22/master
        {
            return this.IDcustomer + ", " + this.FIOcustomer + ", телефон: " + this.PhoneCustomer;
        }
    }
}
