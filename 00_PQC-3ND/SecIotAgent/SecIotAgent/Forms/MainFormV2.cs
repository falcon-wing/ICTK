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
using SecIotAgent.Common;
using SecIotAgent.PUF;
using System.Runtime.InteropServices;
using SecIotAgent.PROCESS;
using SecIotAgent.DEFINE;

namespace SecIotAgent.Forms
{
    public enum SKIN_INFO
    {
        SKIN_INFO_LIGHT = 0,
        SKIN_INFO_DARK = 1,
    }

    public partial class MainFormV2 : MaterialForm
    {
        private static readonly ICTK_PUF_Class iCTK_PUF_Class = new();
        ICTK_PUF_Class ictk_puf = iCTK_PUF_Class;
        ProcessClass ictk_process = new ProcessClass();

        Logs common = new();
        bool _systemShutdown = false;
        bool _bCheck_USB_Status = false;
        private MaterialSkinManager materialSkinManager;

        public enum LOGTAB_ITEM
        {
            LOGTAB_INDEX_TOTAL,
            LOGTAB_INDEX_NETWORK,
            LOGTAB_INDEX_DEVICE,
            LOGTAB_INDEX_ETC,
        }

        public enum DEVICETAB_ITEM
        {
            DEVICETAB_INDEX_REG,
            DEVICETAB_INDEX_AUTH,
            DEVICETAB_INDEX_RESET,
        }
        public int colorSchemeIndex;
        private int currentIndex = -1;

        public int LAST_CHG_MAININDEX = 0;

        private TrayIconForm? trayforminst = null;
        public int nItemAddCnt = 0, nInterval = 5,/* nLastLeftPos = 100*/ nSecondSavePos = 0;

        [DllImport("user32")]
        public static extern int GetClientRect(int hwnd, ref RECT lpRect);

#pragma warning disable CS8618 // 생성자를 종료할 때 null을 허용하지 않는 필드에 null이 아닌 값을 포함해야 합니다. null 허용으로 선언해 보세요.
        public MainFormV2()
#pragma warning restore CS8618 // 생성자를 종료할 때 null을 허용하지 않는 필드에 null이 아닌 값을 포함해야 합니다. null 허용으로 선언해 보세요.
        {
            InitializeComponent();
            LogOutPut((int)LOGTAB_ITEM.LOGTAB_INDEX_TOTAL, "TOTAL");

            if (!ictk_puf.PqcG3API_InitObject(ictk_puf.system_constant))
            {
                common.Log_info("Initialization of the system failed!.", (int)LOGINFO.INFO, (int)LOGINFO_FUNCTION.DEVICE);
                return;
            }
            else
            {
                common.Log_info("Successful system initialization is the result of all participating systems.", (int)LOGINFO.INFO, (int)LOGINFO_FUNCTION.DEVICE);
            }

            InitControl();
            seedListView();

            this.MinimumSize = new System.Drawing.Size(780, 768);
        }

        private void seedListView()
        {
            //Define
            var data = new[]
            {
                new []{"1", "교육", "제품 교육 진행", "2033-08-01 10:00 ~", "5 / 220"},
                new []{"2", "업무협의", "하반기 진행 업무 정의 및 협의", "2033-08-01 10:20 ~" , "0 / 220"},
                new []{"3", "주간보고", "8월 1주차 주간 업무", "2033-08-01 12:00 ~", "0 / 250"},
                new []{"4", "교육", "C# 개발 교육 진행", "2033-08-02 14:00 ~", "0 / 250"},
                new []{"5", "업무협의", "공공기관 보안 강화 방안 모색", "2033-08-09 10:00 ~" , "0 / 260"}
            };

            //MeetroomhistorylistView.SmallImageList = imageList3;
            // MeetroomhistorylistView.Items[0].ImageIndex = 1;
            int nItem = 1;
            //Add
            foreach (string[] version in data)
            {
                var item = new ListViewItem(version);
                // MeetroomhistorylistView.Items[1].ImageIndex = 2;
                item.ImageIndex = 1;
                MeetroomhistorylistView.Items.Add(item);
            }
        }

