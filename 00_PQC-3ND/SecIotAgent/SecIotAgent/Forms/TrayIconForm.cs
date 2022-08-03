using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SecIotAgent.Common;
using System.Diagnostics;
using SecIotAgent.Forms;

using MaterialSkin;
using MaterialSkin.Controls;



namespace SecIotAgent.Forms
{
    public partial class TrayIconForm : MaterialForm
    {
        Logs common = new Logs();
        MainFormV2 mainFormV2 = new MainFormV2();

        public int ThemeType = 0;

      //  MainFormV2 mainFormV2;
        public TrayIconForm()
        {
            InitializeComponent();

            MaterialSkinManager  materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            //materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Green900, MaterialSkin.Primary.BlueGrey900, MaterialSkin.Primary.Blue500, MaterialSkin.Accent.Orange700, MaterialSkin.TextShade.WHITE);

            //green
            /*
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Green800, Primary.Green900, Primary.Green500, Accent.Orange400, TextShade.WHITE);
            */
            //grey
             //materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            // pink
            materialSkinManager.ColorScheme = new ColorScheme(Primary.DeepOrange300, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);


            // materialSkinManager.EnforceBackcolorOnAllComponents = false;
            // materialSkinManager.Theme = materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? MaterialSkinManager.Themes.LIGHT : MaterialSkinManager.Themes.DARK;

            //mainFormV2 = new MainFormV2();
            mainFormV2.SetTheme(0);
            mainFormV2.Show();
            this.Hide();
            this.Opacity = 0;
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == (MouseButtons.Left))
            {
                foreach (Form frm in Application.OpenForms)
                {
                    if (frm.Name == "MainFormV2")
                    {
                        frm.Activate();
                        frm.Visible = true;
                    }

                    return;
                }

                new MainFormV2().Show();
            }
        }

        private void notifyIcon_HOME_Click(object sender, EventArgs e)
        {
            common.GetEnvironment();
            string strBrowser = common.WebBrowser;
            string strWebSite = common.SiteUrl;
            string strWebStartSubCmd = $"/c start " + strBrowser + ":http//" + strWebSite;

            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name == "MainFormV2")
                {
                    frm.Activate();
                    frm.Visible = true;
                }

                return;
            }

            new MainFormV2().Show();
        }

        private void notifyIcon_LOGIN_Click(object sender, EventArgs e)
        {
            new LoginForm().ShowDialog();
        }

        private void notifyIcon_LOGOUT_Click(object sender, EventArgs e)
        {

        }

        private void notifyIcon_INFORMATION_Click(object sender, EventArgs e)
        {
            new InformationForm().ShowDialog();
        }

        private void notifyIcon_EXIT_Click(object sender, EventArgs e)
        {

        }
    }
}
