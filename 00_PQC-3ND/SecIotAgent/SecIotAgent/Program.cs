using System.Net;
using System.Text;
using System.Net.Sockets;
using SecIotAgent.Common;
using System.Text.RegularExpressions;
using SecIotAgent.Forms;
using SecIotAgent.RESTAPI;
using WebSocketSharp;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using SecIotAgent.WEB;

namespace SecIotAgent
{
    public enum LOG_INFOV2
    {
        LOG01,
        LOG02,
        LOG03
    }

    public enum LOGINFO
    {
        INFO,
        WARN,
        ERROR,
        FATAL
    }

    public enum LOGINFO_FUNCTION
    {
        TOTAL,
        DEVICE,
        WEBSOCKET,
        ETC
    }

     

    internal static class Program
    {
        static CSHAP_ICTK_JSON_Class jsonclass = new CSHAP_ICTK_JSON_Class();
        static byte[] readBuffer = new byte[409600];

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Logs commonV2 = new Logs();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.SetCompatibleTextRenderingDefault(false);

            {
                string strLogMsg = "Sec IOT Application stat....";
                commonV2.Log_info(strLogMsg, (int)LOGINFO.INFO, (int)LOGINFO_FUNCTION.ETC);

                strLogMsg = "Check Local Device ........";
                commonV2.Log_info(strLogMsg, (int)LOGINFO.INFO, (int)LOGINFO_FUNCTION.DEVICE);

                strLogMsg = "Read to Take the event.....";
                commonV2.Log_info(strLogMsg, (int)LOGINFO.INFO, (int)LOGINFO_FUNCTION.DEVICE);
            }
            /*
            {
                System.Threading.Thread thread = new Thread(new ThreadStart(WebSocketFunc));
                thread.Start();
            }
            */
            ConnectionManager ws = new ConnectionManager("127.0.0.1", 80);



            /// restapi test
            /// 
            ///
            CSHAP_ICTK_RestApiClass cSHAP_ICTK_RestApiClass = new CSHAP_ICTK_RestApiClass();
            string Url = string.Empty;
            string Method = string.Empty;
            string ContantType = string.Empty;
            string ObjectName = string.Empty;

            Url = "https://43.200.98.151:8443/pqc3/device/public/challenge";
            Method = "GET";
            ContantType = "application/json";
            ObjectName = "list";


           // string jsondata = jsonclass.MakeJsonSample();
            //MessageBox.Show(jsondata);
            //var ResResult = cSHAP_ICTK_RestApiClass.CSHAP_WebResponse(Url, Method, ContantType, ObjectName);
            //CSHAP_ICTK_RestApiClass.
           /* cSHAP_ICTK_RestApiClass.Req_Challenge("500301", "TEST_EMUL_0001");

            cSHAP_ICTK_RestApiClass.CSHAP_WebRequest();
           */


            Application.Run(new TrayIconForm());
        }

        static void onAcceptReader( IAsyncResult ar)
        {
            //int receiveLentth = 
        }


