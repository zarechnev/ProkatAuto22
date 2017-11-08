using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProkatAuto22.Classes
{
    class CustomerClass
    {
        public string IDcustomer { get; set; }
        public string FIOcustomer { get; set; }
        public string PhoneCustomer { get; set; }
        public string CityCustomer { get; set; }

        private DataBaseClass DB;

        /// <summary>
        /// Конструктор класса CustomerClass.
        /// </summary>
        public CustomerClass()
        {
            DB = new DataBaseClass();
        }

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
        {
            DB.EditCustomerDB(this);
        }
    }
}
