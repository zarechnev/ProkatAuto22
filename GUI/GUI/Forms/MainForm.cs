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
        string destFile;
        string sourcePath;
        public Form1()
        {
            InitializeComponent();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd.MM.yyyy; hh:mm";

            UpdateDriversListbox();
        }

        /// <summary>
        /// Обновляет содержимое лист-бокса для списка водителей.
        /// </summary>
        private void UpdateDriversListbox()
        {
            listBox2Driver.Items.Clear();

            List<DriverClass> AllDrivers = new List<DriverClass>();
            AllDrivers = DriverClass.ReadAllDrivers();
            AllDrivers.ForEach(delegate (DriverClass Driver)
            {
                listBox2Driver.Items.Add(Driver);
            });
        }

        /// <summary>
        /// Добавление водителя.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4AddDriver_Click(object sender, EventArgs e)
        {
            DriverClass AddDriver = new DriverClass();

            AddDriver.PhotoDriver = destFile;
            AddDriver.FIOdriver = textBox2FioDriver.Text;
            AddDriver.ExpirienceDriver = textBox3ExpirienceDriver.Text;
            AddDriver.DriverHabitSmoke = checkBox6Smoke.Checked;
            AddDriver.DriverHabitDrink = checkBox7Drink.Checked;
            AddDriver.DriverHabitDrugs = checkBox5Drugs.Checked;

            File.Copy(sourcePath, destFile, true);
            AddDriver.InsertDriver();

            UpdateDriversListbox();
        }

        private void button1EditPhotoDriver_Click(object sender, EventArgs e)
        {
            /// TODO копирование файла должно происходить при нажатии кнопки "добавить водителя" или "редактироть водителя" - Доделано
            OpenFileDialog AddPhotoDriver = new OpenFileDialog();
            
            AddPhotoDriver.Filter = ("(*.jpg)|*.jpg|(*.png)|*.png|All files (*.*)|*.*");
             if (AddPhotoDriver.ShowDialog() == DialogResult.OK)
              {
                string fileNameDriver = AddPhotoDriver.SafeFileName;
                sourcePath = AddPhotoDriver.FileName;
                string targetPath = @"DriverPhoto";
                
                destFile = Path.Combine(targetPath, fileNameDriver);
                
               
              }
        }

        /// <summary>
        /// Сохранение водителя (редактирование).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6RedactionDriver_Click(object sender, EventArgs e)
        {
            DriverClass RedactionDriver = new DriverClass();

            RedactionDriver.DriverDBID = textBox2IdDriver.Text;
            RedactionDriver.PhotoDriver = destFile;
            RedactionDriver.FIOdriver = textBox2FioDriver.Text;
            RedactionDriver.ExpirienceDriver = textBox3ExpirienceDriver.Text;
            RedactionDriver.DriverHabitSmoke = checkBox6Smoke.Checked;
            RedactionDriver.DriverHabitDrink = checkBox7Drink.Checked;
            RedactionDriver.DriverHabitDrugs = checkBox5Drugs.Checked;

            File.Copy(sourcePath, destFile, true);
            RedactionDriver.EditDriver();


            UpdateDriversListbox();
        }

        /// <summary>
        /// Метод срабатывает при клике на водителе из списка.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox2Driver_SelectedIndexChanged(object sender, EventArgs e)
        {
            DriverClass CheckedDriver = new DriverClass();
            CheckedDriver = (DriverClass)listBox2Driver.SelectedItem;
            textBox2IdDriver.Text = CheckedDriver.DriverDBID.ToString();
            textBox2FioDriver.Text = CheckedDriver.FIOdriver.ToString();
            textBox3ExpirienceDriver.Text = CheckedDriver.ExpirienceDriver.ToString();
            checkBox7Drink.Checked = false;
            checkBox6Smoke.Checked = false;
            checkBox5Drugs.Checked = false;
            if (CheckedDriver.DriverHabitDrink) checkBox7Drink.Checked = true;
            if (CheckedDriver.DriverHabitSmoke) checkBox6Smoke.Checked = true;
            if (CheckedDriver.DriverHabitDrugs) checkBox5Drugs.Checked = true;


            if (CheckedDriver.PhotoDriver == "")
            {
                pictureBox2.Image = null;
                pictureBox2.BackColor = Color.Gray;
            }
            else
                pictureBox2.Load(CheckedDriver.PhotoDriver);

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
