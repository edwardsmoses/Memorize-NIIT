using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ProjectMEMORIZE
{
    public partial class HighScore : Form
    {
        public HighScore()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                DialogResult r = MessageBox.Show("Please Input Your Name", "MEMORIZE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (r == DialogResult.OK)
                {
                    txtName.Focus();
                }
            }
            else
            {

                string Name;
                FileStream fs = new FileStream("C:\\Users\\Public\\Name.Txt", FileMode.Create, FileAccess.ReadWrite);
                StreamWriter sw = new StreamWriter(fs);
                StreamReader sr = new StreamReader(fs);
                Name = txtName.Text;
                sw.Write(Name);
                sw.Flush();
                sw.Close();

                fs.Close();


                Close();
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
