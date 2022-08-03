using System;
using System.Diagnostics;
using MaterialSkin;
using MaterialSkin.Controls;
using SecIotAgent.Common;

namespace SecIotAgent
{
    public partial class MainForm : MaterialForm
    {
        Logs common = new Logs();

        public enum LOGTAB_ITEM
        {
            LOGTAB_INDEX_TOTAL,
            LOGTAB_INDEX_NETWORK,
            LOGTAB_INDEX_DEVICE,
            LOGTAB_INDEX_ETC,
        }

        private int currentIndex = -1;
        
        public MainForm()
        {
            InitializeComponent();

            
            var meterialSkinManager = MaterialSkinManager.Instance;
            meterialSkinManager.AddFormToManage(this);
            meterialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            meterialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            LogOutPut((int)LOGTAB_ITEM.LOGTAB_INDEX_TOTAL, "TOTAL");

            /*
                        this.TotalLogmaterialListView.Items.Clear();
                        this.TotalLogmaterialListView.Items.Add("ddd");

                        this.EtcLogmaterialListView.Items.Clear();
                        this.EtcLogmaterialListView.Items.Add("444");

                        this.NetWorkLogmaterialListView.Items.Clear();
                        this.NetWorkLogmaterialListView.Items.Add("222");

                        this.DeviceLogmaterialListView.Items.Clear();
                        this.DeviceLogmaterialListView.Items.Add("333");
            */
        }

        private void materialTabControl2_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void materialTabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.currentIndex = (sender as TabControl).SelectedIndex;

            switch ((LOGTAB_ITEM)this.currentIndex)
            {
                case LOGTAB_ITEM.LOGTAB_INDEX_TOTAL:
                    // total log 
                    LogOutPut((int)LOGTAB_ITEM.LOGTAB_INDEX_TOTAL, "TOTAL");
                    break;
                case LOGTAB_ITEM.LOGTAB_INDEX_NETWORK:
                    LogOutPut((int)LOGTAB_ITEM.LOGTAB_INDEX_NETWORK, "WEBSOCKET");
                    break;
                case LOGTAB_ITEM.LOGTAB_INDEX_DEVICE:
                    LogOutPut((int)LOGTAB_ITEM.LOGTAB_INDEX_DEVICE, "DEVICE");
                    break;
                case LOGTAB_ITEM.LOGTAB_INDEX_ETC:
                default:
                    LogOutPut((int)LOGTAB_ITEM.LOGTAB_INDEX_ETC, "ETC");
                    break;

            }
           // MessageBox.Show()

            //switch()
        }

        public void LogOutPut(int LogTabType, string strFunc)
        {
            if (LogTabType == (int)LOGTAB_ITEM.LOGTAB_INDEX_TOTAL)
            {
              //  this.materialTabControl2.TabPages[0]
               // this.TotalLogListView.Items.Clear();
            }

            if (LogTabType == (int)LOGTAB_ITEM.LOGTAB_INDEX_TOTAL)
            {
                this.TotalLogmaterialListView.Items.Clear();
            }
            else if (LogTabType == (int)LOGTAB_ITEM.LOGTAB_INDEX_NETWORK)
            {
                this.NetWorkLogmaterialListView.Items.Clear();
            }
            else if (LogTabType == (int)LOGTAB_ITEM.LOGTAB_INDEX_DEVICE)
            {
                this.DeviceLogmaterialListView.Items.Clear();
            }
            else if (LogTabType == (int)LOGTAB_ITEM.LOGTAB_INDEX_ETC)
            {
                this.EtcLogmaterialListView.Items.Clear();
            }


            this.TotalLogmaterialListView.Items.Add("ddd");

            if (common.LogPath == null)
            {
                common.GetEnvironment();
            }

            if (common.LogPath == null)
            {
                return;
            }

            //common.Log_info("Start Log view form....", (int)LOGINFO.INFO, (int)LOGINFO_FUNCTION.ETC);

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
                    //LogListView.Items.Add(listviewitem);

                    if (LogTabType == (int)LOGTAB_ITEM.LOGTAB_INDEX_TOTAL)
                    { 
                        this.TotalLogmaterialListView.Items.Add(listviewitem);
                    }
                    else if (LogTabType == (int)LOGTAB_ITEM.LOGTAB_INDEX_NETWORK)
                    {
                        if (spstring[2] == "WEBSOCKET")
                        {
                            this.NetWorkLogmaterialListView.Items.Add(listviewitem);
                        }
                    }
                    else if (LogTabType == (int)LOGTAB_ITEM.LOGTAB_INDEX_DEVICE)
                    {
                        if (spstring[2] == "DEVICE")
                        {
                            this.DeviceLogmaterialListView.Items.Add(listviewitem);

                        }
                    }
                    else if (LogTabType == (int)LOGTAB_ITEM.LOGTAB_INDEX_ETC)
                    {
                        if (spstring[2] == "ETC")
                        {
                            this.EtcLogmaterialListView.Items.Add(listviewitem);
                        }
                    }
                }
            }
        }


        protected override void OnClosed(EventArgs e)
        {
            Hide();
        }

        private void DeviceLogmaterialListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        /*
private void contextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
{
   common.GetEnvironment();
   string strBrowser = common.WebBrowser;
   string strWebSite = common.SiteUrl;
   string strWebStartSubCmd = $"/c start " + strBrowser + ":http//" + strWebSite;

   if (e.ClickedItem != null && e.ClickedItem.ToString().Equals("Open Web Browser"))
   {
       Process.Start(new ProcessStartInfo("cmd", strWebStartSubCmd) { CreateNoWindow = true });
   }
   else if (e.ClickedItem != null && e.ClickedItem.ToString().Equals("TRAY_HOME"))
   {
       Show();
   }
   else if (e.ClickedItem != null && e.ClickedItem.ToString().Equals("TRAY_INFO"))
   {

   }
   else if (e.ClickedItem != null && e.ClickedItem.ToString().Equals("TRAY_EXIT"))
   {

   }
   else
   {

   }
}

*/
    }
}