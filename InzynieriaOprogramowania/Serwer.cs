using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace InzynieriaOprogramowania
{
    class Server
    {
        private TcpListener tcpListener { get; set; }
        private List<TcpClient> tcpClients { get; set; }
        private NetworkStream networkStream;
        private byte[] Buffer = new byte[64];

        public Server(System.Net.IPAddress address, int port)
        {
            tcpListener = new TcpListener(address,port);
        }

        public void StartServer()
        {
            tcpListener.Start();
        }

       /* public TcpClient[] GetTcpClient()
        {
            return tcpClient;
        }

        public NetworkStream GetNetworkStream()
        {
            return networkStream;
        }

        public TcpClient AcceptClient()
        {
            return tcpListener.AcceptTcpClient();
        }*/

       public void AcceptClient()
        {
            tcpClients.Add(tcpListener.AcceptTcpClient());
        }

       public TcpClient getClient(int id)
       {
           return tcpClients.
       }



    }
}
