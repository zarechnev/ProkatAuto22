using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProkatAuto22.Classes;

namespace GUI
{
    public partial class Arenda_add : Form
    {
        public Arenda_add()
        {
            OrderClass RequestObjectInfo = new OrderClass();
            InitializeComponent();

            RequestObjectInfo.ReadRequest();
            comboBox1Automobile.DataSource = RequestObjectInfo.ModelCarList;
            comboBox6CustomerID.DataSource = RequestObjectInfo.CustomerIDList;
        }

        private void button1Cancel_Click(object sender, EventArgs e)
        {
            TextboxClear();
            Close();
        }



        private void button9AddRequestBase_Click(object sender, EventArgs e)
        {
            OrderClass RequestObjectAdd = new OrderClass();

            RequestObjectAdd.InsertRequest(textBox1NumberRequest.Text, comboBox1Automobile.SelectedText, textBox9Driver.Text, textBox5DurationLease.Text, textBox6Price.Text, comboBox6CustomerID.SelectedText, textBox1KidsChair.Text, textBox2WinterTires.Text, textBox3SportFastenings.Text, textBox4GpsNav.Text);
        }


        public void RedactionRequest(int indexRedaction)
        {
            OrderClass RequestObjectRedaction = new OrderClass();
            RequestObjectRedaction.ReadRequest();

            /*
            textBox1NumberRequest.Text = RequestObjectRedaction.NumberRequestList[indexRedaction];
            .............................
            */
        }



        private void TextboxClear()
        {
            textBox1KidsChair.Clear();
            textBox1NumberRequest.Clear();
            textBox2WinterTires.Clear();
            textBox3SportFastenings.Clear();
            textBox4GpsNav.Clear();
            textBox5DurationLease.Clear();
            textBox6Price.Clear();
            textBox9Driver.Clear();
        }

        
    }
}
