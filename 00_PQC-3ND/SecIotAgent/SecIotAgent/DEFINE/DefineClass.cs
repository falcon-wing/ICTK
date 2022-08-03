using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecIotAgent.DEFINE
{
    /// <summary>
    /// ENUM, STRUCT, FONT 및 정의된 정보를 포함 한 Class 입니다.
    /// </summary>
    internal class DefineClass
    {
        public enum FONT_SIZE
        {
            FONT_8 = 8,
            FONT_9 = 9,
            FONT_10 = 10,
            FONT_11 = 11,
            FONT_12 = 12,
            FONT_13 = 13,
            FONT_14 = 14,
            FONT_15 = 15,
            FONT_16 = 16,
            FONT_17 = 17,
            FONT_18 = 18,
            FONT_19 = 19,
            FONT_20 = 20,
        }

        public const string FontName_Malgun_Gothic  = "Malgun Gothic";
        public const string FontName_Default        = "Malgun Gothic";


        public static UInt32 WM_DEVICECHANGE          = 0x0219;
        public static UInt32 DBT_DEVTUP_VOLUME        = 0x02;
        public static UInt32 DBT_DEVICEARRIVAL        = 0x8000;
        public static UInt32 DBT_DEVICEREMOVECOMPLETE = 0x8004;

        

        /// <summary>
        /// 
        /// </summary>
        public struct FONT
        {
            /// <summary>
            /// Define Font
            /// </summary>

            public Font FormMainTitle_Size20;
            public Font FormMainTitle_Size20_B;

            public Font FormSubTitle_Size15;
            public Font FormSubTitle_Size15_B;

            public Font FormMessage_Size12;
            public Font FormMessage_Size12_B;

            public Font FormMessage_Size11;
            public Font FormMessage_Size11_B;

            public Font FormMessage_Size10;
            public Font FormMessage_Size10_B;

            public Font FormMessage_Size9;
            public Font FormMessage_Size9_B;

            /// <summary>
            /// 
            /// </summary>
            public FONT()
            {
                FormMainTitle_Size20 = new Font(FontName_Malgun_Gothic, (float)FONT_SIZE.FONT_20);
                FormMainTitle_Size20_B = new Font(FontName_Malgun_Gothic, (float)FONT_SIZE.FONT_20, FontStyle.Bold);

                FormSubTitle_Size15 = new Font(FontName_Default, (float)FONT_SIZE.FONT_15);
                FormSubTitle_Size15_B = new Font(FontName_Default, (float)FONT_SIZE.FONT_15, FontStyle.Bold);

                FormMessage_Size12 = new Font(FontName_Default, (float)FONT_SIZE.FONT_12);
                FormMessage_Size12_B = new Font(FontName_Default, (float)FONT_SIZE.FONT_12, FontStyle.Bold);

                FormMessage_Size11 = new Font(FontName_Default, (float)FONT_SIZE.FONT_11);
                FormMessage_Size11_B = new Font(FontName_Default, (float)FONT_SIZE.FONT_11, FontStyle.Bold);

                FormMessage_Size10 = new Font(FontName_Default, (float)FONT_SIZE.FONT_10);
                FormMessage_Size10_B = new Font(FontName_Default, (float)FONT_SIZE.FONT_10, FontStyle.Bold);

                FormMessage_Size9 = new Font(FontName_Default, (float)FONT_SIZE.FONT_9);
                FormMessage_Size9_B = new Font(FontName_Default, (float)FONT_SIZE.FONT_9, FontStyle.Bold);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        //Define Form Title 
        public const string MainFormTitleMsg                    = "제공 기능 한눈에 보기.";
        public const string DeviceTitleMsg                      = "Configure Device";
        public const string AuthenticationTitleMsg              = "Authentication";
        public const string RegiRegistrationTitleMsg            = "Registration";

        //Define Form Title sub msg
        ///MainForm
        public const string MainFormMainHelpMsg                 = "인증 및 설정 상태를 확인하고 필요한 작업을 수행하세요.";
        public const string MainForm_BtnMsg_Authentication      = "Authentication";
        public const string MainForm_BtnSubMsg_Authentication   = "인증 기능 및 상태보기";
        public const string MainForm_BtnMsg_ConfitureDevice     = "Configure Device";
        public const string MainForm_BtnSubMsg_ConfitureDevice  = "\'사용자\', \'장치\', \'지문\' 정보의 등록 및 관리";
        public const string MainForm_BtnMsg_ConfigureAppliation = "Configure Application";
        public string MainForm_BtnSubMsg_ConfigureAppliation    = "어플리케이션을 사용하기위한 \'사용자\', \'장치\', \'지문\' 정보의 등록 " + Environment.NewLine + "작업을 진행합니다.";
        public const string MainForm_BtnMsg_ViewLog             = "View Log";
        public string MainForm_BtnSubMsg_ViewLog                = "\'설정\',\'변경\',\'작업내역\' 등의" + Environment.NewLine + "로그내용을 확인 합니다.";

        ///AuthenticationForm
        public const string AuthenticationForm_SA_Msg                   = "Security Account";
        public const string AuthenticationForm_SA_Help_LoginYet_Msg     = "인증서버에 로그인하지 않았습니다.";
        public const string AuthenticationForm_SA_Help_LoginAlready_Msg = "인증서버에 로그인 되었습니다.";
        public const string AuthenticationForm_SA_Btn_Login_Msg         = "로그인하기";
        public const string AuthenticationForm_SA_VideoMettinng_Msg     = "화상회의 로그인을 위한 웹브라우저를 실행 합니다.";
        public const string AuthenticationForm_SA_VideoMettinng_Btn_Msg = "웹브라우저 실행하기";
        public const string AuthenticationForm_ServerStatus_Msg         = "Server Status (활성)";
        public const string AuthenticationForm_ServerStatus_Help_Msg    = "클라이언트에서 접속 가능합니다.";
        public const string AuthenticationForm_ServerStatus_Btn_Msg     = "서비스 재시작";

        ///RegistrationForm


        ///SettingForm


    }
}


/*
 DeviceTitlelabel.Text = "Configure Device";
            Titlelabel.Text = "Configure Application";
            SetLPHelpStringlabel.Text = "로그인 메뉴 선택시 호출할 웹페이지의 정보를 지정합니다.";
            SetRegHelpStringlabel.Text = "어플리케이션을 사용하기위한 \'사용자\', \'장치\', \'지문\' 정보의 등록 " + Environment.NewLine + "작업을 진행합니다.";
            SetInitHelpStringlabel.Text = "기 등록된 정보를 초기화 합니다." + Environment.NewLine + "초기화 작업 시 저장 정보가 삭제 됩니다.";
            Set_IPAddress_H_label.Text = "웹과 통신을 위한 Listen 아이피 정보를 지정합니다.";
            Set_Port_H_label.Text = "웹과 통신을 위한 PORT 정보를 지정합니다.";
            MainTitlelabel.Text = "제공 기능 한눈에 보기.";
            SubTitlelabel.Text = "인증 및 설정 상태를 확인하고 필요한 작업을 수행하세요.";
            SubMsgAuthlabel.Text = "인증기능 및 상태보기";
            SubMsgDevicelabel.Text = "\'사용자\',\'장치\',\'지문\' 정보의" + Environment.NewLine + "등록 및 관리";
            SubMsgSetlabel.Text = " 어플리케이션 사용을 위한" + Environment.NewLine + " 정보 설정 및 관리 작업을" + Environment.NewLine + " 진행 합니다";
            SubMsgLoglabel.Text = "\'설정\',\'변경\',\'작업내역\' 등의" + Environment.NewLine + "로그내용을 확인 합니다.";
            AuthMainTitlelabel.Text = "Authentication";
            ServerStatuslabel.Text = "Server Status (활성)";
            ServerStartlabel.Text = "서비스 재시작";
 */