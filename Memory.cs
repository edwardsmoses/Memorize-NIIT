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
    public partial class Memory : Form
    {
      

        public Memory()
        {
            InitializeComponent();
        }

        
        public int click = 0;
        public int one = 0;
        public int two = 0;
        public int three = 0;
        public int four = 0;
        public int five = 0;
        public int six = 0;
        public int seven = 0;
        public int eight = 0;
        public int Seconds = 40;
        public int Sec = 60;
        public int oneclose = 0;
        public int twoclose = 0;
        public int threeclose = 0;
        public int fourclose = 0;
        public int fiveclose = 0;
        public int sixclose = 0;
        public int sevenclose = 0;
        public int eightclose = 0;
        public int evelenclose = 0;
        public int twelveclose = 0;
        public int thirteenclose = 0;
        public int fourteenclose = 0;
        public int fifteenclose = 0;
        public int sixteenclose = 0;
        public int seventeenclose = 0;
        public int eighteenclose = 0;
        public int stop = 0;
        Random Rand = new Random();
        public int oneX;
        public int twoX;
        public int threeX;
        public int fourX;
        public int fourY;
        public int fiveY;
        public int sixY;
        public int sevenY;
       
        // this list stores the x-location of the buttons.
        List<int> X = new List<int>();
        // this list stores the y-location of the buttons.
        List<int> ListoneY = new List<int>();
        // this list stores the random x-location of the buttons.
        List<int> RandomX = new List<int>();
        // this list stores the random y-location of the buttons.
         List<int> RandomoneY = new List<int>();
       
        private void timerMemorize_Tick(object sender, EventArgs e)
        {
            
            stop++;
            if (Seconds <= 40)
            {
                Seconds--;
                timer.Text = "1" + " " + ":" + " " + Seconds.ToString();
            }
            if (Seconds < 10)
            {

                timer.Text = "1" + " " + ":" + " " + "0" + Seconds.ToString();
            }
            if (Seconds < 0)
            {
                Sec--;
                timer.Text = "0" + " " + ": " + " " + Sec.ToString();
            }

            if (btn1.Visible == false && btn11.Visible == false && btn2.Visible == false && btn22.Visible == false && btn3.Visible == false && btn33.Visible == false && btn4.Visible == false && btn44.Visible == false && btn5.Visible == false && btn55.Visible == false && btn6.Visible == false && btn66.Visible == false && btn7.Visible == false && btn77.Visible == false && btn8.Visible == false && btn88.Visible == false)
            {
                timerMemorize.Stop();
                if (Seconds < 40 && Seconds >= 1)
                {
                    MessageBox.Show("You have completed this game in" + " " + "1 minutes" + ", " + " " + Seconds + " Seconds");
                    this.Won();
                }
                if (Seconds < 1)
                {
                    MessageBox.Show("You have completed this game in" + " " + stop + " Seconds");
                    this.Won();
                }

                btnPause.Enabled = false;
                btnResume.Enabled = false;
                pauseToolStripMenuItem.Enabled = false ;
                resumeToolStripMenuItem.Enabled = false;

            }

            if (stop == 100 || Sec <= 0)
            {
                timerMemorize.Stop();
                this.Won();
                btnPause.Enabled = false;
                btnResume.Enabled = false;
                pauseToolStripMenuItem.Enabled = false;
                resumeToolStripMenuItem.Enabled = false;

            }
        }

        private void viewTopScorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Secon;
            string Name;
            using (StreamReader sr = File.OpenText("C:\\Users\\Public\\Score.Txt"))
            {
                Secon = sr.ReadLine();
            }
            using (StreamReader sr = File.OpenText("C:\\Users\\Public\\Name.Txt"))
            {
                Name = sr.ReadLine();
            }
            MessageBox.Show("\tHIGH SCORER " + "\n" + "Seconds Elapsed:  " + Secon + "\n" + "Name of High Scorer:  " + Name, "MEMORIZE");
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timerMemorize.Enabled = false;
            this.DisableButton();
        }

        private void resumeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timerMemorize.Enabled = true;
            this.EnableButton();
        }

        public void DisableButton()
        {
            btn1.Enabled = false;
            btn2.Enabled = false;
            btn3.Enabled = false;
            btn4.Enabled = false;
            btn5.Enabled = false;
            btn6.Enabled = false;
            btn7.Enabled = false;
            btn8.Enabled = false;
            btn11.Enabled = false;
            btn22.Enabled = false;
            btn33.Enabled = false;
            btn44.Enabled = false;
            btn55.Enabled = false;
            btn66.Enabled = false;
            btn77.Enabled = false;
            btn88.Enabled = false;

        }

        public void EnableButton()
        {
            btn1.Enabled = true;
            btn2.Enabled = true;
            btn3.Enabled = true;
            btn4.Enabled = true;
            btn5.Enabled = true;
            btn6.Enabled = true;
            btn7.Enabled = true;
            btn8.Enabled = true;
            btn11.Enabled = true;
            btn22.Enabled = true;
            btn33.Enabled = true;
            btn44.Enabled = true;
            btn55.Enabled = true;
            btn66.Enabled = true;
            btn77.Enabled = true;
            btn88.Enabled = true;

        }

        public void Won()
        {
            string paths = "C:\\Users\\Public\\Score.Txt";
            FileStream fs = new FileStream(paths, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fs);

            string Score = sr.ReadToEnd();
            sr.Close();
            fs.Close();

            if (stop < Convert.ToInt32(Score))
            {
                using (StreamWriter we = File.CreateText(paths))
                {
                    we.WriteLine(stop);
                }
                HighScore f3 = new HighScore();
                f3.ShowDialog();
                this.WonNewGame();
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
                Application.Restart();
            }
            if (result == DialogResult.No)
            {
                MessageBox.Show("Thanks for Playing this Game", "Memorize");
                Application.Exit();
            }
        }

        public void WonNewGame()
        {
            DialogResult result = MessageBox.Show("Would you like to play a new game", "You Are The Highest Scorer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Restart();

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

        private void Memory_Load(object sender, EventArgs e)
        {

            btnPause.Enabled = true;
            btnResume.Enabled = true;
            pauseToolStripMenuItem.Enabled = true;
            resumeToolStripMenuItem.Enabled = true;
            FileInfo fi = new FileInfo("C:\\Users\\Public\\Score.Txt");
            if (fi.Exists == true)
            {
            }
            try
            {
                if (fi.Exists == false)
                {
                    using (StreamWriter sw = File.CreateText("C:\\Users\\Public\\Score.Txt"))
                    {
                        sw.Write("100");
                        sw.Close();
                    }
                }
            }
            catch
            {
            }
            FileInfo f = new FileInfo("C:\\Users\\Public\\Name.Txt");
            if (f.Exists == true)
            {
            }
            try
            {
                if (f.Exists == false)
                {
                    using (StreamWriter sw = File.CreateText("C:\\Users\\Public\\Name.Txt"))
                    {
                        sw.Write("Jerry");
                        sw.Close();
                    }
                }
            }
            catch
            {
            }
            

            X.Add(41);
            X.Add(144);
            X.Add(258);
            X.Add(355);
            int rgn = 0;
            int crs = 0;
            for (int i = 0; i < 4; i++)
            {
                crs = X.Count - 1;
                rgn = Rand.Next(0, crs);
                RandomX.Add(X[rgn]);
                X.RemoveAt(rgn);
            }

            oneX = RandomX[0];
            twoX = RandomX[1];
            threeX = RandomX[2];
            fourX = RandomX[3];


            ListoneY.Add(100);
            ListoneY.Add(200);
            ListoneY.Add(300);
            ListoneY.Add(400);
            int rgy = 0;
            int cry = 0;
            for (int i = 0; i < 4; i++)
            {
                cry = ListoneY.Count - 1;
                rgy = Rand.Next(0, cry);
                RandomoneY.Add(ListoneY[rgy]);
                ListoneY.RemoveAt(rgy);
            }

            fourY = RandomoneY[0];
            fiveY = RandomoneY[1];
            sixY = RandomoneY[2];
            sevenY = RandomoneY[3];

            btn4.Location = new Point(oneX, fourY);
            btn5.Location = new Point(oneX, fiveY);
            btn6.Location = new Point(oneX, sixY);
            btn7.Location = new Point(oneX, sevenY);
            btn1.Location = new Point(twoX, fourY);
            btn2.Location = new Point(twoX, fiveY);
            btn3.Location = new Point(twoX, sixY);
            btn8.Location = new Point(twoX, sevenY);
            btn11.Location = new Point(threeX, fourY);
            btn22.Location = new Point(threeX, fiveY);
            btn33.Location = new Point(threeX, sixY);
            btn44.Location = new Point(threeX, sevenY);
            btn55.Location = new Point(fourX, fourY);
            btn66.Location = new Point(fourX, fiveY);
            btn77.Location = new Point(fourX, sixY);
            btn88.Location = new Point(fourX, sevenY);
             
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            oneclose++;
            one++;
            click++;
            btn1.ImageIndex = 0;


            if (oneclose <= 1 && one == 2 && click == 2)
            {


                btn11.Visible = false;
                btn1.Visible = false;
                click = 0; one = 0; oneclose = 0;
            }

            if (oneclose <= 1 && click > 2)
            {

                btn1.ImageIndex = 4;
                btn11.ImageIndex = 4;
                btn2.ImageIndex = 4;
                btn22.ImageIndex = 4;
                btn3.ImageIndex = 4;
                btn33.ImageIndex = 4;
                btn4.ImageIndex = 4;
                btn44.ImageIndex = 4;
                btn5.ImageIndex = 4;
                btn55.ImageIndex = 4;
                btn6.ImageIndex = 4;
                btn66.ImageIndex = 4;
                btn7.ImageIndex = 4;
                btn77.ImageIndex = 4;
                btn8.ImageIndex = 4;
                btn88.ImageIndex = 4;
                click = 0;
                one = 0;
                oneclose = 0;
                this.CloseButton();
            }
            if (oneclose > 1)
            {
                btn1.ImageIndex = 4;
                one = 0;
                click = 0;
                oneclose = 0;
            }
            if (click == 0)
            {
                btn1.ImageIndex = 4;
                btn11.ImageIndex = 4;
                btn2.ImageIndex = 4;
                btn22.ImageIndex = 4;
                btn3.ImageIndex = 4;
                btn33.ImageIndex = 4;
                btn4.ImageIndex = 4;
                btn44.ImageIndex = 4;
                btn5.ImageIndex = 4;
                btn55.ImageIndex = 4;
                btn6.ImageIndex = 4;
                btn66.ImageIndex = 4;
                btn7.ImageIndex = 4;
                btn77.ImageIndex = 4;
                btn8.ImageIndex = 4;
                btn88.ImageIndex = 4;
                this.CloseButton();
            }
        }

        private void btn11_Click(object sender, EventArgs e)
        {
            evelenclose++;
            one++;
            click++;
            btn11.ImageIndex = 0;



            if (evelenclose <= 1 && one == 2 && click == 2)
            {

                btn11.Visible = false;
                btn1.Visible = false;
                click = 0; one = 0; oneclose = 0;
            }

            if (evelenclose <= 1 && click > 2)
            {

                btn1.ImageIndex = 4;
                btn11.ImageIndex = 4;
                btn2.ImageIndex = 4;
                btn22.ImageIndex = 4;
                btn3.ImageIndex = 4;
                btn33.ImageIndex = 4;
                btn4.ImageIndex = 4;
                btn44.ImageIndex = 4;
                btn5.ImageIndex = 4;
                btn55.ImageIndex = 4;
                btn6.ImageIndex = 4;
                btn66.ImageIndex = 4;
                btn7.ImageIndex = 4;
                btn77.ImageIndex = 4;
                btn8.ImageIndex = 4;
                btn88.ImageIndex = 4;
                click = 0;
                one = 0;
                evelenclose = 0;
                this.CloseButton();
            }
            if (evelenclose > 1)
            {
                btn11.ImageIndex = 4;
                one = 0;
                click = 0;
                evelenclose = 0;
            }
            if (click == 0)
            {
                btn1.ImageIndex = 4;
                btn11.ImageIndex = 4;
                btn2.ImageIndex = 4;
                btn22.ImageIndex = 4;
                btn3.ImageIndex = 4;
                btn33.ImageIndex = 4;
                btn4.ImageIndex = 4;
                btn44.ImageIndex = 4;
                btn5.ImageIndex = 4;
                btn55.ImageIndex = 4;
                btn6.ImageIndex = 4;
                btn66.ImageIndex = 4;
                btn7.ImageIndex = 4;
                btn77.ImageIndex = 4;
                btn8.ImageIndex = 4;
                btn88.ImageIndex = 4;
                this.CloseButton();
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            twoclose++;
            two++;
            click++;
            btn2.ImageIndex = 1;



            if (twoclose <= 1 && two == 2 && click == 2)
            {

                btn22.ImageIndex = 1;
                btn22.Visible = false;
                btn2.Visible = false;
                click = 0; two = 0; twoclose = 0;
            }

            if (twoclose <= 1 && click > 2)
            {

                btn1.ImageIndex = 4;
                btn11.ImageIndex = 4;
                btn2.ImageIndex = 4;
                btn22.ImageIndex = 4;
                btn3.ImageIndex = 4;
                btn33.ImageIndex = 4;
                btn4.ImageIndex = 4;
                btn44.ImageIndex = 4;
                btn5.ImageIndex = 4;
                btn55.ImageIndex = 4;
                btn6.ImageIndex = 4;
                btn66.ImageIndex = 4;
                btn7.ImageIndex = 4;
                btn77.ImageIndex = 4;
                btn8.ImageIndex = 4;
                btn88.ImageIndex = 4;
                click = 0;
                two = 0;
                twoclose = 0;
                this.CloseButton();
            }
            if (twoclose > 1)
            {
                btn2.ImageIndex = 4;
                two = 0;
                click = 0;
                twoclose = 0;
            }
            if (click == 0)
            {
                btn1.ImageIndex = 4;
                btn11.ImageIndex = 4;
                btn2.ImageIndex = 4;
                btn22.ImageIndex = 4;
                btn3.ImageIndex = 4;
                btn33.ImageIndex = 4;
                btn4.ImageIndex = 4;
                btn44.ImageIndex = 4;
                btn5.ImageIndex = 4;
                btn55.ImageIndex = 4;
                btn6.ImageIndex = 4;
                btn66.ImageIndex = 4;
                btn7.ImageIndex = 4;
                btn77.ImageIndex = 4;
                btn8.ImageIndex = 4;
                btn88.ImageIndex = 4;
                this.CloseButton();
            }
        }

        private void btn22_Click(object sender, EventArgs e)
        {
            twelveclose++;
            two++;
            click++;
            btn22.ImageIndex = 1;



            if (twelveclose <= 1 && two == 2 && click == 2)
            {

                btn22.Visible = false;
                btn2.Visible = false;
                click = 0; two = 0; twoclose = 0;
            }

            if (twoclose <= 1 && click > 2)
            {

                btn1.ImageIndex = 4;
                btn11.ImageIndex = 4;
                btn2.ImageIndex = 4;
                btn22.ImageIndex = 4;
                btn3.ImageIndex = 4;
                btn33.ImageIndex = 4;
                btn4.ImageIndex = 4;
                btn44.ImageIndex = 4;
                btn5.ImageIndex = 4;
                btn55.ImageIndex = 4;
                btn6.ImageIndex = 4;
                btn66.ImageIndex = 4;
                btn7.ImageIndex = 4;
                btn77.ImageIndex = 4;
                btn8.ImageIndex = 4;
                btn88.ImageIndex = 4;
                click = 0;
                two = 0;
                twelveclose = 0;
                this.CloseButton();
            }
            if (twelveclose > 1)
            {
                btn1.ImageIndex = 4;
                two = 0;
                click = 0;
                twelveclose = 0;
            }
            if (click == 0)
            {
                btn1.ImageIndex = 4;
                btn11.ImageIndex = 4;
                btn2.ImageIndex = 4;
                btn22.ImageIndex = 4;
                btn3.ImageIndex = 4;
                btn33.ImageIndex = 4;
                btn4.ImageIndex = 4;
                btn44.ImageIndex = 4;
                btn5.ImageIndex = 4;
                btn55.ImageIndex = 4;
                btn6.ImageIndex = 4;
                btn66.ImageIndex = 4;
                btn7.ImageIndex = 4;
                btn77.ImageIndex = 4;
                btn8.ImageIndex = 4;
                btn88.ImageIndex = 4;
                this.CloseButton();
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            threeclose++;
            three++;
            click++;
            btn3.ImageIndex = 2;



            if (threeclose <= 1 && three == 2 && click == 2)
            {

                btn33.ImageIndex = 2;
                btn33.Visible = false;
                btn3.Visible = false;
                click = 0; three = 0; threeclose = 0;
            }

            if (threeclose <= 1 && click > 2)
            {

                btn1.ImageIndex = 4;
                btn11.ImageIndex = 4;
                btn2.ImageIndex = 4;
                btn22.ImageIndex = 4;
                btn3.ImageIndex = 4;
                btn33.ImageIndex = 4;
                btn4.ImageIndex = 4;
                btn44.ImageIndex = 4;
                btn5.ImageIndex = 4;
                btn55.ImageIndex = 4;
                btn6.ImageIndex = 4;
                btn66.ImageIndex = 4;
                btn7.ImageIndex = 4;
                btn77.ImageIndex = 4;
                btn8.ImageIndex = 4;
                btn88.ImageIndex = 4;
                click = 0;
                three = 0;
                threeclose = 0;
                this.CloseButton();
            }
            if (threeclose > 1)
            {
                btn3.ImageIndex = 4;
                three = 0;
                click = 0;
                threeclose = 0;
            }
            if (click == 0)
            {
                btn1.ImageIndex = 4;
                btn11.ImageIndex = 4;
                btn2.ImageIndex = 4;
                btn22.ImageIndex = 4;
                btn3.ImageIndex = 4;
                btn33.ImageIndex = 4;
                btn4.ImageIndex = 4;
                btn44.ImageIndex = 4;
                btn5.ImageIndex = 4;
                btn55.ImageIndex = 4;
                btn6.ImageIndex = 4;
                btn66.ImageIndex = 4;
                btn7.ImageIndex = 4;
                btn77.ImageIndex = 4;
                btn8.ImageIndex = 4;
                btn88.ImageIndex = 4;
                this.CloseButton();
            }
        }

        private void btn33_Click(object sender, EventArgs e)
        {
            thirteenclose++;
            three++;
            click++;
            btn33.ImageIndex = 2;



            if (thirteenclose <= 1 && three == 2 && click == 2)
            {

                btn3.ImageIndex = 2;
                btn33.Visible = false;
                btn3.Visible = false;
                click = 0; three = 0; thirteenclose = 0;
            }

            if (thirteenclose <= 1 && click > 2)
            {

                btn1.ImageIndex = 4;
                btn11.ImageIndex = 4;
                btn2.ImageIndex = 4;
                btn22.ImageIndex = 4;
                btn3.ImageIndex = 4;
                btn33.ImageIndex = 4;
                btn4.ImageIndex = 4;
                btn44.ImageIndex = 4;
                btn5.ImageIndex = 4;
                btn55.ImageIndex = 4;
                btn6.ImageIndex = 4;
                btn66.ImageIndex = 4;
                btn7.ImageIndex = 4;
                btn77.ImageIndex = 4;
                btn8.ImageIndex = 4;
                btn88.ImageIndex = 4;
                click = 0;
                three = 0;
                thirteenclose = 0;
                this.CloseButton();
            }
            if (thirteenclose > 1)
            {
                btn33.ImageIndex = 4;
                three = 0;
                click = 0;
                thirteenclose = 0;
            }
            if (click == 0)
            {
                btn1.ImageIndex = 4;
                btn11.ImageIndex = 4;
                btn2.ImageIndex = 4;
                btn22.ImageIndex = 4;
                btn3.ImageIndex = 4;
                btn33.ImageIndex = 4;
                btn4.ImageIndex = 4;
                btn44.ImageIndex = 4;
                btn5.ImageIndex = 4;
                btn55.ImageIndex = 4;
                btn6.ImageIndex = 4;
                btn66.ImageIndex = 4;
                btn7.ImageIndex = 4;
                btn77.ImageIndex = 4;
                btn8.ImageIndex = 4;
                btn88.ImageIndex = 4;
                this.CloseButton();
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            fourclose++;
            four++;
            click++;
            btn4.ImageIndex = 3;



            if (fourclose <= 1 && four == 2 && click == 2)
            {

                btn44.ImageIndex = 3;
                btn44.Visible = false;
                btn4.Visible = false;
                click = 0; four = 0; fourclose = 0;
            }

            if (fourclose <= 1 && click > 2)
            {

                btn1.ImageIndex = 4;
                btn11.ImageIndex = 4;
                btn2.ImageIndex = 4;
                btn22.ImageIndex = 4;
                btn3.ImageIndex = 4;
                btn33.ImageIndex = 4;
                btn4.ImageIndex = 4;
                btn44.ImageIndex = 4;
                btn5.ImageIndex = 4;
                btn55.ImageIndex = 4;
                btn6.ImageIndex = 4;
                btn66.ImageIndex = 4;
                btn7.ImageIndex = 4;
                btn77.ImageIndex = 4;
                btn8.ImageIndex = 4;
                btn88.ImageIndex = 4;
                click = 0;
                four = 0;
                fourclose = 0;
                this.CloseButton();
            }
            if (fourclose > 1)
            {
                btn4.ImageIndex = 4;
                four = 0;
                click = 0;
                fourclose = 0;
            }
            if (click == 0)
            {
                btn1.ImageIndex = 4;
                btn11.ImageIndex = 4;
                btn2.ImageIndex = 4;
                btn22.ImageIndex = 4;
                btn3.ImageIndex = 4;
                btn33.ImageIndex = 4;
                btn4.ImageIndex = 4;
                btn44.ImageIndex = 4;
                btn5.ImageIndex = 4;
                btn55.ImageIndex = 4;
                btn6.ImageIndex = 4;
                btn66.ImageIndex = 4;
                btn7.ImageIndex = 4;
                btn77.ImageIndex = 4;
                btn8.ImageIndex = 4;
                btn88.ImageIndex = 4;
                this.CloseButton();
            }

        }

        private void btn44_Click(object sender, EventArgs e)
        {
            fourteenclose++;
            four++;
            click++;
            btn44.ImageIndex = 3;



            if (fourteenclose <= 1 && four == 2 && click == 2)
            {

                btn4.ImageIndex = 3;
                btn44.Visible = false;
                btn4.Visible = false;
                click = 0; four = 0; fourteenclose = 0;
            }

            if (fourteenclose <= 1 && click > 2)
            {

                btn1.ImageIndex = 4;
                btn11.ImageIndex = 4;
                btn2.ImageIndex = 4;
                btn22.ImageIndex = 4;
                btn3.ImageIndex = 4;
                btn33.ImageIndex = 4;
                btn4.ImageIndex = 4;
                btn44.ImageIndex = 4;
                btn5.ImageIndex = 4;
                btn55.ImageIndex = 4;
                btn6.ImageIndex = 4;
                btn66.ImageIndex = 4;
                btn7.ImageIndex = 4;
                btn77.ImageIndex = 4;
                btn8.ImageIndex = 4;
                btn88.ImageIndex = 4;
                click = 0;
                four = 0;
                fourteenclose = 0;
                this.CloseButton();
            }
            if (fourteenclose > 1)
            {
                btn44.ImageIndex = 4;
                four = 0;
                click = 0;
                fourteenclose = 0;
            }
            if (click == 0)
            {
                btn1.ImageIndex = 4;
                btn11.ImageIndex = 4;
                btn2.ImageIndex = 4;
                btn22.ImageIndex = 4;
                btn3.ImageIndex = 4;
                btn33.ImageIndex = 4;
                btn4.ImageIndex = 4;
                btn44.ImageIndex = 4;
                btn5.ImageIndex = 4;
                btn55.ImageIndex = 4;
                btn6.ImageIndex = 4;
                btn66.ImageIndex = 4;
                btn7.ImageIndex = 4;
                btn77.ImageIndex = 4;
                btn8.ImageIndex = 4;
                btn88.ImageIndex = 4;
                this.CloseButton();
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            fiveclose++;
            five++;
            click++;
            btn5.ImageIndex = 5;



            if (fiveclose <= 1 && five == 2 && click == 2)
            {

                btn55.ImageIndex = 5;
                btn55.Visible = false;
                btn5.Visible = false;
                click = 0; five = 0; fiveclose = 0;
            }

            if (fiveclose <= 1 && click > 2)
            {

                btn1.ImageIndex = 4;
                btn11.ImageIndex = 4;
                btn2.ImageIndex = 4;
                btn22.ImageIndex = 4;
                btn3.ImageIndex = 4;
                btn33.ImageIndex = 4;
                btn4.ImageIndex = 4;
                btn44.ImageIndex = 4;
                btn5.ImageIndex = 4;
                btn55.ImageIndex = 4;
                btn6.ImageIndex = 4;
                btn66.ImageIndex = 4;
                btn7.ImageIndex = 4;
                btn77.ImageIndex = 4;
                btn8.ImageIndex = 4;
                btn88.ImageIndex = 4;
                click = 0;
                five = 0;
                fiveclose = 0;
                this.CloseButton();
            }
            if (fiveclose > 1)
            {
                btn5.ImageIndex = 4;
                five = 0;
                click = 0;
                fiveclose = 0;
            }
            if (click == 0)
            {
                btn1.ImageIndex = 4;
                btn11.ImageIndex = 4;
                btn2.ImageIndex = 4;
                btn22.ImageIndex = 4;
                btn3.ImageIndex = 4;
                btn33.ImageIndex = 4;
                btn4.ImageIndex = 4;
                btn44.ImageIndex = 4;
                btn5.ImageIndex = 4;
                btn55.ImageIndex = 4;
                btn6.ImageIndex = 4;
                btn66.ImageIndex = 4;
                btn7.ImageIndex = 4;
                btn77.ImageIndex = 4;
                btn8.ImageIndex = 4;
                btn88.ImageIndex = 4;
                this.CloseButton();
            }
        }

        private void btn55_Click(object sender, EventArgs e)
        {
            fifteenclose++;
            five++;
            click++;
            btn55.ImageIndex = 5;



            if (fifteenclose <= 1 && five == 2 && click == 2)
            {

                btn5.ImageIndex = 5;
                btn55.Visible = false;
                btn5.Visible = false;
                click = 0; five = 0; fifteenclose = 0;
            }

            if (fifteenclose <= 1 && click > 2)
            {

                btn1.ImageIndex = 4;
                btn11.ImageIndex = 4;
                btn2.ImageIndex = 4;
                btn22.ImageIndex = 4;
                btn3.ImageIndex = 4;
                btn33.ImageIndex = 4;
                btn4.ImageIndex = 4;
                btn44.ImageIndex = 4;
                btn5.ImageIndex = 4;
                btn55.ImageIndex = 4;
                btn6.ImageIndex = 4;
                btn66.ImageIndex = 4;
                btn7.ImageIndex = 4;
                btn77.ImageIndex = 4;
                btn8.ImageIndex = 4;
                btn88.ImageIndex = 4;
                click = 0;
                five = 0;
                fifteenclose = 0;
                this.CloseButton();
            }
            if (fifteenclose > 1)
            {
                btn55.ImageIndex = 4;
                five = 0;
                click = 0;
                fifteenclose = 0;
            }
            if (click == 0)
            {
                btn1.ImageIndex = 4;
                btn11.ImageIndex = 4;
                btn2.ImageIndex = 4;
                btn22.ImageIndex = 4;
                btn3.ImageIndex = 4;
                btn33.ImageIndex = 4;
                btn4.ImageIndex = 4;
                btn44.ImageIndex = 4;
                btn5.ImageIndex = 4;
                btn55.ImageIndex = 4;
                btn6.ImageIndex = 4;
                btn66.ImageIndex = 4;
                btn7.ImageIndex = 4;
                btn77.ImageIndex = 4;
                btn8.ImageIndex = 4;
                btn88.ImageIndex = 4;
                this.CloseButton();
            }
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            sixclose++;
            six++;
            click++;
            btn6.ImageIndex = 6;



            if (sixclose <= 1 && six == 2 && click == 2)
            {

                btn66.ImageIndex = 6;
                btn66.Visible = false;
                btn6.Visible = false;
                click = 0; six = 0; sixclose = 0;
            }

            if (sixclose <= 1 && click > 2)
            {

                btn1.ImageIndex = 4;
                btn11.ImageIndex = 4;
                btn2.ImageIndex = 4;
                btn22.ImageIndex = 4;
                btn3.ImageIndex = 4;
                btn33.ImageIndex = 4;
                btn4.ImageIndex = 4;
                btn44.ImageIndex = 4;
                btn5.ImageIndex = 4;
                btn55.ImageIndex = 4;
                btn6.ImageIndex = 4;
                btn66.ImageIndex = 4;
                btn7.ImageIndex = 4;
                btn77.ImageIndex = 4;
                btn8.ImageIndex = 4;
                btn88.ImageIndex = 4;
                click = 0;
                six = 0;
                sixclose = 0;
                this.CloseButton();
            }
            if (sixclose > 1)
            {
                btn1.ImageIndex = 4;
                six = 0;
                click = 0;
                sixclose = 0;
            }
            if (click == 0)
            {
                btn1.ImageIndex = 4;
                btn11.ImageIndex = 4;
                btn2.ImageIndex = 4;
                btn22.ImageIndex = 4;
                btn3.ImageIndex = 4;
                btn33.ImageIndex = 4;
                btn4.ImageIndex = 4;
                btn44.ImageIndex = 4;
                btn5.ImageIndex = 4;
                btn55.ImageIndex = 4;
                btn6.ImageIndex = 4;
                btn66.ImageIndex = 4;
                btn7.ImageIndex = 4;
                btn77.ImageIndex = 4;
                btn8.ImageIndex = 4;
                btn88.ImageIndex = 4;
                this.CloseButton();
            }
        }

        private void btn66_Click(object sender, EventArgs e)
        {
            sixteenclose++;
            six++;
            click++;
            btn66.ImageIndex = 6;



            if (sixteenclose <= 1 && six == 2 && click == 2)
            {

                btn6.ImageIndex = 6;
                btn66.Visible = false;
                btn6.Visible = false;
                click = 0; six = 0; sixteenclose = 0;
            }

            if (sixteenclose <= 1 && click > 2)
            {

                btn1.ImageIndex = 4;
                btn11.ImageIndex = 4;
                btn2.ImageIndex = 4;
                btn22.ImageIndex = 4;
                btn3.ImageIndex = 4;
                btn33.ImageIndex = 4;
                btn4.ImageIndex = 4;
                btn44.ImageIndex = 4;
                btn5.ImageIndex = 4;
                btn55.ImageIndex = 4;
                btn6.ImageIndex = 4;
                btn66.ImageIndex = 4;
                btn7.ImageIndex = 4;
                btn77.ImageIndex = 4;
                btn8.ImageIndex = 4;
                btn88.ImageIndex = 4;
                click = 0;
                six = 0;
                sixteenclose = 0;
                this.CloseButton();
            }
            if (sixteenclose > 1)
            {
                btn66.ImageIndex = 4;
                six = 0;
                click = 0;
                sixteenclose = 0;
            }
            if (click == 0)
            {
                btn1.ImageIndex = 4;
                btn11.ImageIndex = 4;
                btn2.ImageIndex = 4;
                btn22.ImageIndex = 4;
                btn3.ImageIndex = 4;
                btn33.ImageIndex = 4;
                btn4.ImageIndex = 4;
                btn44.ImageIndex = 4;
                btn5.ImageIndex = 4;
                btn55.ImageIndex = 4;
                btn6.ImageIndex = 4;
                btn66.ImageIndex = 4;
                btn7.ImageIndex = 4;
                btn77.ImageIndex = 4;
                btn8.ImageIndex = 4;
                btn88.ImageIndex = 4;
                this.CloseButton();
            }
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            sevenclose++;
            seven++;
            click++;
            btn7.ImageIndex = 7;



            if (sevenclose <= 1 && seven == 2 && click == 2)
            {

                btn77.ImageIndex = 7;
                btn77.Visible = false;
                btn7.Visible = false;
                click = 0; seven = 0; sevenclose = 0;
            }

            if (sevenclose <= 1 && click > 2)
            {

                btn1.ImageIndex = 4;
                btn11.ImageIndex = 4;
                btn2.ImageIndex = 4;
                btn22.ImageIndex = 4;
                btn3.ImageIndex = 4;
                btn33.ImageIndex = 4;
                btn4.ImageIndex = 4;
                btn44.ImageIndex = 4;
                btn5.ImageIndex = 4;
                btn55.ImageIndex = 4;
                btn6.ImageIndex = 4;
                btn66.ImageIndex = 4;
                btn7.ImageIndex = 4;
                btn77.ImageIndex = 4;
                btn8.ImageIndex = 4;
                btn88.ImageIndex = 4;
                click = 0;
                seven = 0;
                sevenclose = 0;
                this.CloseButton();
            }
            if (sevenclose > 1)
            {
                btn7.ImageIndex = 4;
                seven = 0;
                click = 0;
                sevenclose = 0;
            }
            if (click == 0)
            {
                btn1.ImageIndex = 4;
                btn11.ImageIndex = 4;
                btn2.ImageIndex = 4;
                btn22.ImageIndex = 4;
                btn3.ImageIndex = 4;
                btn33.ImageIndex = 4;
                btn4.ImageIndex = 4;
                btn44.ImageIndex = 4;
                btn5.ImageIndex = 4;
                btn55.ImageIndex = 4;
                btn6.ImageIndex = 4;
                btn66.ImageIndex = 4;
                btn7.ImageIndex = 4;
                btn77.ImageIndex = 4;
                btn8.ImageIndex = 4;
                btn88.ImageIndex = 4;
                this.CloseButton();
            }
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            eightclose++;
            eight++;
            click++;
            btn8.ImageIndex = 8;



            if (eightclose <= 1 && eight == 2 && click == 2)
            {

                btn88.ImageIndex = 8;
                btn88.Visible = false;
                btn8.Visible = false;
                click = 0; eight = 0; eightclose = 0;
            }

            if (eightclose <= 1 && click > 2)
            {

                btn1.ImageIndex = 4;
                btn11.ImageIndex = 4;
                btn2.ImageIndex = 4;
                btn22.ImageIndex = 4;
                btn3.ImageIndex = 4;
                btn33.ImageIndex = 4;
                btn4.ImageIndex = 4;
                btn44.ImageIndex = 4;
                btn5.ImageIndex = 4;
                btn55.ImageIndex = 4;
                btn6.ImageIndex = 4;
                btn66.ImageIndex = 4;
                btn7.ImageIndex = 4;
                btn77.ImageIndex = 4;
                btn8.ImageIndex = 4;
                btn88.ImageIndex = 4;
                click = 0;
                eight = 0;
                eightclose = 0;
                this.CloseButton();
            }
            if (eightclose > 1)
            {
                btn8.ImageIndex = 4;
                eight = 0;
                click = 0;
                eightclose = 0;
            }
            if (click == 0)
            {
                btn1.ImageIndex = 4;
                btn11.ImageIndex = 4;
                btn2.ImageIndex = 4;
                btn22.ImageIndex = 4;
                btn3.ImageIndex = 4;
                btn33.ImageIndex = 4;
                btn4.ImageIndex = 4;
                btn44.ImageIndex = 4;
                btn5.ImageIndex = 4;
                btn55.ImageIndex = 4;
                btn6.ImageIndex = 4;
                btn66.ImageIndex = 4;
                btn7.ImageIndex = 4;
                btn77.ImageIndex = 4;
                btn8.ImageIndex = 4;
                btn88.ImageIndex = 4;
                this.CloseButton();
            }
        }

        private void btn77_Click(object sender, EventArgs e)
        {
            seventeenclose++;
            seven++;
            click++;
            btn77.ImageIndex = 7;



            if (seventeenclose <= 1 && seven == 2 && click == 2)
            {

                btn7.ImageIndex = 7;
                btn77.Visible = false;
                btn7.Visible = false;
                click = 0; seven = 0; seventeenclose = 0;
            }

            if (seventeenclose <= 1 && click > 2)
            {

                btn1.ImageIndex = 4;
                btn11.ImageIndex = 4;
                btn2.ImageIndex = 4;
                btn22.ImageIndex = 4;
                btn3.ImageIndex = 4;
                btn33.ImageIndex = 4;
                btn4.ImageIndex = 4;
                btn44.ImageIndex = 4;
                btn5.ImageIndex = 4;
                btn55.ImageIndex = 4;
                btn6.ImageIndex = 4;
                btn66.ImageIndex = 4;
                btn7.ImageIndex = 4;
                btn77.ImageIndex = 4;
                btn8.ImageIndex = 4;
                btn88.ImageIndex = 4;
                click = 0;
                seven = 0;
                seventeenclose = 0;
                this.CloseButton();
            }
            if (seventeenclose > 1)
            {
                btn77.ImageIndex = 4;
                seven = 0;
                click = 0;
                seventeenclose = 0;
            }
            if (click == 0)
            {
                btn1.ImageIndex = 4;
                btn11.ImageIndex = 4;
                btn2.ImageIndex = 4;
                btn22.ImageIndex = 4;
                btn3.ImageIndex = 4;
                btn33.ImageIndex = 4;
                btn4.ImageIndex = 4;
                btn44.ImageIndex = 4;
                btn5.ImageIndex = 4;
                btn55.ImageIndex = 4;
                btn6.ImageIndex = 4;
                btn66.ImageIndex = 4;
                btn7.ImageIndex = 4;
                btn77.ImageIndex = 4;
                btn8.ImageIndex = 4;
                btn88.ImageIndex = 4;
                this.CloseButton();
            }
        }

        private void btn88_Click(object sender, EventArgs e)
        {
            eighteenclose++;
            eight++;
            click++;
            btn88.ImageIndex = 8;



            if (eighteenclose <= 1 && eight == 2 && click == 2)
            {

                btn8.ImageIndex = 8;
                btn88.Visible = false;
                btn8.Visible = false;
                click = 0; eight = 0; eighteenclose = 0;
            }

            if (eighteenclose <= 1 && click > 2)
            {

                btn1.ImageIndex = 4;
                btn11.ImageIndex = 4;
                btn2.ImageIndex = 4;
                btn22.ImageIndex = 4;
                btn3.ImageIndex = 4;
                btn33.ImageIndex = 4;
                btn4.ImageIndex = 4;
                btn44.ImageIndex = 4;
                btn5.ImageIndex = 4;
                btn55.ImageIndex = 4;
                btn6.ImageIndex = 4;
                btn66.ImageIndex = 4;
                btn7.ImageIndex = 4;
                btn77.ImageIndex = 4;
                btn8.ImageIndex = 4;
                btn88.ImageIndex = 4;
                click = 0;
                eight = 0;
                eighteenclose = 0;
                this.CloseButton();
            }
            if (eighteenclose > 1)
            {
                btn88.ImageIndex = 4;
                eight = 0;
                click = 0;
                eighteenclose = 0;
            }
            if (click == 0)
            {
                btn1.ImageIndex = 4;
                btn11.ImageIndex = 4;
                btn2.ImageIndex = 4;
                btn22.ImageIndex = 4;
                btn3.ImageIndex = 4;
                btn33.ImageIndex = 4;
                btn4.ImageIndex = 4;
                btn44.ImageIndex = 4;
                btn5.ImageIndex = 4;
                btn55.ImageIndex = 4;
                btn6.ImageIndex = 4;
                btn66.ImageIndex = 4;
                btn7.ImageIndex = 4;
                btn77.ImageIndex = 4;
                btn8.ImageIndex = 4;
                btn88.ImageIndex = 4;
                this.CloseButton();
            }
        }

    }
}
