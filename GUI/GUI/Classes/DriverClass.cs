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
        public bool DriverHabitSmoke { get; set; } = false;
        public bool DriverHabitDrink { get; set; } = false;
        public bool DriverHabitDrugs { get; set; } = false;

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

        public DriverClass()
        {
            DB = new DataBaseClass();
        }

        public void InsertDriver()
        {
            DB.AddNewDriverDB(this);
        }

        public void EditDriver()
        {
            DB.EditDriverDB(this);
        }

        public override string ToString()
        {
            return this.DriverDBID + ", " + this.FIOdriver + ", стаж с: " + this.ExpirienceDriver + " г.";
        }
    }
}
