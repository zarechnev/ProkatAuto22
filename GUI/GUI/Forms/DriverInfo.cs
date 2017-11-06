using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ProkatAuto22.Classes;


namespace ProkatAuto22
{
    public partial class DriverInfo : Form
    {
        string fileName;
        bool habit1 = false, habit2 = false, habit3=false;
        public DriverInfo()
        {
            InitializeComponent();
        }

        private void button1AddPhotoDriver_Click(object sender, EventArgs e)
        {
            OpenFileDialog AddPhotoDriver = new OpenFileDialog();

            AddPhotoDriver.Filter = ("(*.jpg)|*.jpg|(*.png)|*.png|All files (*.*)|*.*");
            if (AddPhotoDriver.ShowDialog() == DialogResult.OK)
            {
                fileName = AddPhotoDriver.SafeFileName;
                string sourcePath = AddPhotoDriver.FileName;
                string targetPath = @"DriverPhoto";

                string destFile = Path.Combine(targetPath, fileName);

                File.Copy(sourcePath, destFile, true);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void buttonAddDriverBase_Click(object sender, EventArgs e)
        {
            DriverClass DriverObjectAdd = new DriverClass();

            DriverObjectAdd.InsertDriver(fileName, textBoxFIO.Text, textBoxExperience.Text, habit1, habit2, habit3);
        }


        private void checkBox1_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            { habit1 = true; }
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            { habit2 = true; }
        }

        private void checkBox3_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            { habit3 = true; }
        }

        
    }
}
