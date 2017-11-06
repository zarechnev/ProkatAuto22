using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProkatAuto22.Classes
{
    class AutomobileClass
    {
        // для вывода информ. по каждой машине
        public List<string> ModelCarList { get; private set; } 
        public List<string> YearIssueList { get; private set; }
        public List<string> MaxSpeedList { get; private set; }
        public List<string> CapacityCarList { get; private set; }
        public List<string> CapacityTrunkList { get; private set; }
        public List<string> ClassCarList { get; private set; }
        public List<string> TypeCarList { get; private set; }
        public List<string> PriceHourList { get; private set; }
        public List<string> PhotoCarList { get; private set; }
        public List<string> DriverCarList { get; private set; }


        public string ModelCar { get; set; }
        public string ClassCar { get; set; }
        public string TypeCar { get; set; }
        public string PriceHour { get; set; }
        public string PhotoCar { get; set; }
        public string DriverCar { get; set; }
        public string YearIssue{ get; set; }
        public string MaxSpeed { get; set; }
        public string CapacityCar { get; set; }
        public string CapacityTrunk { get; set; }
        


        public void InsertCar(string ModelCar, string ClassCar, string TypeCar, string PriceHour, string PhotoCar, string DriverCar, string YearIssue, string MaxSpeed, string CapacityCar, string CapacityTrunk)
        {

        }

        public void ReadCar()
        {/*
            ModelCarList...
            YearIssueList...
             MaxSpeedList....
             CapacityCarList..
             CapacityTrunkList..
             .........
          */
        }

        public void DeleteCar(string ModelCar, string ClassCar, string TypeCar, string PriceHour, string PhotoCar, string DriverCar, string YearIssue, string MaxSpeed, string CapacityCar, string CapacityTrunk)
        {

        }


        public void GetCarType(string CarType)
        {

        }

        public void GetCarClass(string CarClass)
        {

        }
    }
}
