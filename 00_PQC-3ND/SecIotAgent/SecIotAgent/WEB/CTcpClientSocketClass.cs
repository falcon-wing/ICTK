using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecIotAgent.WEB
{
    internal class CTcpClientSocketClass
    {
        private AsyncSocketClient Socket;
        public CTcpClientSocketClass()
        {
            Socket = new AsyncSocketClient(0);
            Socket.OnConnet += new AsyncSocketConnectEventHandler(OnConnet);
            Socket.OnClose += new AsyncSocketCloseEventHandler(OnClose);
            Socket.OnSend += new AsyncSocketSendEventHandler(OnSend);
            Socket.OnReceive += new AsyncSocketReceiveEventHandler(OnReceive);
            Socket.OnError += new AsyncSocketErrorEventHandler(OnError);
        }

        private void OnConnet(object sender, AsyncSocketConnectionEventArgs e)
        {
            Console.WriteLine("Socket OnConnet");
        }

        private void OnClose(object sender, AsyncSocketConnectionEventArgs e)
        {
            Console.WriteLine("Socket OnClose");
        }

        private void OnSend(object sender, AsyncSocketSendEventArgs e)
        {
            Console.WriteLine("Socket OnSend");
        }

        private void OnReceive(object sender, AsyncSocketReceiveEventArgs e)
        {
            byte[] tbuf = new byte[e.ReceiveBytes];
            e.ReceiveData.Take(e.ReceiveBytes).ToArray().CopyTo(tbuf, 0);
        }

        private void OnError(object sender, AsyncSocketErrorEventArgs e)
        {
            Console.WriteLine("Socket OnError");
        }
    }
}


