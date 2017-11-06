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

namespace GUI
{
    public partial class Form1 : Form
    {
        AutomobileClass CarObject;
        OrderClass RequestObject;
        int index; // индекс выбранного элемента listbox

        public Form1()
        {
            InitializeComponent();
            CarObject = new AutomobileClass();
            RequestObject = new OrderClass();
            
            GetCar(CarObject);
            GetRequest(RequestObject);

            comboBox2ClassType.DataSource = CarObject.ClassCarList;

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
        private void button4AddDriver_Click(object sender, EventArgs e)
        {
            DriverClass AddDriver = new DriverClass();

            AddDriver.PhotoDriver = filename;
            AddDriver.FIOdriver = t;

            listBox2.Refresh();

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

        }
        //////////////////////////////////////////





        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            index= Int32.Parse(listBox1.SelectedIndex.ToString());
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
