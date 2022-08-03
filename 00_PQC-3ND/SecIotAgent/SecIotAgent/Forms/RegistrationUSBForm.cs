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
    public partial class RegistrationUSBForm : MaterialForm
    {
        int nTabIndex = 0;
        MainFormV2 mainFormv2 = new MainFormV2();
        public RegistrationUSBForm(MaterialSkinManager skin)
        { 
            InitializeComponent();

            /*
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            
            
            var Shade = TextShade.WHITE;
            if (mainFormv2.colorSchemeIndex == (int)SKIN_INFO.SKIN_INFO_DARK)
            {
                Shade = TextShade.BLACK;
            }else
            {
                Shade = TextShade.WHITE;
            }

            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;

            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            */
            
            //var materialSkinManager = skin;
            //materialSkinManager.AddFormToManage(this);

            this.Text = "REGISTRATION";

            Font regLabelft = new Font(fingerprintMsg_M_Label.Font.Name, 15, FontStyle.Bold);
            fingerprintMsg_M_Label.Font = regLabelft;
            fingerprintMsg_M_Label.Text = "지문 센서 터치";

            Font regSLabelft = new Font(fingerprintMsg_S_Label.Font.Name, 12);
            fingerprintMsg_S_Label.Font = regSLabelft;
            fingerprintMsg_S_Label.Text = "설정이 완료 될때까지 센서에 반복해서 손가락을 대고 떼세요.";

            fingerprint_RE_label.Font = regLabelft;
            fingerprint_RE_label.Text = "좋습니다. 센서를 다시 터치하세요.";

            fingerprint_Ret_M_label.Font = regLabelft;
            fingerprint_Ret_M_label.Text = "모두 설정되었습니다.";

            fingerprint_Ret_S_label.Font = regSLabelft;
            fingerprint_Ret_S_label.Text = "다음에 장치를 잠금 해제할 때 지문을 사용하세요.";

            LoginV3Form login = new LoginV3Form();//.ShowDialog();
           /* login.materialSkinManager = MaterialSkinManager.Instance; ;
            login.materialSkinManager.AddFormToManage(this);
            login.materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            login.materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
           */
            login.ShowDialog();

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            if (materialButton1.Text == "Fnish")
            {
                this.Close();
            }

            if (nTabIndex < (materialTabControl1.TabCount-1) )
            {
                nTabIndex++;

                if (nTabIndex == (materialTabControl1.TabCount - 1))
                {
                    new AuthServerConnectForm().ShowDialog();

                    materialButton1.Text = "Fnish";
                }

                materialTabControl1.SelectedTab = materialTabControl1.TabPages[nTabIndex];
            }
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            
            
            if (nTabIndex > 0 )
            {
                nTabIndex--;
                materialTabControl1.SelectedTab = materialTabControl1.TabPages[nTabIndex];

               
            }
        }
    }
}
