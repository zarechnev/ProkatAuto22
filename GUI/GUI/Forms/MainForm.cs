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
            Directory.CreateDirectory(@"AutomobilePhoto");

            ComboboxRealization();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd.MM.yyyy; hh:mm";

            UpdateDriversListbox();
            UpdateCarsListbox();
            UpdateCustomersListbox();
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
        /// Очищаем форму добавления водителей.
        /// </summary>
        private void ClearDriverPanel()
        {
            textBox2FioDriver.Text = "";
            textBox3ExpirienceDriver.Text = "";
            checkBox6Smoke.Checked = false;
            checkBox5Drugs.Checked = false;
            checkBox7Drink.Checked = false;
            pictureBox2.Image = null;
            pictureBox2.BackColor = Color.Gray;
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

            ClearDriverPanel();
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
                string fileNameDriver = AddPhotoDriver.SafeFileName.GetHashCode().ToString();
                sourcePath = AddPhotoDriver.FileName;
                string targetPath = @"DriverPhoto";

                destFile = Path.Combine(targetPath, fileNameDriver);

                pictureBox2.Load(sourcePath);

                FlagCopy = true;
            }
        }

        /// <summary>
        /// Удаление водителя.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1DelDriver_Click(object sender, EventArgs e)
        {
            DriverClass DriverToDelete = new DriverClass();
            DriverToDelete = (DriverClass)listBox2Driver.SelectedItem;
            DriverToDelete.DeleteDriver();
            UpdateDriversListbox();

            ClearDriverPanel();
            listBox1DriverForOrder.Items.Clear();
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
            ClearDriverPanel();
        }

        /// <summary>
        /// Метод срабатывает при клике на водителе из списка.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox2Driver_SelectedIndexChanged(object sender, EventArgs e)
        {
            // проверка на пустой индекс
            if (listBox2Driver.SelectedItem == null)
            { return; }

            DriverClass CheckedDriver = new DriverClass();
            CheckedDriver = (DriverClass)listBox2Driver.SelectedItem;
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
        /// Редактирование клиента.
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
            // проверка на пустой индекс
            if (listBox3Customers.SelectedItem == null)
            { return; }

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
            textBox2IdCustomer.Text = "";            
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
                listBox1Automobile.Items.Add(Car);
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
            //AddCar.TypeCar = comboBox2CarType.SelectedItem.ToString();                    //Combo-box надо подумать.
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
            comboBox2CarType.SelectedIndex = -1;                  
            textBox9CapacityCar.Text = "";
            textBox7YearIssueCar.Text = "";
            AutoGosNumberTextBox.Text = "";
            textBox14CarryingCar.Text = "";
            pictureBox1.Image = null;
            pictureBox1.BackColor = Color.Gray;
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
                string fileNameCar = AddPhotoCar.SafeFileName.GetHashCode().ToString();
                sourcePath = AddPhotoCar.FileName;
                string targetPath = @"AutomobilePhoto";

                destFile = Path.Combine(targetPath, fileNameCar);

                pictureBox1.Load(sourcePath);

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
            RedactionCar.ModelCar = textBox1ModelCar.Text;
            RedactionCar.PriceHourCar = textBox4PriceForHourCar.Text;
      //    RedactionCar.TypeCar = comboBox2CarType.Text;                    // Пока не работает, в базу не добавляется категория.
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
            // проверка на пустой индекс
            if (listBox1Automobile.SelectedItem == null)
            { return; }

            AutomobileClass CheckedCar = new AutomobileClass();
            CheckedCar = (AutomobileClass)listBox1Automobile.SelectedItem;
            textBox3IDCar.Text = CheckedCar.IDCar.ToString();
            textBox1ModelCar.Text = CheckedCar.ModelCar.ToString();
            textBox4PriceForHourCar.Text = CheckedCar.PriceHourCar.ToString();
/*
            if(CheckedCar.TypeCar.ToString() == "B")    // Пока не работает, в базу не добавляется категория.
            { comboBox2CarType.SelectedIndex = 0;}
            if (CheckedCar.TypeCar.ToString() == "C")
            { comboBox2CarType.SelectedIndex = 1; }
            if (CheckedCar.TypeCar.ToString() == "D")
            { comboBox2CarType.SelectedIndex = 2; }

             comboBox2CarType.Text = CheckedCar.TypeCar.ToString();                   
       */   textBox9CapacityCar.Text = CheckedCar.CapacityCar.ToString();
            textBox7YearIssueCar.Text = CheckedCar.YearIssueCar.ToString();
            AutoGosNumberTextBox.Text = CheckedCar.GosNumberCar.ToString();
            textBox14CarryingCar.Text = CheckedCar.CarryingCar.ToString();

            if (CheckedCar.PhotoCar == "")
            {
                pictureBox1.Image = null;
                pictureBox1.BackColor = Color.Gray;
            }
            else
                pictureBox1.Load(CheckedCar.PhotoCar);

            /// Выбираем автомрбиль для оформления заказа
            listBox1CarForOrder.Items.Clear();
            listBox1CarForOrder.Items.Add(CheckedCar);
        }

        /// <summary>
        /// Метод управляет работой комбо-бокса.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboboxRealization()
        {
            comboBox2CarType.Items.Add("B");
            comboBox2CarType.Items.Add("C");
            comboBox2CarType.Items.Add("D");
        }

        /// <summary>
        /// Метод срабатывает при клике на класс авто из combobox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox2CarType_SelectedIndexChanged(object sender, EventArgs e)
        {

            /*       switch(comboBox2CarType.SelectedIndex)
                    {
                        case 0:
                            UpdateAutomobileCategoryB();
                            break;
                        case 1:
                            UpdateAutomobileCategoryC();
                            break;
                        case 2:
                            UpdateAutomobileCategoryD();
                            break;
                    }
           */

        }

        /*
       /// <summary>
       /// Обновляет содержимое лист-бокса для списка автомобилей отсортированных по категории B.
       /// </summary>
       private void UpdateAutomobileCategoryB()
       {
           listBox1Automobile.Items.Clear();

           List<AutomobileClass> AllCars = new List<AutomobileClass>();
           AllCars = AutomobileClass.ReadAllCars();
           AllCars.ForEach(delegate (AutomobileClass Car)
           {
               if (Car.TypeCar.ToString() == "B")
                   listBox1Automobile.Items.Add(Car);
           });
       }

       /// <summary>
       /// Обновляет содержимое лист-бокса для списка автомобилей отсортированных по категории C.
       /// </summary>
       private void UpdateAutomobileCategoryC()
       {
           listBox1Automobile.Items.Clear();

           List<AutomobileClass> AllCars = new List<AutomobileClass>();
           AllCars = AutomobileClass.ReadAllCars();
           AllCars.ForEach(delegate (AutomobileClass Car)
           {
               if (Car.TypeCar.ToString() == "C")
                   listBox1Automobile.Items.Add(Car);
           });
       }

       /// <summary>
       /// Обновляет содержимое лист-бокса для списка автомобилей отсортированных по категории D.
       /// </summary>
       private void UpdateAutomobileCategoryD()
       {
           listBox1Automobile.Items.Clear();

           List<AutomobileClass> AllCars = new List<AutomobileClass>();
           AllCars = AutomobileClass.ReadAllCars();
           AllCars.ForEach(delegate (AutomobileClass Car)
           {
               if (Car.TypeCar.ToString() == "D")
                   listBox1Automobile.Items.Add(Car);
           });
       }
   */

        /////////////////////////////////////////// Заказы
        /// <summary>
        /// Обновляет содержимое лист-бокса для списка заказов.
        /// </summary>
        private void UpdateOrdersListbox()
        {
            listBox4Order.Items.Clear();

            List<OrderClass> AllOrders = new List<OrderClass>();
            AllOrders = OrderClass.ReadAllOrders();
            AllOrders.ForEach(delegate (OrderClass Order)
            {
                listBox4Order.Items.Add(Order);
            });
        }

        /// <summary>
        /// Добавление заказа. Не протестировано
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9AddRequest_Click(object sender, EventArgs e)
        {
            OrderClass AddOrder = new OrderClass();

            AddOrder.DataRequest = dateTimePicker1.Text.ToString();
            AddOrder.CarRequest = listBox1CarForOrder.SelectedItem.ToString();
            AddOrder.DriverRequest = listBox1DriverForOrder.SelectedItem.ToString();
            AddOrder.CustomerRequest = listBox2CustomerForOrder.SelectedItem.ToString();
            AddOrder.AddressRequest = textBox15AddressOrder.Text;
            AddOrder.TimeRequest = textBox5TimeOrder.Text;
            AddOrder.PriceRequest = textBox6PriceOrder.Text;
            AddOrder.KidsChair = checkBox1KidsChair.Checked;
            AddOrder.WinterTires = checkBox2WinterTyres.Checked;
            AddOrder.SportFastenings = checkBox3SportFastenings.Checked;
            AddOrder.Gps = checkBox4GPS.Checked;

            AddOrder.InsertOrder();
            UpdateOrdersListbox();

            // Очищаем форму добавления заказов                 // Не протестировано
            dateTimePicker1.Text = "";                      
            listBox1CarForOrder.SelectedIndex = -1;      
            listBox1DriverForOrder.SelectedIndex = -1;    
            listBox2CustomerForOrder.SelectedIndex = -1;
            textBox15AddressOrder.Text = "";
            textBox5TimeOrder.Text = "";
            textBox6PriceOrder.Text = "";
            checkBox1KidsChair.Checked = false;
            checkBox2WinterTyres.Checked = false;
            checkBox3SportFastenings.Checked = false;
            checkBox4GPS.Checked = false;
        }

        /// <summary>
        /// Сохранение заказа (редактирование).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7RedactionRequest_Click(object sender, EventArgs e)
        {
            OrderClass RedactionOrder = new OrderClass();

            RedactionOrder = (OrderClass)listBox4Order.SelectedItem;
            RedactionOrder.IDRequest = textBox2IDOrder.Text;
            RedactionOrder.DataRequest = dateTimePicker1.Text.ToString();
            RedactionOrder.CarRequest = listBox1CarForOrder.SelectedItem.ToString();
            RedactionOrder.DriverRequest = listBox1DriverForOrder.SelectedItem.ToString();
            RedactionOrder.CustomerRequest = listBox2CustomerForOrder.SelectedItem.ToString();
            RedactionOrder.AddressRequest = textBox15AddressOrder.Text;
            RedactionOrder.TimeRequest = textBox5TimeOrder.Text;
            RedactionOrder.PriceRequest = textBox6PriceOrder.Text;
            RedactionOrder.KidsChair = checkBox1KidsChair.Checked;
            RedactionOrder.WinterTires = checkBox2WinterTyres.Checked;
            RedactionOrder.SportFastenings = checkBox3SportFastenings.Checked;
            RedactionOrder.Gps = checkBox4GPS.Checked;

            RedactionOrder.EditOrder();
            UpdateOrdersListbox();      
        }

        /// <summary>
        /// Метод срабатывает при клике на заказ из списка.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox4Order_SelectedIndexChanged(object sender, EventArgs e)
        {
            // проверка на пустой индекс
            if (listBox4Order.SelectedItem == null)
            { return; }

            OrderClass CheckedOrder = new OrderClass();
            CheckedOrder = (OrderClass)listBox4Order.SelectedItem;
            textBox2IDOrder.Text = CheckedOrder.IDRequest.ToString();
            dateTimePicker1.Text = CheckedOrder.DataRequest.ToString();
            listBox1CarForOrder.Items.Clear();
            listBox1CarForOrder.Items.Add(CheckedOrder.CarRequest.ToString());
            listBox1DriverForOrder.Items.Clear();
            listBox1DriverForOrder.Items.Add(CheckedOrder.DriverRequest.ToString());
            listBox2CustomerForOrder.Items.Clear();
            listBox2CustomerForOrder.Items.Add(CheckedOrder.CustomerRequest.ToString());
            textBox15AddressOrder.Text = CheckedOrder.AddressRequest.ToString();
            textBox5TimeOrder.Text = CheckedOrder.TimeRequest.ToString();
            textBox6PriceOrder.Text = CheckedOrder.PriceRequest.ToString();
            checkBox1KidsChair.Checked = false;
            checkBox2WinterTyres.Checked = false;
            checkBox3SportFastenings.Checked = false;
            checkBox4GPS.Checked = false;
            if (CheckedOrder.KidsChair) checkBox1KidsChair.Checked = true;
            if (CheckedOrder.WinterTires) checkBox2WinterTyres.Checked = true;
            if (CheckedOrder.SportFastenings) checkBox3SportFastenings.Checked = true;
            if (CheckedOrder.Gps) checkBox4GPS.Checked = true;
        }
    }
}