using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecIotAgent.CMD
{
    public class VideoMettingPlatform
    {
        /// <summary>
        /// 사용자 아이디/비밀번호를 이용한 화상회의 플랫폼과의 인증 작업 진행
        /// 인증 성공 시 인증 TOKEN을 전달 받는다
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="UserPW"></param>
        /// <returns>token</returns>
        public byte[]? Authentication(string UserID, string UserPW)
        {
            byte[] bytes = null;
            
            // 화상회의 플랫폼과의 통신 API 전달 받아 작업 진행 예정

            return bytes;
        }
    }

    public class CertificateServer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AuthToken"></param>
        /// <returns></returns>
        public bool SendAuthTokenToCertificateServer(byte[] AuthToken)
        {
            return false;
        }

        /// <summary>
        /// Client (web) 에서 미디어키 요청 시 인증서버에 요청
        /// RoomCode를 받는건지 확인 해봐야 함
        /// </summary>
        /// <param name="RoomCode"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public byte[] ?RequestNewMediaKey(string UserID, string RoomCode = "")
        {
            byte[] MediaKey = null;

            // 미디어 키의 생성을 인증서버에 요청한다.

            return MediaKey;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AuthToken"></param>
        /// <returns></returns>
        public bool RegisterUsb(byte[] AuthToken)
        {
            return false;
        }
    }

    public class PUFDongle
    {
        /// <summary>
        /// 지문 등록을 진행한다.
        /// </summary>
        /// <returns></returns>
        public bool FingerprintRegistration()
        { 
            return false; 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool FingerprintInitialization()
        {
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool PufDongleInitilization()
        {
            return false;
        }

        /// <summary>
        /// 인증서 정보를 PUF에서 읽어온다.
        /// </summary>
        /// <returns></returns>
        public byte[]? GetCertificateInformation()
        {
            byte[] CertData = null;

            return CertData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte[]? GetPrkInformation()
        {
            byte [] PrkData = null;

            return PrkData;
        }
    }

    internal class Central_ProcessingClass
    {
        VideoMettingPlatform VideoMetting = new VideoMettingPlatform();
        CertificateServer certificateServer = new CertificateServer();
        PUFDongle pufDongle = new PUFDongle();

        //
        /* web */
        //
        /*--------------------------------------------------------------------------*/

        /// <summary>
        /// Client (web)에서의 서버 접속 상태 요청 시 상태 정보를 전달한다.
        /// </summary>
        //
        public bool GetSocketStatus()
        {
            return false;
        }

        /// <summary>
        /// Client (web)에서 로그인을 요청하거나, Agent 자체적으로 로그인 작업을 진행 할 시 로그인 작업을 진행한다.
        /// 로그인 하기위해서 화상 서버와 통신한다.
        /// 로그인 성공시 Token 정보를 전달 받는다
        /// </summary>
        public byte[]? RequestServerAuthentication(string UserId, string UserPW )
        {
            return VideoMetting.Authentication(UserId, UserPW);
        }

        /// <summary>
        /// USB의 정보를 인증서버에 저장한다.
        /// 여기서 인증서를 전달하는가?
        /// </summary>
        /// <returns></returns>
        public bool RegistryUSBOnAuthenticationServer(byte[] AuthToken)
        {
            return certificateServer.RegisterUsb(AuthToken);
        }


        /// <summary>
        /// MediaKey 를 요청하는 작업을 진행한다. 
        /// 전달하는 데이터는 어떤 데이터를 줘야 할지?
        /// </summary>
        /// <returns></returns>
        public byte[]? RequestMediaKeyToAuthenticationServer(string UserID,string RoomCode = "")
        {
            return certificateServer.RequestNewMediaKey(UserID, RoomCode);
        }

        //
        /* finger print */
        //
        /*--------------------------------------------------------------------------*/

        /// <summary>
        /// 지문을 등록하는 작업을 진행 한다.
        /// </summary>
        /// <returns></returns>
        public bool RegistryUserFingerPrint()
        {
            return pufDongle.FingerprintRegistration();
        }

        /// <summary>
        /// AC의 초기화 작업이 성공한 후 작업 진행 한다.
        /// 지문만 초기화 하거나 전체 초기화 작업을 진행 할때 모두 사용
        /// </summary>
        /// <returns></returns>
        public bool InitFingerPrint()
        {
            return pufDongle.FingerprintInitialization();
        }


        //
        /* PUF */
        //
        /*--------------------------------------------------------------------------*/

        /// <summary>
        /// Client (web) 요청에 따라 PUF내의 인증서 정보를 전달한다.
        /// </summary>
        /// <returns></returns>
        public byte[]? GetCertData()
        {
            return pufDongle.GetCertificateInformation();
        }

        /// <summary>
        /// Client (web) 요청에 따라 PUF내의 PRK 정보를 전달한다.
        /// </summary>
        /// <returns></returns>
        public byte[]? GetPUF_PRK()
        {
            return pufDongle.GetPrkInformation();
        }

        /// <summary>
        /// PUF 정보를 초기화 한다? 인증서 및 키 값 초기화 이외에 추가적인 내용 있는가?
        /// (INIT_MASTER_KEY_SEED : 초기화 키, VERIFY-INIT-AC-KEY : 초기화 AC 저장) <== 관련 있는가?
        /// </summary>
        /// <returns></returns>
        public bool InitPuf ()
        {
            return pufDongle.PufDongleInitilization();
        }
    }
}
