using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProkatAuto22.Classes;

namespace ProkatAuto22
{
    public partial class AutomobileAdd : Form
    {
        string fileName;
        public AutomobileAdd()
        {
            AutomobileClass CarInfo = new AutomobileClass();
            InitializeComponent();
            CarInfo.ReadCar();
            comboBox1Driver.DataSource = CarInfo.DriverCarList;
        }

        // Добавление фото
        private void button1AddPhotoAuto_Click(object sender, EventArgs e)
        {
            openFileDialog1PhotoAuto.Filter = ("(*.jpg)|*.jpg|(*.png)|*.png|All files (*.*)|*.*");
            if (openFileDialog1PhotoAuto.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog1PhotoAuto.SafeFileName;
                string sourcePath = openFileDialog1PhotoAuto.FileName;
                string targetPath = @"AutomobilePhoto";

                string destFile = Path.Combine(targetPath, fileName);

                File.Copy(sourcePath, destFile, true);
            }
        }


        private void button1Cancel_Click(object sender, EventArgs e)
        {
            TextboxClear();
            Close();
        }


        // Добавление машины в базу
        private void button9AddAutoBase_Click(object sender, EventArgs e)
        {
            AutomobileClass CarObjectAdd = new AutomobileClass();

            CarObjectAdd.InsertCar(textBoxModelAuto.Text, textBox1ClassAuto.Text, textBox9TypeTransport.Text, textBox5ValueArenda.Text, fileName, comboBox1Driver.SelectedText, textBox3ReleaseYear.Text, textBox4MaxSpeed.Text, textBox8NumberSeats.Text, textBox10VolumeTrunk.Text);
            

        }

        // Редактирование
        public void RedactionCar(int indexRedaction)
        {
            AutomobileClass CarObjectRedaction = new AutomobileClass();
            CarObjectRedaction.ReadCar();

            textBoxModelAuto.Text = CarObjectRedaction.ModelCarList[indexRedaction];
            textBox1ClassAuto.Text = CarObjectRedaction.ClassCarList[indexRedaction];
            /*.............................
             */
        }

        private void TextboxClear()
        {
            textBox1ClassAuto.Clear();
            textBox1ClassAuto.Clear();
            textBox9TypeTransport.Clear();
            textBox5ValueArenda.Clear();
            textBox3ReleaseYear.Clear();
            textBox4MaxSpeed.Clear();
            textBox8NumberSeats.Clear();
            textBox10VolumeTrunk.Clear();
        }

       


        /*     private void SetCar(AutomobileClass CarObjectAdd)
             {
                 CarObjectAdd.ModelCar = textBoxModelAuto.Text;
                 CarObjectAdd.ClassCar = textBox1ClassAuto.Text;
                 /*
                  * 
                  *

             }
         */


    }
}
