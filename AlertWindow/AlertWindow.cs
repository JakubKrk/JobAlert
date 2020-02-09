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
using System.Diagnostics;

namespace JobAlert
{
    public partial class AlertWindow : Form
    {
        int newcount = 0;
        int curroffer = 0;
        string newcountstr = "";
        List<List<string>> myList = new List<List<string>>();

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;    // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }
        public AlertWindow()
        {
            InitializeComponent();
            this.ShowInTaskbar = true;
            this.TopMost = true;
            string curFile = @"temp.csv";
            if (File.Exists(curFile))
            {
                
                StreamReader sr = new StreamReader(@"temp.csv");
                // for set encoding

                string strline = "";
                string[] _values = null;
                int x = 0;
                while (!sr.EndOfStream)
                {


                    if (x == 0)
                    {
                        newcountstr = sr.ReadLine();
                        Int32.TryParse(newcountstr, out newcount);


                    }

                    if (x != 0)
                    {
                        strline = sr.ReadLine();
                        _values = strline.Split(';');
                        myList.Add(new List<string> { _values[0], _values[1], _values[2], _values[3], _values[4], _values[5], _values[6] });
                    }

                    x++;
                }
                sr.Close();

                pBox2.Visible = false;
                loadOfferInfo();

                System.IO.Stream str = Properties.Resources.sound_effect;
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(str);
                player.Play();

            }   
            else
            {
                System.Windows.Forms.Application.Exit();
            }
        }
        
        private void loadOfferInfo()
        {
            label1.Text = (curroffer + 1).ToString() + "/" + newcountstr;
            lTitle.Text = myList[curroffer][0] +"\n[" +myList[curroffer][1] + "]";
            
            lDate.Text = myList[curroffer][2];
            lSite.Text = myList[curroffer][3];
            lLocation.Text = myList[curroffer][4];
            lTag.Text = myList[curroffer][6];
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void drag_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void drag_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        
        Point lastPoint;

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        
        
       
          private void pBox1_MouseEnter(object sender, EventArgs e)
        {
            this.pBox1.Image = ((Image)(Properties.Resources.next_button_png_blue));
        }

        private void pBox1_MouseLeave_1(object sender, EventArgs e)
        {
            this.pBox1.Image = ((Image)(Properties.Resources.next_button_png));
        }

        private void pBox1_MouseDown(object sender, MouseEventArgs e)
        {
            this.pBox1.Image = ((Image)(Properties.Resources.next_button_png_light));
        }

        private void pBox1_MouseUp(object sender, MouseEventArgs e)
        {
            this.pBox1.Image = ((Image)(Properties.Resources.next_button_png_blue));;
        }

        private void pBox2_MouseDown(object sender, MouseEventArgs e)
        {
            this.pBox2.Image = ((Image)(Properties.Resources.prev_button_png_light));
        }

        private void pBox2_MouseEnter(object sender, EventArgs e)
        {
            this.pBox2.Image = ((Image)(Properties.Resources.prev_button_png_blue));
        }

        private void pBox2_MouseLeave(object sender, EventArgs e)
        {
            this.pBox2.Image = ((Image)(Properties.Resources.prev_button_png));
        }

        private void pBox2_MouseUp(object sender, MouseEventArgs e)
        {
            this.pBox2.Image = ((Image)(Properties.Resources.prev_button_png_blue));
         
        }

        private void pBoxExit_MouseMove(object sender, MouseEventArgs e)
        {
            this.pBoxExit.Image = ((Image)(Properties.Resources.Xred));
        }

        private void pBoxMinimize_MouseMove(object sender, MouseEventArgs e)
        {
            this.pBoxMinimize.Image = ((Image)(Properties.Resources.MinRed));
        }

        private void pBoxExit_MouseLeave(object sender, EventArgs e)
        {
            this.pBoxExit.Image = ((Image)(Properties.Resources.Xblack));
        }

        private void pBoxMinimize_MouseLeave(object sender, EventArgs e)
        {
            this.pBoxMinimize.Image = ((Image)(Properties.Resources.MinBlack));
        }

        private void pLink_MouseDown(object sender, MouseEventArgs e)
        {
            this.pLink.Image = ((Image)(Properties.Resources.link_light));

        }

        private void pLink_MouseEnter(object sender, EventArgs e)
        {
            this.pLink.Image = ((Image)(Properties.Resources.link_blue));
           
        }

        private void pLink_MouseLeave(object sender, EventArgs e)
        {
            this.pLink.Image = ((Image)(Properties.Resources.link));
        }

        private void pLink_MouseUp(object sender, MouseEventArgs e)
        {
            this.pLink.Image = ((Image)(Properties.Resources.link_blue));
        }

        private void pBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (curroffer + 1 < newcount)
            {
                curroffer++;
                loadOfferInfo();
            }
            if (curroffer + 1 == newcount)
            {
                pBox1.Visible = false;
            }
            if (curroffer > 0)
            {
                pBox2.Visible = true;
            }
        }

        private void pBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (curroffer > 0)
            {
                curroffer--;
                loadOfferInfo();

            }
            if (curroffer == 0)
            {
                pBox2.Visible = false;
            }
            if (curroffer + 1 < newcount)
            {
                pBox1.Visible = true;
            }
        }

        private void pLink_MouseClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start(myList[curroffer][5]);
        }

        private void pBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (curroffer + 1 < newcount)
            {
                curroffer++;
                loadOfferInfo();
            }
            if (curroffer + 1 == newcount)
            {
                pBox1.Visible = false;
            }
            if (curroffer > 0)
            {
                pBox2.Visible = true;
            }
        }

        private void pBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (curroffer > 0)
            {
                curroffer--;
                loadOfferInfo();

            }
            if (curroffer == 0)
            {
                pBox2.Visible = false;
            }
            if (curroffer + 1 < newcount)
            {
                pBox1.Visible = true;
            }
        }
    }
}
