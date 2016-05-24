using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace ProjectMEMORIZE
{
    class MemorizeFunctions : Memory 
    {
       
        public void Won()
        {
            FileStream fs = new FileStream("Score.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fs);

            string Score = sr.ReadToEnd();
            sr.Close();
            fs.Close();

            if (base.stop < Convert.ToInt32(Score))
            {
                using (StreamWriter we = File.CreateText("Score.txt"))
                {
                    we.WriteLine(stop);
                }
                HighScore f3 = new HighScore();
                f3.ShowDialog();
                this.NewGame();
            }
            else
            {
                this.NewGame();
            }
        }

        public void NewGame()
        {

            DialogResult result = MessageBox.Show("Do you want to play a new game", "TIME UP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Close();
                frmMemorize m = new frmMemorize();
                m.Show();

            }
            if (result == DialogResult.No)
            {
                MessageBox.Show("Thanks for Playing this Game", "Memorize");
                Application.Exit();
            }
        }

        public void CloseButton()
        {
            oneclose = 0;
            twoclose = 0;
            threeclose = 0;
            fourclose = 0;
            fiveclose = 0;
            sixclose = 0;
            sevenclose = 0;
            eightclose = 0;
            evelenclose = 0;
            twelveclose = 0;
            thirteenclose = 0;
            fourteenclose = 0;
            fifteenclose = 0;
            sixteenclose = 0;
            seventeenclose = 0;
            eighteenclose = 0;
            one = 0;
            two = 0;
            three = 0;
            four = 0;
            five = 0;
            six = 0;
            seven = 0;
            eight = 0;
        }

    }
}