        public void InitControl()
        {
            common.MainForm_obj = this;
            ///
            // RESOURCE STRING 
            {
                DeviceTitlelabel.Text = Properties.Resources.STR_TITLE_DEVICE;
                Titlelabel.Text = Properties.Resources.STR_BTN_CONFIGUREAPPLIATION;
                SetLPHelpStringlabel.Text = Properties.Resources.STR_HELP_WEBBROWSER;
                SetRegHelpStringlabel.Text = Properties.Resources.STR_SUBMSG_CONFIGUREAPPLIATIONV2;
                SetInitHelpStringlabel.Text = Properties.Resources.STR_HELP_INIT_INFORMATION;
                Set_IPAddress_H_label.Text = Properties.Resources.STR_HELP_IPADDRESS;
                Set_Port_H_label.Text = Properties.Resources.STR_HELP_PORT;
                MainTitlelabel.Text = Properties.Resources.STR_TITLE_MAINFORM;
                SubTitlelabel.Text = Properties.Resources.STR_MSG_MAINHELP;
                SubMsgAuthlabel.Text = Properties.Resources.STR_SUBMSG_AUTHENTICATION;
                SubMsgDevicelabel.Text = Properties.Resources.STR_BTN_REGISTRATION_MSG;
                SubMsgSetlabel.Text = Properties.Resources.STR_SUBMSG_CONFIGUREAPPLIATION;
                SubMsgLoglabel.Text = Properties.Resources.STR_SUBMSG_VIEWLOG;
                AuthMainTitlelabel.Text = Properties.Resources.STR_TITLE_AUTHENTICATION;
                ServerStatuslabel.Text = Properties.Resources.STR_SERVERSTATUS_MSG;
                ServerStartlabel.Text = Properties.Resources.STR_BTN_SERVERSTATUS;
                IPAddresstextBox.PlaceholderText = Properties.Resources.STR_IPADDRESS_PLACEHOLDERTEXT;

                USB_Statgus_label.Text = Properties.Resources.STR_USB_DISCONNECTED;
            }

            ///CONTROL INIT
            {
                comboBox1.SelectedIndex = 0;
                Registration_comboBox.SelectedIndex = 0;
                Initialization_comboBox.SelectedIndex = 0;
                Authentication_metroTile.UseCustomBackColor = true;
                ConfigureDevice_metroTile.UseCustomBackColor = true;
                ConfigureApplication_metroTile.UseCustomBackColor = true;
                ViewLog_metroTile.UseCustomBackColor = true;
                VideoMetting_metroTile.UseCustomBackColor = true;

                FunTitleSetlabel.BringToFront();
                SubMsgSetlabel.BringToFront();
                materialTextBox1.Text = common.SiteUrl;
                USB_Status_pictureBox.Image = imageList1.Images[15];
            }

            ///TITLE VERSION PRINT
            {
                var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                this.Text = String.Format("Security Iot Device Agent {0}", version);
            }

            ///SET FONT
            {
                SetFontProcess();
            }

            {
                //MainMenuTabControl
                this.Home_tabPage.ToolTipText = "메인 화면을 보여줍니다.";
                this.Auth_tabPage.ToolTipText = "인증 관련 기능을 보여줍니다.";
            }

            SetHeight(MeetroomhistorylistView, 60);
            SetHeight(_totalLoglistView, 40);
            _totalLoglistView.Height = 60;
        }

        private void SetHeight(ListView LV, int height)
        {
            // listView 높이 지정     
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, height);
            LV.SmallImageList = imgList;
        }

