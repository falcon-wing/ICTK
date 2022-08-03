using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecIotAgent.Forms;

namespace SecIotAgent.Common
{
    internal class Logs
    {

        /// <summary>
        /// </summary>
        public static MainFormV2 mainForm_obj;

        /// <summary>
        /// 
        /// </summary>
        public MainFormV2 MainForm_obj
        {
            get { return mainForm_obj; }
            set { mainForm_obj = value; }
        }

        private string? g_strRunWebBrowser;

        public string? LogPath { get; set; }

        public string SiteUrl { get; set; }

        public string WebBrowser
        {
            get { return g_strRunWebBrowser; }
            set { g_strRunWebBrowser = value; }
        }

        public bool SetEnvironment()
        {
            //bool bChkStat = false;

            Properties.Settings.Default.LogFullPath = LogPath;
            Properties.Settings.Default.webURL = SiteUrl;
            Properties.Settings.Default.RunWebBrowser = g_strRunWebBrowser;

            
            Properties.Settings.Default.Save();

            return true;
        }

        public bool GetEnvironment()
        {
            bool bChkStat = false;
            if (LogPath == null)
            {
                LogPath = Properties.Settings.Default.LogFullPath;
                if (String.IsNullOrEmpty(LogPath))
                {
                    LogPath = Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf("\\")) + "\\Log\\seclog.txt";

                    Properties.Settings.Default.LogFullPath = LogPath;
                    bChkStat = true;
                }
            }

            if (String.IsNullOrEmpty(SiteUrl))
            {
                SiteUrl = Properties.Settings.Default.webURL;
                if (String.IsNullOrEmpty(SiteUrl))
                {
                    SiteUrl = "http://localhost/";
                    Properties.Settings.Default.webURL = SiteUrl;

                    bChkStat = true;
                }

                if (!SiteUrl.Equals(Properties.Settings.Default.webURL))
                {
                    Properties.Settings.Default.webURL = SiteUrl;
                    bChkStat = true;
                }
            }

            if (String.IsNullOrEmpty(g_strRunWebBrowser))
            {
                g_strRunWebBrowser = Properties.Settings.Default.RunWebBrowser;
                if (String.IsNullOrEmpty(g_strRunWebBrowser))
                {
                    g_strRunWebBrowser = "microsoft-edge";
                    Properties.Settings.Default.RunWebBrowser = g_strRunWebBrowser;

                    bChkStat = true;
                }

                if (!g_strRunWebBrowser.Equals(Properties.Settings.Default.RunWebBrowser))
                {
                    Properties.Settings.Default.RunWebBrowser = g_strRunWebBrowser;
                    bChkStat = true;
                }
            }

            if (String.IsNullOrEmpty(LogPath))
            {
                LogPath = Properties.Settings.Default.LogFullPath;
                if (String.IsNullOrEmpty(LogPath))
                {
                    LogPath = Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf("\\")) + "\\Log\\seclog.txt";
                    Properties.Settings.Default.LogFullPath = LogPath;

                    bChkStat = true;
                }

                if (!LogPath.Equals(Properties.Settings.Default.LogFullPath))
                {
                    Properties.Settings.Default.LogFullPath = LogPath;
                    bChkStat = true;
                }
            }

            if (bChkStat)
            {
                Properties.Settings.Default.Save();
            }

            return true;
        }


        public bool Log_info(string strMsg, int nLogMode, int nFunction)
        {
            try
            {
                string strCheckFolder = "";
                string strFileName = "";
                string strLogMode = "";
                string strFunction = "";

                string strLocal = Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf("\\"));
                strCheckFolder = strLocal + "\\Log";

                if (LogPath == null)
                {
                    GetEnvironment();
                }

                if (!System.IO.Directory.Exists(strCheckFolder))
                {
                    System.IO.Directory.CreateDirectory(strCheckFolder);
                }

                switch ((LOGINFO)nLogMode)
                {
                    case LOGINFO.ERROR:
                        strLogMode = LOGINFO.ERROR.ToString();
                        break;
                    case LOGINFO.WARN:
                        strLogMode = LOGINFO.WARN.ToString();
                        break;
                    case LOGINFO.FATAL:
                        strLogMode = LOGINFO.FATAL.ToString();
                        break;
                    case LOGINFO.INFO:
                    default:
                        strLogMode = LOGINFO.INFO.ToString();
                        break;
                }

                switch ((LOGINFO_FUNCTION)nFunction)
                {
                    case LOGINFO_FUNCTION.DEVICE:
                        strFunction = LOGINFO_FUNCTION.DEVICE.ToString();
                        break;
                    case LOGINFO_FUNCTION.WEBSOCKET:
                        strFunction = LOGINFO_FUNCTION.WEBSOCKET.ToString();
                        break;
                    case LOGINFO_FUNCTION.ETC:
                    default:
                        strFunction = LOGINFO_FUNCTION.ETC.ToString();
                        break;
                }

                strFileName = LogPath;//strCheckFolder + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

                string LogFormat = strLogMode + "\t" + strFunction + "\t" + strMsg;
                LogFormat = LogFormat.Replace("\n", "");
                LogFormat = LogFormat.Replace("\r", "");

                System.IO.StreamWriter FileWrite = new System.IO.StreamWriter(strFileName, true);
                FileWrite.WriteLine(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "\t" + LogFormat);
                FileWrite.Flush();
                FileWrite.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
