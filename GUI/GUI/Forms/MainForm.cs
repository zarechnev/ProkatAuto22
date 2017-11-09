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
        string destFile = "";
        string sourcePath;

        bool FlagCopy = false;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            Directory.CreateDirectory(@"DriverPhoto");

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd.MM.yyyy; hh:mm";

            UpdateDriversListbox();
            UpdateCarsListbox();
        }


        ////////////////////////////////// Водители

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

            if (FlagCopy)
            {
                File.Copy(sourcePath, destFile, true);
                destFile = "";
            }
            AddDriver.InsertDriver();

            UpdateDriversListbox();
            FlagCopy = false;

            /// Очищаем форму добавления водителей
            textBox2IdDriver.Text = "";
            textBox2FioDriver.Text = "";
            textBox3ExpirienceDriver.Text = "";
            checkBox6Smoke.Checked = false;
            checkBox5Drugs.Checked = false;
            checkBox7Drink.Checked = false;
        }

        /// <summary>
        /// Смена фотографии водителя(запускает диалог для выбора фото и сохраняет итоговый путь destFile).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1EditPhotoDriver_Click(object sender, EventArgs e)
        {
            OpenFileDialog AddPhotoDriver = new OpenFileDialog();

            AddPhotoDriver.Filter = ("(*.jpg)|*.jpg|(*.png)|*.png|All files (*.*)|*.*");
            if (AddPhotoDriver.ShowDialog() == DialogResult.OK)
            {
                string fileNameDriver = AddPhotoDriver.SafeFileName;
                sourcePath = AddPhotoDriver.FileName;
                string targetPath = @"DriverPhoto";

                destFile = Path.Combine(targetPath, fileNameDriver);

                pictureBox2.Load(sourcePath);

                FlagCopy = true;
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

            RedactionDriver = (DriverClass)listBox2Driver.SelectedItem;
            RedactionDriver.DriverDBID = textBox2IdDriver.Text;
            RedactionDriver.FIOdriver = textBox2FioDriver.Text;
            RedactionDriver.ExpirienceDriver = textBox3ExpirienceDriver.Text;
            RedactionDriver.DriverHabitSmoke = checkBox6Smoke.Checked;
            RedactionDriver.DriverHabitDrink = checkBox7Drink.Checked;
            RedactionDriver.DriverHabitDrugs = checkBox5Drugs.Checked;

            if (destFile != "")
            { RedactionDriver.PhotoDriver = destFile; }

            if (FlagCopy)
            {
                File.Copy(sourcePath, destFile, true);
                destFile = "";
            }
            RedactionDriver.EditDriver();


            UpdateDriversListbox();
            FlagCopy = false;
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

            /// Выбераем водителя для оформления заказа
            listBox1DriverForOrder.Items.Clear();
            listBox1DriverForOrder.Items.Add(CheckedDriver);
        }


        ////////////////////////////////// Клиенты

        /// <summary>
        /// Обновляет содержимое лист-бокса для списка клиентов.
        /// </summary>
        private void UpdateCustomersListbox()
        {
            listBox3Customers.Items.Clear();

            List<CustomerClass> AllCustomers = new List<CustomerClass>();
            AllCustomers = CustomerClass.ReadAllCustomers();
            AllCustomers.ForEach(delegate (CustomerClass Customer)
            {
                listBox3Customers.Items.Add(Customer);
            });
        }

        /// <summary>
        /// Сохранение клиента (редактирование).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button10RedactionCustomer_Click(object sender, EventArgs e)
        {
            CustomerClass RedactionCustomer = new CustomerClass();

            RedactionCustomer.IDcustomer = textBox2IdCustomer.Text;
            RedactionCustomer.FIOcustomer = textBox12FioCustomer.Text;
            RedactionCustomer.PhoneCustomer = textBox11PhoneCustomer.Text;
            RedactionCustomer.CityCustomer = textBox10CityCustomer.Text;

            RedactionCustomer.EditCustomer();

            UpdateCustomersListbox();
        }

        /// <summary>
        /// Метод срабатывает при клике на клиента из списка.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox3Customers_SelectedIndexChanged(object sender, EventArgs e)
        {
            CustomerClass CheckedCustomer = new CustomerClass();
            CheckedCustomer = (CustomerClass)listBox3Customers.SelectedItem;
            textBox2IdCustomer.Text = CheckedCustomer.IDcustomer.ToString();
            textBox12FioCustomer.Text = CheckedCustomer.FIOcustomer.ToString();
            textBox11PhoneCustomer.Text = CheckedCustomer.PhoneCustomer.ToString();
            textBox10CityCustomer.Text = CheckedCustomer.CityCustomer.ToString();

            /// Выбираем клиента для оформления заказа
            listBox2CustomerForOrder.Items.Clear();
            listBox2CustomerForOrder.Items.Add(CheckedCustomer);
        }

        /// <summary>
        /// Метод добавляет клиента в базу.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button12AddCustomer_Click_1(object sender, EventArgs e)
        {
            CustomerClass AddCustomer = new CustomerClass();

            AddCustomer.FIOcustomer = textBox12FioCustomer.Text;
            AddCustomer.PhoneCustomer = textBox11PhoneCustomer.Text;
            AddCustomer.CityCustomer = textBox10CityCustomer.Text;

            AddCustomer.InsertCustomer();

            UpdateCustomersListbox();

            /// Очищаем форму добавления клиентов
            textBox12FioCustomer.Text = "";
            textBox11PhoneCustomer.Text = "";
            textBox10CityCustomer.Text = "";
            
        }

        //////////////////////////////////////// Автомобили
        /// <summary>
        /// Обновляет содержимое лист-бокса для списка автомобилей. Не протестировано
        /// </summary>
        private void UpdateCarsListbox()
        {
            listBox1Automobile.Items.Clear();

            List<AutomobileClass> AllCars = new List<AutomobileClass>();
            AllCars = AutomobileClass.ReadAllCars();
            AllCars.ForEach(delegate (AutomobileClass Car)
            {
                listBox3Customers.Items.Add(Car);
            });
        }

        /// <summary>
        /// Добавление автомобиля. Не протестировано
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1AddAuto_Click(object sender, EventArgs e)
        {
            AutomobileClass AddCar = new AutomobileClass();

            AddCar.PhotoCar = destFile;
            AddCar.ModelCar = textBox1ModelCar.Text;
            AddCar.PriceHourCar = textBox4PriceForHourCar.Text;
            AddCar.TypeCar = comboBox2CarType.Text;                    //Combo-box надо подумать.
            AddCar.CapacityCar = textBox9CapacityCar.Text;
            AddCar.YearIssueCar = textBox7YearIssueCar.Text;
            AddCar.GosNumberCar = AutoGosNumberTextBox.Text;
            AddCar.CarryingCar = textBox14CarryingCar.Text;

            if (FlagCopy)
            {
                File.Copy(sourcePath, destFile, true);
                destFile = "";
            }
            AddCar.InsertCar();

            UpdateCarsListbox();
            FlagCopy = false;

            // Очищаем форму добавления автомобилей
            textBox1ModelCar.Text = "";
            textBox4PriceForHourCar.Text = "";
            comboBox2CarType.Text = "";                  //Combo-box надо подумать.
            textBox9CapacityCar.Text = "";
            textBox7YearIssueCar.Text = "";
            AutoGosNumberTextBox.Text = "";
            textBox14CarryingCar.Text = "";
        }

        /// <summary>
        /// Смена фотографии автомобиля(запускает диалог для выбора фото и сохраняет итоговый путь destFile). Не протестировано.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2ChangePhotoCar_Click(object sender, EventArgs e)
        {
            OpenFileDialog AddPhotoCar = new OpenFileDialog();

            AddPhotoCar.Filter = ("(*.jpg)|*.jpg|(*.png)|*.png|All files (*.*)|*.*");
            if (AddPhotoCar.ShowDialog() == DialogResult.OK)
            {
                string fileNameCar = AddPhotoCar.SafeFileName;
                sourcePath = AddPhotoCar.FileName;
                string targetPath = @"DriverPhoto";

                destFile = Path.Combine(targetPath, fileNameCar);

                pictureBox2.Load(sourcePath);

                FlagCopy = true;
            }
        }

        /// <summary>
        /// Сохранение автомобиля (редактирование).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3RedactionAuto_Click(object sender, EventArgs e)
        {
            AutomobileClass RedactionCar = new AutomobileClass();

            RedactionCar = (AutomobileClass)listBox1Automobile.SelectedItem;
            RedactionCar.IDCar = textBox2IdDriver.Text;
            RedactionCar.ModelCar = textBox1ModelCar.Text;
            RedactionCar.PriceHourCar = textBox4PriceForHourCar.Text;
            RedactionCar.TypeCar = comboBox2CarType.Text;                    //Combo-box надо подумать.
            RedactionCar.CapacityCar = textBox9CapacityCar.Text;
            RedactionCar.YearIssueCar = textBox7YearIssueCar.Text;
            RedactionCar.GosNumberCar = AutoGosNumberTextBox.Text;
            RedactionCar.CarryingCar = textBox14CarryingCar.Text;

            if (destFile != "")
            { RedactionCar.PhotoCar = destFile; }

            if (FlagCopy)
            {
                File.Copy(sourcePath, destFile, true);
                destFile = "";
            }
            RedactionCar.EditCar();


            UpdateCarsListbox();
            FlagCopy = false;
        }

        /// <summary>
        /// Метод срабатывает при клике на автомобиль из списка.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1Automobile_SelectedIndexChanged(object sender, EventArgs e)
        {
            AutomobileClass CheckedCar = new AutomobileClass();
            CheckedCar = (AutomobileClass)listBox1Automobile.SelectedItem;
            textBox3IDCar.Text = CheckedCar.IDCar.ToString();
            textBox1ModelCar.Text = CheckedCar.ModelCar.ToString();
            textBox4PriceForHourCar.Text = CheckedCar.PriceHourCar.ToString();
            comboBox2CarType.Text = CheckedCar.TypeCar.ToString();                    //Combo-box надо подумать.
            textBox9CapacityCar.Text = CheckedCar.CapacityCar.ToString();
            textBox7YearIssueCar.Text = CheckedCar.YearIssueCar.ToString();
            AutoGosNumberTextBox.Text = CheckedCar.GosNumberCar.ToString();
            textBox14CarryingCar.Text = CheckedCar.CarryingCar.ToString();

            if (CheckedCar.PhotoCar == "")
            {
                pictureBox2.Image = null;
                pictureBox2.BackColor = Color.Gray;
            }
            else
                pictureBox2.Load(CheckedCar.PhotoCar);

            /// Выбираем автомрбиль для оформления заказа
            listBox1CarForOrder.Items.Clear();
            listBox1CarForOrder.Items.Add(CheckedCar);
        }

    }
}