        private void SetFontProcess()
        {
            DefineClass.FONT DefineFont = new DefineClass.FONT();

            Titlelabel.Font = DefineFont.FormMainTitle_Size20_B;
            DeviceTitlelabel.Font = DefineFont.FormMainTitle_Size20_B;
            AuthMainTitlelabel.Font = DefineFont.FormMainTitle_Size20_B;
            VideoMettingMainTitlelabel.Font = DefineFont.FormMainTitle_Size20_B;
            LogLookuptitlelabel.Font = DefineFont.FormMainTitle_Size20_B;

            Set_LPagelabel.Font = DefineFont.FormMessage_Size11_B;
            Set_uiskin_label.Font = DefineFont.FormMessage_Size10_B;
            RegTitlelabel.Font = DefineFont.FormMessage_Size10_B;

            SetLPHelpStringlabel.Font = DefineFont.FormMessage_Size10;
            SetRegHelpStringlabel.Font = DefineFont.FormMessage_Size10;
            SideTextlabel.Font = DefineFont.FormSubTitle_Size15_B;
            DeviceSidelabel.Font = DefineFont.FormSubTitle_Size15_B;

            ConnectRoomlabel.Font = DefineFont.FormSubTitle_Size15_B;
            Historylabel.Font = DefineFont.FormSubTitle_Size15_B;
            Reservationlabel.Font = DefineFont.FormSubTitle_Size15_B;

            InitTitlelabel.Font = DefineFont.FormMessage_Size10_B;
            SetInitHelpStringlabel.Font = DefineFont.FormMessage_Size10;

            Set_IPAddress_T_label.Font = DefineFont.FormMessage_Size10_B;
            Set_IPAddress_H_label.Font = DefineFont.FormMessage_Size10;

            Set_Port_T_label.Font = DefineFont.FormMessage_Size10_B;
            Set_Port_H_label.Font = DefineFont.FormMessage_Size10;

            MainTitlelabel.Font = DefineFont.FormMainTitle_Size20_B;
            SubTitlelabel.Font = DefineFont.FormMessage_Size10;

            TotalLogSublabel.Font = DefineFont.FormSubTitle_Size15_B;
            Networklogsublabel.Font = DefineFont.FormSubTitle_Size15_B;
            Etclogsublabel.Font = DefineFont.FormSubTitle_Size15_B;
            DevicelogSublabel.Font = DefineFont.FormSubTitle_Size15_B;

            FunTitleAuthlabel.Font = DefineFont.FormMessage_Size11_B;
            FunTitleDevicelabel.Font = DefineFont.FormMessage_Size11_B;
            FunTitleSetlabel.Font = DefineFont.FormMessage_Size11_B;
            FunTitleLoglabel.Font = DefineFont.FormMessage_Size11_B;
            RemoteVidoeTitlelabel.Font = DefineFont.FormMessage_Size11_B;

            SubMsgAuthlabel.Font = DefineFont.FormMessage_Size9;
            SubMsgDevicelabel.Font = DefineFont.FormMessage_Size9;
            SubMsgSetlabel.Font = DefineFont.FormMessage_Size9;
            SubMsgLoglabel.Font = DefineFont.FormMessage_Size9;
            SubMsgRemoteVideolabel.Font = DefineFont.FormMessage_Size9;

            Accountlabel.Font = DefineFont.FormSubTitle_Size15_B;
            AccountInfolabel.Font = DefineFont.FormMessage_Size10;
            LoginlinkLabel.Font = DefineFont.FormMessage_Size10;
            RunWebBrowserlabel.Font = DefineFont.FormMessage_Size10;

            ServerStatuslabel.Font = DefineFont.FormSubTitle_Size15_B;
            ServerStatusSublabel.Font = DefineFont.FormMessage_Size10;
            ServerStartlabel.Font = DefineFont.FormMessage_Size10;
            WebBrowserlinkLabel.Font = DefineFont.FormMessage_Size10;

            USB_Statgus_label.Font = DefineFont.FormMessage_Size9;
            MettingRoomURLlabel.Font = DefineFont.FormMessage_Size9;

            MeetroomhistorylistView.Font = DefineFont.FormMessage_Size10;
        }

