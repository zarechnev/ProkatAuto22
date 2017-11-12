using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProkatAuto22.Classes
{
    class OrderClass
    {
        public string IDRequest { get; set; }
        public string DataRequest { get; set; }
        public AutomobileClass CarRequest { get; set; }
        public DriverClass DriverRequest { get; set; }
        public CustomerClass CustomerRequest { get; set; }
        public string AddressRequest { get; set; }
        public string TimeRequest { get; set; }          // формат даты, не протестировано.
        public string PriceRequest { get; set; }
        public bool KidsChair { get; set; }
        public bool WinterTires { get; set; }
        public bool SportFastenings { get; set; }
        public bool Gps { get; set; }

        private DataBaseClass DB;

        /// <summary>
        /// Метод класса. Возвращает список (классов) заявок.
        /// </summary>
        /// <returns></returns>
        public static List<OrderClass> ReadAllOrders()
        {
            DataBaseClass DB = new DataBaseClass();
            return DB.ReadAllOrdersDB();
        }

        /// <summary>
        /// Конструктор экземпляра класса.
        /// </summary>
        public OrderClass()
        {
            DB = new DataBaseClass();
        }

        /// <summary>
        /// Добавление заявки.
        /// </summary>
        public void InsertOrder()
        {
            DB.AddNewOrderDB(this);
        }

        /// <summary>
        /// Редактирование заявки.
        /// </summary>
        public void EditOrder()
        {
            DB.EditOrderDB(this);
        }

        /// <summary>
        /// Удаление заявки.
        /// </summary>
        public void DeleteOrder()
        {
            DB.DeleteOrderDB(this);
        }

        /// <summary>
        /// Выводит информацию о экземпляре заявки в читаемом виде.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.IDRequest + ", " + this.CarRequest + ", клиент: " + this.CustomerRequest;
        }
    }
}
