using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProkatAuto22;
using ProkatAuto22.Classes;
using System.IO;

namespace GUI
{
    public partial class Form1 : Form
    {
        DriverClass DriverObjectRead;
        CustomerClass CustomerObjectRead;

        string fileNameDriver;

        public Form1()
        {
            InitializeComponent();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd.MM.yyyy; hh:mm";

            List<DriverClass> AllDrivers = new List<DriverClass>();
            AllDrivers = DriverClass.ReadAllDrivers();
            AllDrivers.ForEach(delegate (DriverClass Driver)
            {
                listBox2Driver.Items.Add(Driver);
            });
        }

        /// Водители
        private void button4AddDriver_Click(object sender, EventArgs e)
        {
            DriverClass AddDriver = new DriverClass();

            AddDriver.PhotoDriver = fileNameDriver;
            AddDriver.FIOdriver = textBox2FioDriver.Text;
            AddDriver.ExpirienceDriver = textBox3ExpirienceDriver.Text;
            AddDriver.DriverHabitSmoke = checkBox6Smoke.Checked;
            AddDriver.DriverHabitDrink = checkBox7Drink.Checked;
            AddDriver.DriverHabitDrugs = checkBox5Drugs.Checked;

            AddDriver.InsertDriver();
        }

        private void button1EditPhotoDriver_Click(object sender, EventArgs e)
        {
            OpenFileDialog AddPhotoDriver = new OpenFileDialog();
            
            AddPhotoDriver.Filter = ("(*.jpg)|*.jpg|(*.png)|*.png|All files (*.*)|*.*");
             if (AddPhotoDriver.ShowDialog() == DialogResult.OK)
              {
                fileNameDriver = AddPhotoDriver.SafeFileName;
                string sourcePath = AddPhotoDriver.FileName;
                string targetPath = @"DriverPhoto";
                
                string destFile = Path.Combine(targetPath, fileNameDriver);
                
                File.Copy(sourcePath, destFile, true);
              }
        }
 
        private void button6RedactionDriver_Click(object sender, EventArgs e)
        {
            DriverClass RedactionDriver = new DriverClass();
            // string idDriver;
            /*
            RedactionDriver= DataBase.ReadDriverDB(Int32.Parse(DriverObjectRead.AllDriversList[listBox2Driver.SelectedIndex].DriverDBID));
            RedactionDriver.PhotoDriver = fileNameDriver;
            RedactionDriver.FIOdriver = textBox2FioDriver.Text;
            RedactionDriver.ExpirienceDriver = textBox3ExpirienceDriver.Text;
            RedactionDriver.DriverHabitSmoke = habitSmoke;
            RedactionDriver.DriverHabitDrink = habitDrink;
            RedactionDriver.DriverHabitDrugs = habitDrugs;

            RedactionDriver.EditDriver();

            listBox2Driver.Refresh();
            */
        }

        /*
        ////////////////////////////////// Клиенты
        private void button12AddCustomer_Click(object sender, EventArgs e)
        {
            CustomerClass AddCustomer = new CustomerClass();

            AddCustomer.FIOcustomer = textBox12FioCustomer.Text;
            AddCustomer.PhoneCustomer = textBox11PhoneCustomer.Text;
            AddCustomer.CityCustomer = textBox10CityCustomer.Text;

            AddCustomer.InsertCustomer();

            listBox3Customers.Refresh();

        }

        private void button10RedactionCustomer_Click(object sender, EventArgs e)
        {
            CustomerClass RedactionCustomer = new CustomerClass();
            // string idDriver;
            RedactionCustomer = DataBase.ReadCustomerDB(Int32.Parse(CustomerObjectRead.AllCustomerList[listBox3Customers.SelectedIndex].IDcustomer));
            RedactionCustomer.FIOcustomer = textBox12FioCustomer.Text;
            RedactionCustomer.PhoneCustomer = textBox11PhoneCustomer.Text;
            RedactionCustomer.CityCustomer = textBox10CityCustomer.Text;

            RedactionCustomer.EditCustomer();

            listBox3Customers.Refresh();
        }

        private void GetCustomers()
        {
         //   for (int i = 0; i < CustomerObjectRead.AllCustomerList.Count; i++)
          //      listBox3Customers.Items.Add(CustomerObjectRead.AllCustomerList[i].FIOcustomer);
        }
        */
    }
}