        private static bool IsValidJson(string strInput)
        {
            if (string.IsNullOrWhiteSpace(strInput)) { return false; }
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || //For object
                (strInput.StartsWith("[") && strInput.EndsWith("]"))) //For array
            {
                try
                {
                    var obj = JToken.Parse(strInput);
                    return true;
                }
                catch (JsonReaderException jex)
                {
                    //Exception in parsing json
                    Console.WriteLine(jex.Message);
                    return false;
                }
                catch (Exception ex) //some other exception
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool ValidateJSON(this string s)
        {
            try
            {
                JToken.Parse(s);
                return true;
            }
            catch (JsonReaderException)
            {
              //  Trace.WriteLine(ex);
                return false;
            }
        }


        private static void WebSocketFunc()
        {
            string ip = "127.0.0.1";
            int port = 80;
            var server = new TcpListener(IPAddress.Parse(ip), port);
            server.Start();

            string strLogMsg = String.Format("Server has started on {0}:{1}, Waiting for a connection...", ip, port);
            Logs commonV2 = new Logs();
            commonV2.Log_info(strLogMsg, (int)LOGINFO.INFO, (int)LOGINFO_FUNCTION.WEBSOCKET);

            TcpClient client = server.AcceptTcpClient();
            {
                Console.WriteLine("A client connected.");
            }

            NetworkStream stream = client.GetStream();

            while (true)
            {
                //offset = 0;
                while (!stream.DataAvailable) ;
                while (client.Available < 3) ; // match against "get"

                byte[] bytes = new byte[client.Available];
                stream.Read(bytes, 0, client.Available);
                string s = Encoding.UTF8.GetString(bytes);
                
                if (Regex.IsMatch(s, "^GET", RegexOptions.IgnoreCase))
                {

                    // 1. Obtain the value of the "Sec-WebSocket-Key" request header without any leading or trailing whitespace
                    // 2. Concatenate it with "258EAFA5-E914-47DA-95CA-C5AB0DC85B11" (a special GUID specified by RFC 6455)
                    // 3. Compute SHA-1 and Base64 hash of the new value
                    // 4. Write the hash back as the value of "Sec-WebSocket-Accept" response header in an HTTP response
                    string swk = Regex.Match(s, "Sec-WebSocket-Key: (.*)").Groups[1].Value.Trim();
                    string swka = swk + "258EAFA5-E914-47DA-95CA-C5AB0DC85B11";
                    byte[] swkaSha1 = System.Security.Cryptography.SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(swka));
                    string swkaSha1Base64 = Convert.ToBase64String(swkaSha1);

                    // HTTP/1.1 defines the sequence CR LF as the end-of-line marker
                    byte[] response = Encoding.UTF8.GetBytes(
                        "HTTP/1.1 101 Switching Protocols\r\n" +
                        "Connection: Upgrade\r\n" +
                        "Upgrade: websocket\r\n" +
                        "Sec-WebSocket-Accept: " + swkaSha1Base64 + "\r\n\r\n");

                    stream.Write(response, 0, response.Length);
                }
                else
                {
                    bool fin = (bytes[0] & 0b10000000) != 0,
                        mask = (bytes[1] & 0b10000000) != 0; // must be true, "All messages from the client to the server have this bit set"
                    int opcode = bytes[0] & 0b00001111; // expecting 1 - text message
                    int offset = 2;
                    ulong msglen = (ulong)bytes[1] & 0b01111111;

                    if (msglen == 126)
                    {
                        // bytes are reversed because websocket will print them in Big-Endian, whereas
                        // BitConverter will want them arranged in little-endian on windows
                        msglen = BitConverter.ToUInt16(new byte[] { bytes[3], bytes[2] }, 0);
                        offset = 4;
                    }
                    else if (msglen == 127)
                    {
                        // To test the below code, we need to manually buffer larger messages — since the NIC's autobuffering 
                        // may be too latency-friendly for this code to run (that is, we may have only some of the bytes in this
                        // websocket frame available through client.Available).  
                        msglen = BitConverter.ToUInt64(new byte[] { bytes[9], bytes[8], bytes[7], bytes[6], bytes[5], bytes[4], bytes[3], bytes[2] }, 0);
                        offset = 10;
                    }

                    if (msglen == 0)
                        Console.WriteLine("msglen == 0");
                    else if (mask)
                    {
                        byte[] decoded = new byte[msglen];
                        byte[] masks = new byte[4] { bytes[offset], bytes[offset + 1], bytes[offset + 2], bytes[offset + 3] };
                        offset += 4;

                        for (ulong i = 0; i < msglen; ++i)
                            decoded[i] = (byte)(bytes[offset + (int)i] ^ masks[i % 4]);

                        string text = Encoding.UTF8.GetString(decoded);
                        Console.WriteLine("{0}", text);
                        strLogMsg = String.Format("recv message {0}", text);

                        if (ValidateJSON(text) == true )
                        {
                            var obj = JObject.Parse(text);
                            if (obj == null)
                            {
                                continue;
                            }

                            string cmd = obj["cmd"].ToString();

                            if (String.IsNullOrEmpty(cmd))
                            {
                                continue;
                            }
                            else
                            {
                                if (String.Compare(cmd, "check", false) == 0)
                                {

                                    string str = "Add 1003 + 1 : " + (1003 + 1);
                                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(str);
                                    // 반환
                                    stream.Write(msg, 0, msg.Length);
                                    /*
                                    byte[] response = Encoding.UTF8.GetBytes(
                                        "connected");

                                    string msg = "Hello World";
                                    byte[] buff = Encoding.ASCII.GetBytes(msg);

                                    stream.Write(buff, 0, buff.Length);
                                    */
                                }
                                else if (String.Compare(cmd, "log_in", false) == 0)
                                {

                                }
                                else if (String.Compare(cmd, "exchange_media_key", false) == 0)
                                {

                                }


                            }
                            MessageBox.Show(cmd);
                            //var header_list = obj["header"];
                            //var body_list = obj["body"];
                        }

                        commonV2.Log_info(strLogMsg, (int)LOGINFO.INFO, (int)LOGINFO_FUNCTION.WEBSOCKET);
                    }
                    else
                        Console.WriteLine("mask bit not set");

                    Console.WriteLine();
                }
            }

        }
    }
}