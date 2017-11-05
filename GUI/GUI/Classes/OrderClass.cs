using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProkatAuto22.Classes
{
    class OrderClass
    {
        public List<string> NumberRequestList { get; private set; }
        public List<string> ModelCarList { get; private set; }
        public List<string> DriverCarList { get; private set; }
        public List<string> DurationLeaseList { get; private set; }
        public List<string> PriceLeaseList { get; private set; }
        public List<string> CustomerIDList { get; private set; }
        public List<string> KidsChairList { get; private set; }
        public List<string> WinterTiresList { get; private set; }
        public List<string> SportFasteningsList { get; private set; }
        public List<string> GpsList { get; private set; }



        public string NumberRequest { get; set; }      
        public string DriverCar { get; set; }
        public string DurationLease { get; set; }
        public string PriceLease { get; set; }
        public string KidsChair { get; set; }
        public string WinterTires { get; set; }
        public string SportFastenings { get; set; }
        public string Gps { get; set; }


        public void InsertRequest(string NumberRequest, string ModelCar, string DriverCar, string DurationLease, string PriceLease, string CustomerID, string KidsChair, string WinterTires, string SportFastenings, string GpsList)
        {

        }

        public void ReadRequest()
        {/*
            NumberRequestList
            ModelCarList
             .........
         */
        }


        public void DeleteRequest(string NumberRequest, string ModelCar, string DriverCar, string DurationLease, string PriceLease, string CustomerID, string KidsChair, string WinterTires, string SportFastenings, string GpsList)
        {

        }

    }
}
