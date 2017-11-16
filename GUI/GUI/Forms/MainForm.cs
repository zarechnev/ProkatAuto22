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
using System.Security.Cryptography;

namespace GUI
{
    public partial class Form1 : Form
    {
        string destFile = "";
        string sourcePath;
        List<string> ListDeletePhoto;
        bool FlagCopy = false;
      
        /// <summary>
        /// Конструктор класса.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            ListDeletePhoto = new List<string>();
            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);
    
            Directory.CreateDirectory(@"DriverPhoto");
            Directory.CreateDirectory(@"AutomobilePhoto");

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd.MM.yyyy; hh:mm";

            /// Указываем дефолтную категорию ТС.
            comboBox2CarType.SelectedIndex = 0;

            UpdateDriversListbox();
            UpdateCarsListbox();
            UpdateCustomersListbox();
            UpdateOrdersListbox();
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            if(ListDeletePhoto.Count !=0)
            DeletePhoto(ListDeletePhoto);
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
            MD5 md5 = new MD5CryptoServiceProvider();
            OpenFileDialog AddPhotoDriver = new OpenFileDialog();

            AddPhotoDriver.Filter = ("(*.jpg)|*.jpg|(*.png)|*.png|All files (*.*)|*.*");
            if (AddPhotoDriver.ShowDialog() == DialogResult.OK)
            {
                string fileNameDriver = AddPhotoDriver.SafeFileName;
                sourcePath = AddPhotoDriver.FileName;
                string targetPath = @"DriverPhoto";
                byte[] checkSum = md5.ComputeHash(Encoding.UTF8.GetBytes(fileNameDriver));
                string encodedFileNameDriver = BitConverter.ToString(checkSum).Replace("-", String.Empty) + Path.GetExtension(fileNameDriver);

                destFile = Path.Combine(targetPath, encodedFileNameDriver);

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
            ListDeletePhoto.Add(DriverToDelete.PhotoDriver);

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
            {
                ListDeletePhoto.Add(RedactionDriver.PhotoDriver);
                RedactionDriver.PhotoDriver = destFile;
            }

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
            RedactionCustomer = (CustomerClass)listBox3Customers.SelectedItem;
            RedactionCustomer.FIOcustomer = textBox12FioCustomer.Text;
            RedactionCustomer.PhoneCustomer = textBox11PhoneCustomer.Text;
            RedactionCustomer.CityCustomer = textBox10CityCustomer.Text;

            RedactionCustomer.EditCustomer();

            UpdateCustomersListbox();

            /// Очищаем форму добавления клиентов
            textBox12FioCustomer.Text = "";
            textBox11PhoneCustomer.Text = "";
            textBox10CityCustomer.Text = "";
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

        /// <summary>
        /// Удаление клиента.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1DeleteOrder_Click(object sender, EventArgs e)
        {
            CustomerClass CustomerToDelete = new CustomerClass();
            CustomerToDelete = (CustomerClass)listBox3Customers.SelectedItem;
            CustomerToDelete.DeleteCustomer();

            listBox2CustomerForOrder.Items.Clear();
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
                listBox1Automobile.Items.Add(Car);
            });
        }

        /// <summary>
        /// Очищаем форму добавления автомобилей.
        /// </summary>
        private void ClearCarPanel()
        {
            textBox1ModelCar.Text = "";
            textBox4PriceForHourCar.Text = "";
            comboBox2CarType.SelectedIndex = 0;
            textBox9CapacityCar.Text = "";
            textBox7YearIssueCar.Text = "";
            AutoGosNumberTextBox.Text = "";
            textBox14CarryingCar.Text = "";
            pictureBox1.Image = null;
            pictureBox1.BackColor = Color.Gray;
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
            AddCar.CarCategoryID =comboBox2CarType.SelectedIndex+1;
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

            ClearCarPanel();
        }

        /// <summary>
        /// Смена фотографии автомобиля(запускает диалог для выбора фото и сохраняет итоговый путь destFile). Не протестировано.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2ChangePhotoCar_Click(object sender, EventArgs e)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            OpenFileDialog AddPhotoCar = new OpenFileDialog();

            AddPhotoCar.Filter = ("(*.jpg)|*.jpg|(*.png)|*.png|All files (*.*)|*.*");
            if (AddPhotoCar.ShowDialog() == DialogResult.OK)
            {
                string fileNameCar = AddPhotoCar.SafeFileName;
                sourcePath = AddPhotoCar.FileName;
                string targetPath = @"AutomobilePhoto";
                byte[] checkSum = md5.ComputeHash(Encoding.UTF8.GetBytes(fileNameCar));
                string encodedFileNameCar = BitConverter.ToString(checkSum).Replace("-", String.Empty) + Path.GetExtension(fileNameCar);

                destFile = Path.Combine(targetPath, encodedFileNameCar);

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
            RedactionCar.CarCategoryID = comboBox2CarType.SelectedIndex +1;
            RedactionCar.CapacityCar = textBox9CapacityCar.Text;
            RedactionCar.YearIssueCar = textBox7YearIssueCar.Text;
            RedactionCar.GosNumberCar = AutoGosNumberTextBox.Text;
            RedactionCar.CarryingCar = textBox14CarryingCar.Text;

            if (destFile != "")
            {
                ListDeletePhoto.Add(RedactionCar.PhotoCar);
                RedactionCar.PhotoCar = destFile;
            }

            if (FlagCopy)
            {
                File.Copy(sourcePath, destFile, true);
                destFile = "";
            }
            RedactionCar.EditCar();

            UpdateCarsListbox();
            FlagCopy = false;
            ClearCarPanel();
        }

        /// <summary>
        /// Удаляем автомобиль.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1DeleteCar_Click(object sender, EventArgs e)
        {
            AutomobileClass CarToDelete = new AutomobileClass();
            CarToDelete = (AutomobileClass)listBox1Automobile.SelectedItem;
            CarToDelete.DeleteCar();
            ListDeletePhoto.Add(CarToDelete.PhotoCar);

            ClearCarPanel();
            UpdateCarsListbox();

            listBox1CarForOrder.Items.Clear();
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
            textBox1ModelCar.Text = CheckedCar.ModelCar.ToString();
            textBox4PriceForHourCar.Text = CheckedCar.PriceHourCar.ToString();
            comboBox2CarType.Text = CheckedCar.TypeCar;
            textBox9CapacityCar.Text = CheckedCar.CapacityCar.ToString();
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
        /// Очищаем форму добавления заказов.
        /// </summary>
        private void ClearOrderPanel()
        {
            dateTimePicker1.Text = "";
            listBox1CarForOrder.Items.Clear();
            listBox1DriverForOrder.Items.Clear();
            listBox2CustomerForOrder.Items.Clear();
            textBox15AddressOrder.Text = "";
            textBox5TimeOrder.Text = "";
            textBox6PriceOrder.Text = "";
            checkBox1KidsChair.Checked = false;
            checkBox2WinterTyres.Checked = false;
            checkBox3SportFastenings.Checked = false;
            checkBox4GPS.Checked = false;
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
            AddOrder.CarRequest = (AutomobileClass)listBox1CarForOrder.Items[0];
            AddOrder.DriverRequest = (DriverClass)listBox1DriverForOrder.Items[0];
            AddOrder.CustomerRequest = (CustomerClass)listBox2CustomerForOrder.Items[0];
            AddOrder.AddressRequest = textBox15AddressOrder.Text;
            AddOrder.TimeRequest = textBox5TimeOrder.Text;
            AddOrder.KidsChair = checkBox1KidsChair.Checked;
            AddOrder.WinterTires = checkBox2WinterTyres.Checked;
            AddOrder.SportFastenings = checkBox3SportFastenings.Checked;
            AddOrder.Gps = checkBox4GPS.Checked;

            AddOrder.InsertOrder();
            UpdateOrdersListbox();

            // Очищаем форму добавления заказов                 // Не протестировано
            ClearOrderPanel();
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
            RedactionOrder.AddressRequest = textBox15AddressOrder.Text;
            RedactionOrder.TimeRequest = textBox5TimeOrder.Text;
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
            ///dateTimePicker1.Text = CheckedOrder.DataRequest.ToString();
            listBox1CarForOrder.Items.Clear();
            listBox1CarForOrder.Items.Add(CheckedOrder.CarRequest);
            listBox1DriverForOrder.Items.Clear();
            listBox1DriverForOrder.Items.Add(CheckedOrder.DriverRequest);
            listBox2CustomerForOrder.Items.Clear();
            listBox2CustomerForOrder.Items.Add(CheckedOrder.CustomerRequest);
            textBox15AddressOrder.Text = CheckedOrder.AddressRequest;
            textBox5TimeOrder.Text = CheckedOrder.TimeRequest.ToString();
            ///textBox6PriceOrder.Text = CheckedOrder.PriceRequest.ToString();
            checkBox1KidsChair.Checked = false;
            checkBox2WinterTyres.Checked = false;
            checkBox3SportFastenings.Checked = false;
            checkBox4GPS.Checked = false;
            if (CheckedOrder.KidsChair) checkBox1KidsChair.Checked = true;
            if (CheckedOrder.WinterTires) checkBox2WinterTyres.Checked = true;
            if (CheckedOrder.SportFastenings) checkBox3SportFastenings.Checked = true;
            if (CheckedOrder.Gps) checkBox4GPS.Checked = true;
        }

        /// <summary>
        /// Метод удаляет неиспользуемые фото из списка.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeletePhoto(List<string> s)
        {
            
            foreach (string i in s)
            {
                if (i != "")
                    File.Delete(i);
            }
        }

        // Валидация полей
        //FIO vod
        private void textBox2FioDriver_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && (e.KeyChar < 'А' || e.KeyChar > 'я')&&(e.KeyChar!=32))
                e.Handled = true;
        }
        //Stag
        private void textBox3ExpirienceDriver_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                e.Handled = true;
        }
        //cena arendy
        private void textBox4PriceForHourCar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                e.Handled = true;
        }
        //vmestimost
        private void textBox9CapacityCar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                e.Handled = true;
        }
        //god vypuska
        private void textBox7YearIssueCar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox7YearIssueCar.TextLength ==4) {e.Handled=true ;}
            if (e.KeyChar==8)e.Handled=false;
            if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                e.Handled = true;

        }
        //gos nomer
        private void AutoGosNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                e.Handled = true;
        }
        //gruzopodemnost
        private void textBox14CarryingCar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                e.Handled = true;
        }

        //fio
        private void textBox12FioCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && (e.KeyChar < 'А' || e.KeyChar > 'я') && (e.KeyChar != 32))
                e.Handled = true;
        }

        private void textBox11PhoneCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                e.Handled = true;
        }

        private void textBox10CityCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && (e.KeyChar < 'А' || e.KeyChar > 'я') && (e.KeyChar != 32))
                e.Handled = true;
        }

        //vremya arendy
        private void textBox5TimeOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                e.Handled = true;
        }

        private void textBox6PriceOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                e.Handled = true;
        }

        /// <summary>
        /// Удаление заявок.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8DeleteRequest_Click(object sender, EventArgs e)
        {
            OrderClass OrderToDelete = new OrderClass();
            OrderToDelete = (OrderClass)listBox4Order.SelectedItem;
            OrderToDelete.DeleteOrder();

            ClearOrderPanel();

            UpdateOrdersListbox();
        }
    }
}