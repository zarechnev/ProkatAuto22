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
        public List<bool>  DriverHabit1List { get; set; }
        public List<bool> DriverHabit2List { get; set; }
        public List<bool> DriverHabit3List { get; set; }





        public string PhotoDriver { get; set; }
        public string FIOdriver { get; set; }
        public string ExpirienceDriver { get; set; }
        public bool DriverHabit1 { get; set; }
        public bool DriverHabit2 { get; set; }
        public bool DriverHabit3 { get; set; }




        public void InsertDriver(string PhotoDriver, string FIOdriver, string ExpirienceDriver, bool DriverHabit1, bool DriverHabit2, bool DriverHabit3)
        {

        }

        public void ReadDriver()
        {/*
            NumberRequestList
            ModelCarList
             .........
         */
        }


        public void DeleteRequest(string PhotoDriver, string FIOdriver, string ExpirienceDriver, bool DriverHabit1, bool DriverHabit2, bool DriverHabit3)
        {

        }
    }
}
