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
        /// Конструктор экземпляра класса.
        /// </summary>
        /// <returns></returns>
        public AutomobileClass()
        {
            DB = new DataBaseClass();
        }

        /// <summary>
        /// Свойство, которое возвращает-устанавливает тип ТС по индексу.
        /// </summary>
        public int CarCategoryID
        {
            get
            {
                if (this.TypeCar == "B") return 1;
                if (this.TypeCar == "C") return 2;
                if (this.TypeCar == "D") return 3;
                return -1;
            }
            set
            {
                if (value == 1) this.TypeCar = "B";
                if (value == 2) this.TypeCar = "C";
                if (value == 3) this.TypeCar = "D";
            }
        }

        /// <summary>
        /// Добавление автомобиля.
        /// </summary>
        public void InsertCar()
        {
            DB.AddNewCarDB(this);
        }

        /// <summary>
        /// Метод класса. Возвращает список (экземпляров) автомобилей.
        /// </summary>
        /// <returns></returns>
        public static List<AutomobileClass> ReadAllCars()
        {
            DataBaseClass DB = new DataBaseClass();
            return DB.ReadAllCars();
        }

        /// <summary>
        /// Редактирование автомобиля.
        /// </summary>
        public void EditCar()
        {
            DB.EditCarDB(this);
        }

        /// <summary>
        /// Удаление автомобиля.
        /// </summary>
        public void DeleteCar()
        {
            DB.DeleteCar(this);
        }

        /// <summary>
        /// Выводит информацию о экземпляре в читаемом виде.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.IDCar + ", " + this.ModelCar + " (" + this.YearIssueCar + " г.в.). Час аренды: " +  this.PriceHourCar + " р.";
        }
    }
}
