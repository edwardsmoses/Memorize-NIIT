using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectMEMORIZE
{
    public partial class frmMemorize : Form
    {
        private const string helpfile = "MemorizeHelp.chm";
        private const string aboutmemorizefile = "Aboutus.chm";

        public frmMemorize()
        {
            InitializeComponent();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to start a new game", "MEMORIZE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Memory f2 = new Memory();
                f2.MdiParent = this;
                f2.Dispose();
                Memory m = new Memory();
                m.MdiParent = this;
                m.Show();

            }

            if (result == DialogResult.No)
            {

            }
        }

        private void exitGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit this game", "MEMORIZE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.Yes)
            {
                Application.Exit();

            }
            if (result == DialogResult.No)
            {
                
            }
        }

        private void frmMemorize_Load(object sender, EventArgs e)
        {
            Memory f2 = new Memory();
            f2.MdiParent = this;
            f2.Show();
        }

        private void frmMemorize_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to exit this game", "MEMORIZE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

            }
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpNavigator navigator = HelpNavigator.TableOfContents;

            Help.ShowHelp(this, helpfile, navigator, parameterTxtBox.Text);
        }

        private void aboutMEMEORIZEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpNavigator navigator = HelpNavigator.TableOfContents;

            Help.ShowHelp(this, aboutmemorizefile, navigator, parameterTxtBox.Text);
        }

        private void frmMemorize_FormClosed(object sender, FormClosedEventArgs e)
        {

        }




    }
}
