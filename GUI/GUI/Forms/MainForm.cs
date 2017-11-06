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
        DataBaseClass DataBase;
        DriverClass DriverObjectRead;
        CustomerClass CustomerObjectRead;
        AutomobileClass CarObject;
        OrderClass RequestObject;
        int index; // индекс выбранного элемента listbox

        string fileNameDriver;

        bool habitSmoke, habitDrink, habitDrugs;

        public Form1()
        {
            InitializeComponent();
            DriverObjectRead = new DriverClass();
            CustomerObjectRead = new CustomerClass();

            DriverObjectRead.ReadDriver();
            GetDrivers();

            CustomerObjectRead.ReadCustomer();
            GetCustomers();

         //   CarObject = new AutomobileClass();
         //   RequestObject = new OrderClass();

            //   GetCar(CarObject);
            //  GetRequest(RequestObject);

            //  comboBox2ClassType.DataSource = CarObject.ClassCarList;

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd.MM.yyyy; hh:mm";
        }

        ///////////////////////////////////////// Авто

        private void button1AddAuto_Click(object sender, EventArgs e)
        {
            
        }

        private void button3RedactionAuto_Click(object sender, EventArgs e)
        {

        }

        //вывод данных на форму
        private void GetCar(AutomobileClass CarObject)
        {
            CarObject.ReadCar();

            /*
            for (int i = 0; i < CarObject.ModelCarList.Count; i++)
                listBox1.Items.Add(CarObject.ModelCarList[i]);
                */
        }

        private void button2DeleteCar_Click(object sender, EventArgs e)
        {
            CarObject.DeleteCar(CarObject.ModelCarList[index], CarObject.ClassCarList[index], CarObject.TypeCarList[index], CarObject.PriceHourList[index], CarObject.PhotoCarList[index], CarObject.DriverCarList[index], CarObject.YearIssueList[index], CarObject.MaxSpeedList[index], CarObject.CapacityCarList[index], CarObject.CapacityTrunkList[index]);
        }

        private void comboBox2ClassType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarObject.GetCarClass(comboBox2ClassType.SelectedText);
        }

        private void comboBox1CarType_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        ////////////////////////////////// Водители

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
 
        private void button4AddDriver_Click(object sender, EventArgs e)
        {
            DriverClass AddDriver = new DriverClass();

            AddDriver.DriverDBID = textBox2IdDriver.Text;
            AddDriver.PhotoDriver = fileNameDriver;
            AddDriver.FIOdriver = textBox2FioDriver.Text;
            AddDriver.ExpirienceDriver = textBox3ExpirienceDriver.Text;
            AddDriver.DriverHabitSmoke = habitSmoke;
            AddDriver.DriverHabitDrink = habitDrink;
            AddDriver.DriverHabitDrugs = habitDrugs;

            AddDriver.InsertDriver();

            listBox2Driver.Refresh();
        }

        private void button6RedactionDriver_Click(object sender, EventArgs e)
        {
            DriverClass RedactionDriver = new DriverClass();
           // string idDriver;
           /*
            RedactionDriver.DriverDBID = DriverObjectRead.DriverDBIDList(Int32.Parse(listBox2Driver.SelectedIndex.ToString()));
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

        private void button5DeleteDriver_Click(object sender, EventArgs e)
        {
            DriverClass DeleteDriver = new DriverClass();
            /*
            DeleteDriver.DriverDBID = DriverObjectRead.DriverDBIDList(Int32.Parse(listBox2Driver.SelectedIndex.ToString()));
            DeleteDriver.DeleteDriver();

            listBox2Driver.Refresh();
            */
        }

        private void GetDrivers()
        {
        //    for (int i = 0; i < DriverObjectRead.FIOdriverList.Count; i++)
          //      listBox2Driver.Items.Add(DriverObjectRead.FIOdriverList[i]);
        }

        private void checkBox6Smoke_Click(object sender, EventArgs e)
        {
            if (checkBox6Smoke.Checked)
                habitSmoke = true;
            else
                habitSmoke = false;
        }

        private void checkBox7Drink_Click(object sender, EventArgs e)
        {
            if (checkBox7Drink.Checked)
                habitDrink = true;
            else
                habitDrink = false;
        }

        private void checkBox5Drugs_Click(object sender, EventArgs e)
        {
            if (checkBox5Drugs.Checked)
                habitDrugs = true;
            else
                habitDrugs = false;
        }

        //////////////////////////// Заявки
        private void button9AddRequest_Click(object sender, EventArgs e)
        {

        }

        private void button7RedactionRequest_Click(object sender, EventArgs e)
        {

        }

        private void GetRequest (OrderClass RequestObject)
        {
            RequestObject.ReadRequest();

            /*
            textBox7RequestCar.Text = RequestObject.ModelCarList[index];
            */

        }

        private void button8DeleteRequest_Click(object sender, EventArgs e)
        {
            RequestObject.DeleteRequest(RequestObject.NumberRequestList[index], RequestObject.ModelCarList[index], RequestObject.DriverCarList[index], RequestObject.DurationLeaseList[index], RequestObject.PriceLeaseList[index], RequestObject.CustomerIDList[index], RequestObject.KidsChairList[index], RequestObject.WinterTiresList[index], RequestObject.SportFasteningsList[index], RequestObject.GpsList[index]);
        }

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
            /*
            RedactionCustomer.IDcustomer = CustomerObjectRead.IDcustomerList(Int32.Parse(listBox3Customers.SelectedIndex.ToString()));
            RedactionCustomer.FIOcustomer = textBox12FioCustomer.Text;
            RedactionCustomer.PhoneCustomer = textBox11PhoneCustomer.Text;
            RedactionCustomer.CityCustomer = textBox10CityCustomer.Text;

            RedactionCustomer.EditCustomer();

            listBox3Customers.Refresh();
            */
        }

        private void button11DeleteCustomer_Click(object sender, EventArgs e)
        {
            CustomerClass DeleteCustomer = new CustomerClass();

            /*
            DeleteCustomer.IDcustomer = CustomerObjectRead.IDcustomerList(Int32.Parse(listBox3Customers.SelectedIndex.ToString()));
            DeleteCustomer.DeleteCustomer();

            listBox3Customers.Refresh();
            */
        }

        private void GetCustomers()
        {
            //for (int i = 0; i < CustomerObjectRead.FIOcustomerList.Count; i++)
              //  listBox3Customers.Items.Add(CustomerObjectRead.FIOcustomerList[i]);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            index= Int32.Parse(listBox1Automobile.SelectedIndex.ToString());
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

    }
}
