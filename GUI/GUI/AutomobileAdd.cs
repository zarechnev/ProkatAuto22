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

namespace ProkatAuto22
{
    public partial class AutomobileAdd : Form
    {
        public AutomobileAdd()
        {
            InitializeComponent();
        }

        private void button1AddPhotoAuto_Click(object sender, EventArgs e)
        {
            openFileDialog1PhotoAuto.Filter = ("(*.jpg)|*.jpg|(*.png)|*.png|All files (*.*)|*.*");
            if (openFileDialog1PhotoAuto.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1PhotoAuto.SafeFileName;
                string sourcePath = openFileDialog1PhotoAuto.FileName;
                string targetPath = @"AutomobilePhoto";

                string destFile = Path.Combine(targetPath, fileName);

                File.Copy(sourcePath, destFile, true);
            }
        }

        private void button1Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
