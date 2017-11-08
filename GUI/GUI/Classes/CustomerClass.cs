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
        /// </summary>
        public CustomerClass()
        {
            DB = new DataBaseClass();
        }


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
        {
            return this.IDcustomer + ", " + this.FIOcustomer + ", телефон: " + this.PhoneCustomer;
        }
    }
}
