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

namespace GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1AddAuto_Click(object sender, EventArgs e)
        {
            AutomobileAdd FormAddAuto = new AutomobileAdd();
            FormAddAuto.Show();
        }

        private void button4AddDriver_Click(object sender, EventArgs e)
        {
            DriverInfo FormAddDriver = new DriverInfo();
            FormAddDriver.Show();
        }

        private void button9AddRequest_Click(object sender, EventArgs e)
        {
            Arenda_add FormAddArenda = new Arenda_add();
            FormAddArenda.Show();
        }

        private void button12AddCustomer_Click(object sender, EventArgs e)
        {
            CustomerAdd FormAddCustomer = new CustomerAdd();
            FormAddCustomer.Show();
        }
    }
}
