using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProkatAuto22.Classes
{
    class DriverClass
    {
        public string DriverDBID { get; set; }
        public string PhotoDriver { get; set; }
        public string FIOdriver { get; set; }
        public string ExpirienceDriver { get; set; }
        public bool DriverHabitSmoke { get; set; }
        public bool DriverHabitDrink { get; set; }
        public bool DriverHabitDrugs { get; set; }

        private DataBaseClass DB;

        /// <summary>
        /// Метод класса. Возвращает список (классов) водителей.
        /// </summary>
        /// <returns></returns>
        public static List<DriverClass> ReadAllDrivers()
        {
            DataBaseClass DB = new DataBaseClass();
            return DB.ReadAllDriversDB();
        }

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        public DriverClass()
        {
            DB = new DataBaseClass();
        }

        /// <summary>
        /// Добавление водителя.
        /// </summary>
        public void InsertDriver()
        {
            DB.AddNewDriverDB(this);
        }

        /// <summary>
        /// Редактирование водителя.
        /// </summary>
        public void EditDriver()
        {
            DB.EditDriverDB(this);
        }

        /// <summary>
        /// Выводит информацию о экземпляре в читаемом виде.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.DriverDBID + ", " + this.FIOdriver + ", стаж с: " + this.ExpirienceDriver + " г.";
        }
    }
}