        /// <summary>
        /// USB 연결 시 메인화면에 상태정보를 변경해준다.
        /// </summary>
        /// <param name="bConnected"></param>
        public void SetUsbConnectStatus(bool bConnected)
        {
            if (bConnected)
            {
                USB_Statgus_label.Text = Properties.Resources.STR_USB_CONNECTED;
                USB_Status_pictureBox.Image = imageList1.Images[14];
            }
            else
            {
                USB_Statgus_label.Text = Properties.Resources.STR_USB_DISCONNECTED;
                USB_Status_pictureBox.Image = imageList1.Images[15];
            }
        }

        /// <summary>
        /// 로그 내용을 출력합니다.
        /// </summary>
        /// <param name="LogTabType"></param>
        /// <param name="strFunc"></param>
        public void LogOutPut(int LogTabType, string strFunc)
        {
            if (LogTabType == (int)LOGTAB_ITEM.LOGTAB_INDEX_TOTAL)
            {
                this._totalLoglistView.Items.Clear();
            }
            else if (LogTabType == (int)LOGTAB_ITEM.LOGTAB_INDEX_NETWORK)
            {
                this._networkLoglistView.Items.Clear();
            }
            else if (LogTabType == (int)LOGTAB_ITEM.LOGTAB_INDEX_DEVICE)
            {
                this._deviceLoglistView.Items.Clear();
            }
            else if (LogTabType == (int)LOGTAB_ITEM.LOGTAB_INDEX_ETC)
            {
                this._etcLoglistView.Items.Clear();
            }

            if (common.LogPath == null)
            {
                common.GetEnvironment();
            }

            if (common.LogPath == null)
            {
                return;
            }

            string strFileName = common.LogPath;
            if (!System.IO.File.Exists(common.LogPath))
            {
            }
            else
            {
                string[] strValue = System.IO.File.ReadAllLines(strFileName);
                for (int iCnt = 0; iCnt < strValue.Length; iCnt++)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = (iCnt + 1).ToString();

                    string[] spstring = strValue[iCnt].Split('\t');
                    var listviewitem = new ListViewItem(spstring);

                    if (LogTabType == (int)LOGTAB_ITEM.LOGTAB_INDEX_TOTAL)
                    {
                        this._totalLoglistView.Items.Add(listviewitem);
                    }
                    else if (LogTabType == (int)LOGTAB_ITEM.LOGTAB_INDEX_NETWORK)
                    {
                        if (spstring[2] == Properties.Resources.STR_TAB_LOG_WEBSOCKET)
                        {
                            this._networkLoglistView.Items.Add(listviewitem);
                        }
                    }
                    else if (LogTabType == (int)LOGTAB_ITEM.LOGTAB_INDEX_DEVICE)
                    {
                        if (spstring[2] == Properties.Resources.STR_TAB_LOG_DEVICE)
                        {
                            this._deviceLoglistView.Items.Add(listviewitem);

                        }
                    }
                    else if (LogTabType == (int)LOGTAB_ITEM.LOGTAB_INDEX_ETC)
                    {
                        if (spstring[2] == Properties.Resources.STR_TAB_LOG_ETC)
                        {
                            this._etcLoglistView.Items.Add(listviewitem);
                        }
                    }
                }
            }
        }
        /*
                private void LogsTabControl_SelectedIndexChanged(object sender, EventArgs e)
                {
                    this.currentIndex = (sender as TabControl).SelectedIndex;

                    switch ((LOGTAB_ITEM)this.currentIndex)
                    {
                        case LOGTAB_ITEM.LOGTAB_INDEX_TOTAL:
                            // total log 
                            LogOutPut((int)LOGTAB_ITEM.LOGTAB_INDEX_TOTAL, Properties.Resources.STR_TAB_LOG_TOTAL);
                            break;
                        case LOGTAB_ITEM.LOGTAB_INDEX_NETWORK:
                            LogOutPut((int)LOGTAB_ITEM.LOGTAB_INDEX_NETWORK, Properties.Resources.STR_TAB_LOG_WEBSOCKET);
                            break;
                        case LOGTAB_ITEM.LOGTAB_INDEX_DEVICE:
                            LogOutPut((int)LOGTAB_ITEM.LOGTAB_INDEX_DEVICE, Properties.Resources.STR_TAB_LOG_DEVICE);
                            break;
                        case LOGTAB_ITEM.LOGTAB_INDEX_ETC:
                        default:
                            LogOutPut((int)LOGTAB_ITEM.LOGTAB_INDEX_ETC, Properties.Resources.STR_TAB_LOG_ETC);
                            break;
                    }
                }
        */
        private void BtnFingerAdmin_Click(object sender, EventArgs e)
        {
            this.materialTabControl1.SelectedIndex = 1;
            this.materialTabControl1.TabPages[1].Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.materialTabControl1.SelectedIndex = 2;
            this.materialTabControl1.TabPages[2].Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            new LoginForm().ShowDialog();
        }


        private void Button1_Click_1(object sender, EventArgs e)
        {
            if (ictk_process.AuthenticationUser() == true)
            {
                if (ictk_process.AuthenticationPUF_N_Finger() == true)
                {
                    MessageBox.Show("인증에 성공했습니다");
                }
            }
        }

        protected override void WndProc(ref Message m)
        {

            int wparm = m.WParam.ToInt32();

            if (m.Msg == DefineClass.WM_DEVICECHANGE)// && (m.WParam.ToInt32() == DBT_DEVICEARRIVAL)) || ((m.Msg == WM_DEVICECHANGE) && (m.WParam.ToInt32() == DBT_DEVICEREMOVECOMPLETE))) //디바이스 연결
            {
                if (_bCheck_USB_Status)
                {
                    if (ictk_puf.is_puf_connect() == false)
                    {
                        SetUsbConnectStatus(false);
                    }
                    else
                    {
                        SetUsbConnectStatus(true);
                    }
                }
            }

            base.WndProc(ref m);
        }


        private void btnRegistrationUSB_Click(object sender, EventArgs e)
        {
            new RegistrationUSBForm(materialSkinManager).ShowDialog();
        }

        private void MainFormV2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_systemShutdown) // 트레이 아이콘의 컨텍스트 메뉴를 통해 프로그램 종료가 선택된경우 true
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
                this.Visible = false; // 화면을 닫지 않고 단지 숨길 뿐이다.
            }
        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            string? sel = Registration_comboBox.SelectedItem.ToString();
            if (sel == "User")
            {
                new RegistrarotionUserForm().ShowDialog();
            }
            else if (sel == "Device & FingerPrint")
            {
                new RegistrationUSBForm(materialSkinManager).ShowDialog();
            }
            else
            {

            }
        }

        private void btnInitialization_Click(object sender, EventArgs e)
        {
            string? sel = Initialization_comboBox.SelectedItem.ToString();
            if (sel == "User")
            {
                MessageBox.Show("사용자 정보를 초기화 합니다.");
            }
            else if (sel == "Device")
            {
                MessageBox.Show("디바이스 정보를 초기화 합니다.");
            }
            else if (sel == "FingerPrint")
            {
                MessageBox.Show("사용자 지문 정보를 초기화 합니다.");
            }
            else if (sel == "Certification")
            {
                MessageBox.Show("인증서 정보를 초기화 합니다.");
            }
            else
            {

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int sel = comboBox1.SelectedIndex;
            switch ((SKIN_INFO)sel)
            {
                case SKIN_INFO.SKIN_INFO_DARK:
                    materialSkinManager.Theme = materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? MaterialSkinManager.Themes.LIGHT : MaterialSkinManager.Themes.DARK;
                    colorSchemeIndex = (int)SKIN_INFO.SKIN_INFO_DARK;
                    break;
                case SKIN_INFO.SKIN_INFO_LIGHT:
                    materialSkinManager.Theme = materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? MaterialSkinManager.Themes.LIGHT : MaterialSkinManager.Themes.LIGHT;
                    colorSchemeIndex = (int)SKIN_INFO.SKIN_INFO_LIGHT;
                    break;
                default:
                    materialSkinManager.Theme = materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? MaterialSkinManager.Themes.LIGHT : MaterialSkinManager.Themes.DARK;
                    colorSchemeIndex = (int)SKIN_INFO.SKIN_INFO_DARK;
                    break;

            }

            SetFontProcess();
        }

        public void SetTheme(int nType)
        {
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);

            switch ((SKIN_INFO)nType)
            {
                case SKIN_INFO.SKIN_INFO_DARK:
                    materialSkinManager.Theme = materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? MaterialSkinManager.Themes.LIGHT : MaterialSkinManager.Themes.DARK;
                    colorSchemeIndex = (int)SKIN_INFO.SKIN_INFO_DARK;
                    break;
                case SKIN_INFO.SKIN_INFO_LIGHT:
                    materialSkinManager.Theme = materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? MaterialSkinManager.Themes.LIGHT : MaterialSkinManager.Themes.LIGHT;
                    colorSchemeIndex = (int)SKIN_INFO.SKIN_INFO_LIGHT;
                    break;
                default:
                    materialSkinManager.Theme = materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? MaterialSkinManager.Themes.LIGHT : MaterialSkinManager.Themes.DARK;
                    colorSchemeIndex = (int)SKIN_INFO.SKIN_INFO_DARK;
                    break;
            }

            SetFontProcess();
        }

        private void VideoMetting_BTN_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 1;
            this.materialTabControl1.TabPages[1].Show();
        }

        private void Authentication_BTN_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 2;
            this.materialTabControl1.TabPages[2].Show();
        }

        private void FunTitleAuthlabel_Click(object sender, EventArgs e)        {            materialTabControl1.SelectedIndex = 2;            this.materialTabControl1.TabPages[2].Show();        }

        private void SubMsgAuthlabel_Click(object sender, EventArgs e)        {            materialTabControl1.SelectedIndex = 2;            this.materialTabControl1.TabPages[2].Show();        }

        
        private void ConfigureDevice_BTN_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 3;
            this.materialTabControl1.TabPages[3].Show();
        }

        private void ConfigureAPP_BTN_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 4;
            this.materialTabControl1.TabPages[4].Show();
        }

        private void FunTitleSetlabel_Click(object sender, EventArgs e)        {            materialTabControl1.SelectedIndex = 4;            this.materialTabControl1.TabPages[4].Show();        }

        private void SubMsgSetlabel_Click(object sender, EventArgs e)        {            materialTabControl1.SelectedIndex = 4;            this.materialTabControl1.TabPages[4].Show();        }


        private void Log_BTN_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 5;
            this.materialTabControl1.TabPages[5].Show();
        }

        private void listView_ColumnSizeAutoChange(ListView LV) 
        { 
            LV.Columns[^1].Width = -2; 
        }

        private void TotalLog_ListView_Resize(object sender, EventArgs e)
        {
            listView_ColumnSizeAutoChange((ListView)sender);
        }

        int nLAstPosion = 0;
        private void Home_tabPage_SizeChanged(object sender, EventArgs e)
        {
            int nFomSizeX = Home_tabPage.Width;
            int nItemSize = Authentication_metroTile.Width;
            int nItemCnt = (Home_tabPage.Width - 200) / Authentication_metroTile.Width;
            int nFixFirstItemXPos = VideoMetting_metroTile.Location.X;//100;
            int nFixFirstItemYPos = VideoMetting_metroTile.Location.Y;

            int nLastLeftPos = 100;
            nItemAddCnt = 0;
            nLAstPosion = 0;

            MetroFramework.Controls.MetroTile[] _metrotile = new MetroFramework.Controls.MetroTile[5] { VideoMetting_metroTile, Authentication_metroTile, ConfigureDevice_metroTile, ConfigureApplication_metroTile, ViewLog_metroTile, };
            if ((nLAstPosion > (_metrotile.Count() * nItemSize) || nItemCnt == 5) && nLAstPosion > 0)
            {
                return;
            }

            _metrotile[0].Location = new Point(nFixFirstItemXPos, nFixFirstItemYPos);
            nLastLeftPos = nLastLeftPos + VideoMetting_metroTile.Width + (nInterval * 2);
            int nLineCnt = 0;
            for (int i = 1; i < _metrotile.Count(); i++)
            {
                int nYPos = 0;
                if ((nLastLeftPos + (_metrotile[i].Width + nInterval)) > (Home_tabPage.Width))
                {
                    nLineCnt++;
                    nLastLeftPos = 100;
                    nLastLeftPos = nFixFirstItemXPos;
                }
                
                if (nLineCnt == 0)
                {
                    nYPos = nFixFirstItemYPos;
                }else
                {
                    nYPos = (_metrotile[nLineCnt].Location.Y + _metrotile[nLineCnt].Height) + nInterval;
                }

                if (nYPos == 0) {  nYPos = 200; }
                _metrotile[i].Location = new Point(nLastLeftPos, nYPos);
                nLastLeftPos += (_metrotile[i - 1].Width + nInterval);
                nItemAddCnt++;
                nLAstPosion = nLastLeftPos;
            }
            return;
        }

        private void ServerStartlabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ICTKPupWarpClass ictkwarp = new ICTKPupWarpClass();
            string strData = ictkwarp.GetPUF_Prk_by_string();
            MessageBox.Show(strData);

            materialTabControl1.SelectedIndex = 3;
            this.materialTabControl1.TabPages[3].Show();
        }

        private void USBChkToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (USBChkToggle.Checked == true)
            {
                // Connect
                _bCheck_USB_Status = true;
            }
            else
            {
                // Disconnect
                _bCheck_USB_Status = false;
            }
        }

        private void CheckCert_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //ICTKPupWarpClass ictkwarp = new ICTKPupWarpClass();
            //인증서 화면 출력
            new CertInfoForm().ShowDialog();
        }

        private void LogLockup_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.currentIndex = (sender as TabControl).SelectedIndex;

            switch ((LOGTAB_ITEM)this.currentIndex)
            {
                case LOGTAB_ITEM.LOGTAB_INDEX_TOTAL:
                    // total log 
                    LogOutPut((int)LOGTAB_ITEM.LOGTAB_INDEX_TOTAL, Properties.Resources.STR_TAB_LOG_TOTAL);
                    break;
                case LOGTAB_ITEM.LOGTAB_INDEX_NETWORK:
                    LogOutPut((int)LOGTAB_ITEM.LOGTAB_INDEX_NETWORK, Properties.Resources.STR_TAB_LOG_WEBSOCKET);
                    break;
                case LOGTAB_ITEM.LOGTAB_INDEX_DEVICE:
                    LogOutPut((int)LOGTAB_ITEM.LOGTAB_INDEX_DEVICE, Properties.Resources.STR_TAB_LOG_DEVICE);
                    break;
                case LOGTAB_ITEM.LOGTAB_INDEX_ETC:
                default:
                    LogOutPut((int)LOGTAB_ITEM.LOGTAB_INDEX_ETC, Properties.Resources.STR_TAB_LOG_ETC);
                    break;
            }
        }

        private void WebBrowserlinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ///web browser run
            /// common.GetEnvironment();
            string strBrowser = common.WebBrowser;
            string strWebSite = common.SiteUrl;
            string strWebStartSubCmd = $"/c start " + strBrowser + ":" + strWebSite;

            Process.Start(new ProcessStartInfo("cmd", strWebStartSubCmd) { CreateNoWindow = true });
        }

        private void Home_tabPage_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void LoginlinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ///
            new LoginV3Form().ShowDialog();
        }

        private void SettingSaveButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.webURL = this.materialTextBox1.Text;
            Properties.Settings.Default.Save();

            common.SiteUrl = this.materialTextBox1.Text;
            common.SetEnvironment();
        }
    }
}
