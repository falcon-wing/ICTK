using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace SecIotAgent.Forms
{
    public partial class AuthServerConnectForm : Form
    {
        private int timerCount = 0;

        public AuthServerConnectForm()
        {
            InitializeComponent();

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            progressBar1.MarqueeAnimationSpeed = 30;
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Step = 1;
            progressBar1.Value = 0;
        
            timer1.Start();

            ProgressStatlabel.Text = "인증서버에 등록 작업을 진행 중입니다.";



        }

        private void AuthServerConnectForm_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //label1.Text += "."; 
            if (++timerCount == 100) 
            {
                timer1.Stop();
                progressBar1.Enabled = false; 
                this.Close(); 
            }
        
        }
    }
}
