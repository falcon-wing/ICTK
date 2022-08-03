using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pqcclrwrap;
using NeoLib.Util;
using System.Security.Cryptography;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SecIotAgent.PUF
{

    public struct OBJECT_TYPE_A
    {


    }

    public class ICTK_ALGORITHM
    {

        

        public static Byte[] aes_crypto(bool encdec, Byte[] key, Byte[] msg, Byte[] iv)
        {

#pragma warning disable SYSLIB0022 // 형식 또는 멤버는 사용되지 않습니다.
            RijndaelManaged aes = new RijndaelManaged();
#pragma warning restore SYSLIB0022 // 형식 또는 멤버는 사용되지 않습니다.
            aes.KeySize = 128;
            aes.BlockSize = 128;
            aes.Mode = CipherMode.CBC;
            aes.Key = key;
            aes.IV = iv;
            aes.Padding = PaddingMode.Zeros;

            var encrypt = encdec ? aes.CreateEncryptor() : aes.CreateDecryptor();

            byte[] ResultArray = encrypt.TransformFinalBlock(msg, 0, msg.Length);

            return ResultArray;
        }

        public static Byte[] sha_256(Byte[] msg)
        {
            SHA256 mySHA256 = SHA256.Create();

            byte[] hashValue = mySHA256.ComputeHash(msg);
            return hashValue;
        }
    }

    public class PUF_API_CLASS
    {
        /// <summary>
        /// </summary>
        public static PqcG3API? obj;

        /// <summary>
        /// 
        /// </summary>
        public PqcG3API Obj
        {
#pragma warning disable CS8603 // 가능한 null 참조 반환입니다.
            get => obj;
#pragma warning restore CS8603 // 가능한 null 참조 반환입니다.
            set { obj = value; }    
        }

       

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool chip_init()
        {
            if (obj is null)
                return false;

            obj.init();

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool chip_wakeup()
        {
            if (obj is null)
                return false;


            obj.wake_up();

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool chip_is_conncted()
        {
            if (obj is null)
                return false;

            return obj.IsConnected();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nsize"></param>
        /// <returns></returns>
        public byte[] chip_get_challenage_for_byte(int nsize)
        {
            if (obj is null)
                return null;

            return obj.get_challenge(nsize);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nsize"></param>
        /// <returns></returns>
        public string chip_get_challenage_for_string(int nsize)
        {
            if (obj is null)
                return String.Empty;

            var buffer = obj.get_challenge(nsize);

            return NeoHexString.ByteArrayToHexStr(buffer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte[]? chip_get_serialnumber_for_byte()
        {
            if (obj is null)
                return null;

            return obj.get_sn();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string chip_get_serialnumber_for_string()
        {
            if (obj is null)
                return String.Empty;

            var buffer = obj.get_sn();

            return NeoHexString.ByteArrayToHexStr(buffer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyindex"></param>
        /// <param name="pw"></param>
        /// <returns></returns>
        public bool chip_verify_pw_by_byte(int keyindex, byte[] pw)
        {
            if (obj is null)
                return false;

            if (keyindex < 0 || pw is null)
            {
                return false;
            }

            obj.verify_pw(keyindex, pw);

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyindex"></param>
        /// <param name="pw"></param>
        /// <returns></returns>
        public bool chip_verify_pw_by_string(int keyindex, string pw)
        {
            if (obj is null)
                return false;

            if (keyindex < 0 || pw is null)
            {
                return false;
            }
                        
            obj.verify_pw(keyindex, NeoHexString.HexStringToByteArray(pw));

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="new_pw"></param>
        /// <returns></returns>
        public bool chip_write_password(string new_pw)
        {
            if (obj is null || new_pw is null)
                return false;

            obj.write_pw(NeoHexString.HexStringToByteArray(new_pw));

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyindex"></param>
        /// <param name="keyarea"></param>
        /// <param name="new_msg"></param>
        /// <returns></returns>
        public bool chip_write_key(int keyindex, int keyarea, string new_msg)
        {
            if (obj is null || new_msg is null)
                return false;

            obj.write_key(keyindex, keyarea, NeoHexString.HexStringToByteArray(new_msg));

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyindex"></param>
        /// <param name="keyarea"></param>
        /// <returns></returns>
        public byte[] ?chip_read_key_for_byte(int keyindex, int keyarea)
        {
            if (obj is null)
                return null;

            return obj.read_key(keyindex, keyarea);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyindex"></param>
        /// <param name="keyarea"></param>
        /// <returns></returns>
        public string chip_read_key_for_string(int keyindex, int keyarea)
        {
            if (obj is null)
                return String.Empty;

            return NeoHexString.ByteArrayToHexStr(obj.read_key(keyindex, keyarea));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyindex"></param>
        /// <param name="keyarea"></param>
        /// <param name="new_msg"></param>
        /// <returns></returns>
        public bool chip_write_multi_key_by_byte(int keyindex, int keyarea, byte[] new_msg)
        {
            if (obj is null)
                return false;

            obj.write_multi_key(keyindex , keyarea, new_msg);   

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyindex"></param>
        /// <param name="keyarea"></param>
        /// <param name="new_msg"></param>
        /// <returns></returns>
        public bool chip_write_multi_key_by_string(int keyindex, int keyarea, string new_msg)
        {
            if (obj is null)
                return false;

            obj.write_multi_key(keyindex, keyarea, NeoHexString.HexStringToByteArray(new_msg));

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyindex"></param>
        /// <param name="keyarea"></param>
        /// <param name="readsize"></param>
        /// <returns></returns>
        public byte[] ?chip_read_multi_key(int keyindex, int keyarea, int readsize)
        {
            if (obj is null)
                return null;

            return obj.read_multi_key(keyindex, keyarea, readsize);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyindex"></param>
        /// <param name="keyarea"></param>
        /// <param name="readsize"></param>
        /// <returns></returns>
        public string chip_read_multi_key_for_string(int keyindex, int keyarea, int readsize)
        {
            if (obj is null)
                return String.Empty;

            return NeoHexString.ByteArrayToString( obj.read_multi_key(keyindex, keyarea, readsize));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keytype"></param>
        /// <param name="new_msg"></param>
        /// <returns></returns>
        public bool chip_write_with_header_by_byte(KEYTYPE keytype, byte[] new_msg)
        {
            if (obj is null)
                return false;

            obj.write_with_header(keytype, new_msg);

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keytype"></param>
        /// <param name="new_msg"></param>
        /// <returns></returns>
        public bool chip_write_with_header_by_string(KEYTYPE keytype, byte[] new_msg)
        {
            if (obj is null)
                return false;

            obj.write_with_header(keytype, new_msg);

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keytype"></param>
        /// <returns></returns>
        public byte[] ?chip_read_with_header_for_byte(KEYTYPE keytype)
        {
            if (obj is null)
                return null;

            return obj.read_with_header(keytype);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keytype"></param>
        /// <returns></returns>
        public string chip_read_with_header_for_string(KEYTYPE keytype)
        {
            if (obj is null)
                return String.Empty;

            return NeoHexString.ByteArrayToString(obj.read_with_header(keytype));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aes_crypt"></param>
        /// <param name="sha_256"></param>
        /// <returns></returns>
        public bool set_aes_function(AES_CRYPT aes_crypt, SHA_256 sha_256)
        {
            if (obj is null)
                return false;

            obj.set_aes_fn(aes_crypt, sha_256);

            return true;
        }
    }

    internal class ICTK_PUF_Class 
    {
        #region Field

        public string system_constant = "632854F31C456408B6A3F9B20024EADA";//"4C4755504C55532D5051432D44454D4F2D53595354454D2D434F4E5354414E54";

        /// <summary>
        /// WM_DEVICECHANGE
        /// </summary>
        public const int WM_DEVICECHANGE = 0x0219;

        /// <summary>
        /// DBT_DEVTYP_DEVICEINTERFACE
        /// </summary>
        public const int DBT_DEVTYP_DEVICEINTERFACE = 0x05;

        /// <summary>
        /// DEVICE_NOTIFY_WINDOW_HANDLE
        /// </summary>
        public const int DEVICE_NOTIFY_WINDOW_HANDLE = 0x00000000;

        #endregion

        PUF_API_CLASS ictk_puf_api = new PUF_API_CLASS();
        ICTK_ALGORITHM ictk_algorithm = new ICTK_ALGORITHM();

        public bool _chip_verify_pw_by_byte(int keyindex, byte[] pw)
        {
            return ictk_puf_api.chip_verify_pw_by_byte(keyindex, pw);
        }

        public bool set_puf_aes_function(AES_CRYPT aes_crypt, SHA_256 sha_256)
        {
            ictk_puf_api.set_aes_function(aes_crypt, sha_256);
            return true;
        }

        public bool PqcG3API_InitObject(string system_constant)
        {
            var pgpg3api = new PqcG3API(NeoHexString.StringToByteArray(system_constant));
            if (pgpg3api != null)
            {
                pgpg3api.init();
                ictk_puf_api.Obj = pgpg3api;
            }
            else
            {
                return false;
            }

            return true;
        }

        public bool is_puf_connect()
        {
            /*if (ictk_puf_api.chip_init() == false)
            {
                //DO LOG

                return false;
            }
            */

            return ictk_puf_api.chip_is_conncted() ? true : false;
        }


        public string get_puf_sn()
        {
            if (ictk_puf_api.chip_is_conncted() != true)
            {
                return String.Empty;
            }

            if (ictk_puf_api.chip_wakeup() != true)
            {
                return String.Empty;
            }

            return ictk_puf_api.chip_get_serialnumber_for_string();
        }

        public byte[]? get_puf_sn_byte()
        {
            if (ictk_puf_api.chip_is_conncted() != true)
            {
                return null;
            }

            if (ictk_puf_api.chip_wakeup() != true)
            {
                return null;
            }

            return ictk_puf_api.chip_get_serialnumber_for_byte();
        }

        public byte[] _chip_read_key_for_byte(int keyindex, int keyarea)
        {
            return ictk_puf_api.chip_read_key_for_byte(keyindex, keyarea);
        }
        
        public byte[] _chip_read_multi_key(int keyindex, int keyarea, int readsize)
        {
            return ictk_puf_api.chip_read_multi_key(keyindex, keyarea, readsize);
        }

    }

    public class ICTKPupWarpClass
    {
        ICTK_PUF_Class ictkpuf = new ICTK_PUF_Class();
        ICTK_ALGORITHM argorithm = new ICTK_ALGORITHM();

        int PUF_KEY_INDEX_HEADER = 15;
        int PUF_KEY_INDEX_PRK = 16;
        int PUF_SECTER_SIZE = 32;

        /// <summary>
        ///Lower byte  
        ///    00 – setup area
        ///    01 – key area
        ///    02 – data area Data0
        ///    03 – data area Data1
        /// </summary>
        
        public enum P2OPTION
        {
            OPTION_LOWER_SETUP_AREA = 0,
            OPTION_LOWER_KEY_AREA   = 1,
            OPTION_LOWER_DATA0_AREA = 2,
            OPTION_LOWER_DATA1_AREA = 3,
        }

        public struct _KEYCERT_HEADER
        {
            public short prk_size;
            public short cert_size;
            public short prk_slot_size;
            public short cert_slot_size;//165
            public short cert_slot2_size;//
            public byte[] dummy = new byte[22];

            public _KEYCERT_HEADER(short prk_size_,
            short cert_size_,
            short prk_slot_size_,
            short cert_slot_size_,//165
            short cert_slot2_size_,//
            byte[] dummy_)// = new byte[22]
            {
                prk_size = prk_size_;
                cert_size = cert_size_;
                prk_slot_size = prk_slot_size_;
                cert_slot_size = cert_slot_size_;//165
                cert_slot2_size = cert_slot2_size_;//
                dummy = dummy_;
            }
        }

        public static T ByteToStruct<T>(byte[] buffer) where T : struct
        {
            int size = Marshal.SizeOf(typeof(T));

            if (size > buffer.Length)
            {
                throw new Exception();
            }

            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.Copy(buffer, 0, ptr, size);
            T obj = (T)Marshal.PtrToStructure(ptr, typeof(T));
            Marshal.FreeHGlobal(ptr);
            return obj;
        }

        public bool Init()
        {
            return true;
        }

        ///
        ///Verify SHA-256 checksum
        public bool VerifySHA256ChceksumPRK(byte[] _PrkData)
        {
            byte[] PrkSHA2 =ICTK_ALGORITHM.sha_256(_PrkData);
            string sha2 = NeoHexString.ByteArrayToHexStr(PrkSHA2);
            if (string.Compare(NeoHexString.ByteArrayToHexStr(PrkSHA2), Properties.Resources.STR_SHA2_PRK_SIGNUMHASH, true) == 0)
            {
                return true;
            }
            return false;
        }

        public bool VerifySHA256ChceksumCert(byte[] _CertData)
        {
            byte[] CertSHA2 = ICTK_ALGORITHM.sha_256(_CertData);
            if (string.Compare(NeoHexString.ByteArrayToHexStr(CertSHA2), Properties.Resources.STR_SHA2_CERT_SIGNUMHASH,true) == 0)
            {
                return true;
            }
            return false;
        }

        public byte[] ?GetPUF_Prk()
        {
            byte[] prk = new byte[8];

            var sn = ictkpuf.get_puf_sn_byte();

            if (ictkpuf.is_puf_connect() != true)
            {
                return prk;
            }
            else
            {
                if(!ictkpuf.set_puf_aes_function(ICTK_ALGORITHM.aes_crypto , ICTK_ALGORITHM.sha_256))
                {
                    return null;
                }

                if (!ictkpuf._chip_verify_pw_by_byte(0, sn))//AC 0을 얻는다.
                {
                    return null;
                }

                Thread.Sleep(1000);

                byte[] read_data = ictkpuf._chip_read_key_for_byte(15, 1);//4번키의 값을 읽는다. AC 1을 얻어야 한다. 

                _KEYCERT_HEADER KeyCertHeader = ByteToStruct<_KEYCERT_HEADER>(read_data);
                Thread.Sleep(1000);

                byte[] PrkData = ictkpuf._chip_read_multi_key(PUF_KEY_INDEX_PRK, (int)P2OPTION.OPTION_LOWER_KEY_AREA, (int)KeyCertHeader.prk_size);
                if (VerifySHA256ChceksumPRK(PrkData) == false)
                {
                    return null;
                }

                return PrkData;
            }

#pragma warning disable CS0162 // 접근할 수 없는 코드가 있습니다.
            return null;
#pragma warning restore CS0162 // 접근할 수 없는 코드가 있습니다.
        }

        public string? GetPUF_Prk_by_string()
        {
            byte[] prk = new byte[8];

            if (ictkpuf.is_puf_connect() != true)
            {
                return String.Empty;
            }
            else
            {
                var sn = ictkpuf.get_puf_sn_byte();

                if (!ictkpuf.set_puf_aes_function(ICTK_ALGORITHM.aes_crypto, ICTK_ALGORITHM.sha_256))
                {
                    return String.Empty;
                }

                if (!ictkpuf._chip_verify_pw_by_byte(0, sn))//AC 0을 얻는다.
                {
                    return String.Empty;
                }

                Thread.Sleep(1000);

                byte[] read_data = ictkpuf._chip_read_key_for_byte(PUF_KEY_INDEX_HEADER, 1);//4번키의 값을 읽는다. AC 1을 얻어야 한다. 

                _KEYCERT_HEADER KeyCertHeader = ByteToStruct<_KEYCERT_HEADER>(read_data);
                Thread.Sleep(1000);

                byte[] PrkData = ictkpuf._chip_read_multi_key(PUF_KEY_INDEX_PRK, (int)P2OPTION.OPTION_LOWER_KEY_AREA, (int)KeyCertHeader.prk_size);
                if (VerifySHA256ChceksumPRK(PrkData) == false)
                {
                    return string.Empty;
                }

                return String.Format("{0}", NeoHexString.ByteArrayToHexStr(PrkData)); ;
            }

#pragma warning disable CS0162 // 접근할 수 없는 코드가 있습니다.
            return String.Empty;
#pragma warning restore CS0162 // 접근할 수 없는 코드가 있습니다.
        }

        public byte[]? GetPUF_Cert()
        {
            byte[] prk = new byte[8];

            var sn = ictkpuf.get_puf_sn_byte();

            if (ictkpuf.is_puf_connect() != true)
            {
                return prk;
            }
            else
            {
                if(!ictkpuf.set_puf_aes_function(ICTK_ALGORITHM.aes_crypto, ICTK_ALGORITHM.sha_256))
                {
                    return null;
                }

                if (!ictkpuf._chip_verify_pw_by_byte(0, sn))//AC 0을 얻는다.
                {
                    return null;
                }

                Thread.Sleep(1000);

                byte[] read_data = ictkpuf._chip_read_key_for_byte(15, (int)P2OPTION.OPTION_LOWER_KEY_AREA);//4번키의 값을 읽는다. AC 1을 얻어야 한다. 

                _KEYCERT_HEADER KeyCertHeader = ByteToStruct<_KEYCERT_HEADER>(read_data);

                Thread.Sleep(1000);

                byte[] CertData = new byte[(int)KeyCertHeader.prk_size];
                byte[] ConBineData = new byte[((int)KeyCertHeader.cert_slot_size * PUF_SECTER_SIZE) + ((int)KeyCertHeader.cert_slot2_size * PUF_SECTER_SIZE)];
                byte[] CertFirstData    = ictkpuf._chip_read_multi_key(0, (int)P2OPTION.OPTION_LOWER_DATA0_AREA, ((int)KeyCertHeader.cert_slot_size * PUF_SECTER_SIZE));
                byte[] CertSecondData   = ictkpuf._chip_read_multi_key(0, (int)P2OPTION.OPTION_LOWER_DATA1_AREA, ((int)KeyCertHeader.cert_slot2_size * PUF_SECTER_SIZE));

                Array.Clear(CertData, 0, CertData.Length);
                Array.Clear(ConBineData, 0, ConBineData.Length);
                Array.Copy(CertFirstData, 0, ConBineData, 0, CertFirstData.Length);
                Array.Copy(CertSecondData, 0, ConBineData, CertFirstData.Length, CertSecondData.Length);

                Array.Copy(ConBineData, 0, CertData , 0, (int)KeyCertHeader.cert_size);

                if (VerifySHA256ChceksumCert(CertData) == false)
                {
                    return null;
                }

                return CertData;
            }

#pragma warning disable CS0162 // 접근할 수 없는 코드가 있습니다.
            return null;
#pragma warning restore CS0162 // 접근할 수 없는 코드가 있습니다.
        }


        public string GetPUF_Cert_by_string()
        {
            byte[] prk = new byte[8];

            var sn = ictkpuf.get_puf_sn_byte();

            if (ictkpuf.is_puf_connect() != true)
            {
                return String.Empty;
            }
            else
            {
                if(!ictkpuf.set_puf_aes_function(ICTK_ALGORITHM.aes_crypto, ICTK_ALGORITHM.sha_256))
                {
                    return string.Empty;
                }

                if (!ictkpuf._chip_verify_pw_by_byte(0, sn))//AC 0을 얻는다.
                {
                    return String.Empty;
                }

                Thread.Sleep(1000);

                byte[] read_data = ictkpuf._chip_read_key_for_byte(15, (int)P2OPTION.OPTION_LOWER_KEY_AREA);//4번키의 값을 읽는다. AC 1을 얻어야 한다. 

                _KEYCERT_HEADER KeyCertHeader = ByteToStruct<_KEYCERT_HEADER>(read_data);

                Thread.Sleep(1000);

                byte[] CertData         = new byte[((int)KeyCertHeader.cert_size)];
                byte[] ConBineData      = new byte[(((int)KeyCertHeader.cert_slot_size * PUF_SECTER_SIZE) + ((int)KeyCertHeader.cert_slot2_size * PUF_SECTER_SIZE ))];
                byte[] CertFirstData    = ictkpuf._chip_read_multi_key(0, (int)P2OPTION.OPTION_LOWER_DATA0_AREA, ((int)KeyCertHeader.cert_slot_size * PUF_SECTER_SIZE));
                byte[] CertSecondData   = ictkpuf._chip_read_multi_key(0, (int)P2OPTION.OPTION_LOWER_DATA1_AREA,((int)KeyCertHeader.cert_slot2_size * PUF_SECTER_SIZE));

                Array.Clear(CertData, 0, CertData.Length);
                Array.Clear(ConBineData, 0, ConBineData.Length);
                Array.Copy(CertFirstData, 0, ConBineData, 0, CertFirstData.Length);
                Array.Copy(CertSecondData, 0, ConBineData, CertFirstData.Length, CertSecondData.Length);

                Array.Copy(ConBineData, 0, CertData, 0, (int)KeyCertHeader.cert_size);

                if (VerifySHA256ChceksumCert(CertData) == false)
                {
                    return string.Empty;
                }

                return String.Format("{0}", NeoHexString.ByteArrayToHexStr(CertData)); 
            }

#pragma warning disable CS0162 // 접근할 수 없는 코드가 있습니다.
            return String.Empty;
#pragma warning restore CS0162 // 접근할 수 없는 코드가 있습니다.
        }
    }
}
