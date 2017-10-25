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


namespace ProkatAuto22
{
    public partial class DriverInfo : Form
    {
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
                string fileName = AddPhotoDriver.SafeFileName;
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
    }
}
