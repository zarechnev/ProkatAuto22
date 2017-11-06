using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProkatAuto22.Classes
{
    class DriverClass
    {
        public List<string> PhotoDriverList { get;  set; }
        public List<string>  FIOdriverList { get;  set; }
        public List<string> ExpirienceDriverList { get;  set; }
        public List<bool> DriverHabitSmokeList { get; set; }
        public List<bool> DriverHabitDrinkList { get; set; }
        public List<bool> DriverHabitDrugsList { get; set; }
        
        public string DriverDBID { get; set; }
        public string PhotoDriver { get; set; }
        public string FIOdriver { get; set; }
        public string ExpirienceDriver { get; set; }
        public bool DriverHabitSmoke { get; set; }
        public bool DriverHabitDrink { get; set; }
        public bool DriverHabitDrugs { get; set; }

        private DataBaseClass DB;

        public DriverClass()
        {

        }

        public void InsertDriver()
        {
            DB.AddNewDriverDB(this);
        }

        public void ReadDriver()
        {
            //DB.ReadDriversDB(this);
        }

        public void DeleteDriver()
        {
            DB.DeleteDriverDB(this);
        }

        public void EditDriver()
        {
            DB.EditDriverDB(this);
        }
    }
}
