using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProkatAuto22.Classes
{
    class CustomerClass
    {
        public List<string> IDcustomerList { get; set; }
        public List<string> FIOcustomerList { get; set; }
        public List<string> PhoneCustomerList { get; set; }
        public List<bool> CityCustomerList { get; set; }

        public List<CustomerClass> AllCustomerList { get; set; }

        public string IDcustomer { get; set; }
        public string FIOcustomer { get; set; }
        public string PhoneCustomer { get; set; }
        public string CityCustomer { get; set; }

        private DataBaseClass DB;

        public CustomerClass()
        {
            DB = new DataBaseClass();
        }

        public void InsertCustomer()
        {
            DB.AddNewCustomerDB(this);
        }

        public void ReadAllCustomers()
        {
            AllCustomerList = new List<CustomerClass>(DB.ReadAllCustomersDB());
        }


        public void EditCustomer()
        {
            DB.EditCustomerDB(this);
        }
    }
}
