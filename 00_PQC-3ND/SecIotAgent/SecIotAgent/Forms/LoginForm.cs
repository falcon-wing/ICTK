using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using MaterialSkin;
using MaterialSkin.Controls;

namespace SecIotAgent.Forms
{
    public partial class LoginForm : Form
    {
        private Point point = new Point();
        
        public LoginForm()
        {
            InitializeComponent();

            Load += Form_Load;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            SetSize(this.LoginMsgmaterialLabel);
        }

        private void SetSize(Label label)
        {
            string text = label.Text;

            if (text.Length > 0)
            {
                int bestSize = 100;

                int width = label.DisplayRectangle.Width - 3;
                int height = label.DisplayRectangle.Height - 3;

                using (Graphics graphics = label.CreateGraphics())
                {
                    for (int i = 1; i <= 100; i++)
                    {
                        using (Font testFont = new Font(label.Font.FontFamily, i))
                        {
                            SizeF textSize = graphics.MeasureString(text, testFont);

                            if ((textSize.Width > width) || (textSize.Height > height))
                            {
                                bestSize = i - 1;

                                break;
                            }
                        }
                    }
                }

                label.Font = new Font(label.Font.FontFamily, bestSize);
            }
        }

        private void LoginForm_MouseDown(object sender, MouseEventArgs e)
        {
            point = new Point(e.X, e.Y);
        }

        private void LoginForm_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                this.Location = new Point(this.Left - (point.X - e.X), this.Top - (point.Y - e.Y));
            }
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
