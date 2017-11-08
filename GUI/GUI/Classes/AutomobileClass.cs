using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProkatAuto22.Classes
{
    class AutomobileClass
    {
        public string IDCar { get; set; }
        public string PhotoCar { get; set; }
        public string ModelCar { get; set; }
        public string PriceHourCar { get; set; }
        public string TypeCar { get; set; }
        public string CapacityCar { get; set; }
        public string YearIssueCar { get; set; }
        public string GosNumberCar { get; set; }
        public string CarryingCar { get; set; }

        private DataBaseClass DB;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        public AutomobileClass()
        {
            DB = new DataBaseClass();
        }

        /// <summary>
        /// Метод класса. Возвращает список (классов) автомобилей.
        /// </summary>
        /// <returns></returns>
        public static List<AutomobileClass> ReadAllCars()
        {
            DataBaseClass DB = new DataBaseClass();
            return DB.ReadAllCarsDB();
        }

        /// <summary>
        /// Добавление автомобиля.
        /// </summary>
        public void InsertCar()
        {
            DB.AddNewCarDB(this);
        }

        /// <summary>
        /// Редактирование автомобиля.
        /// </summary>
        public void EditCar()
        {
            DB.EditCarDB(this);
        }

        /// <summary>
        /// Выводит информацию о экземпляре в читаемом виде.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.IDCar + ", " + this.ModelCar + ", " + this.PriceHourCar + " р., ";
        }


        

        
    }
}
