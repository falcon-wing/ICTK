using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecIotAgent.Forms
{
    public partial class FingerAuthForm : Form
    {
        private Point point = new Point();
        public FingerAuthForm()
        {
            InitializeComponent();

            label2.BackColor = Color.Transparent;
        }

        private void FingerAuthForm_MouseDown(object sender, MouseEventArgs e)
        {
            point = new Point(e.X, e.Y);
        }

        private void FingerAuthForm_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                this.Location = new Point(this.Left - (point.X - e.X), this.Top - (point.Y - e.Y));
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("인증 작업을 취소합니다. 인증 작업을 다시 시도해 주세요.");
            this.Close();
        }

        private void FingerAuthForm_Paint(object sender, PaintEventArgs e)
        {
            Rectangle borderRectangle = this.ClientRectangle;
            borderRectangle.Inflate(-10, -10);
            ControlPaint.DrawBorder3D(e.Graphics, borderRectangle,
                Border3DStyle.Raised);
        
        }
    }
}
