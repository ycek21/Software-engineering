using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class TcpServer
    {
        private readonly TcpListener _tcpListener;
        private List<Client> _tcpClients = new List<Client>(2);

        public TcpServer(string ipAddress, int port)
        {
            this._tcpListener = new TcpListener(IPAddress.Parse(ipAddress),port);
            this._tcpListener.Start();
        }

        public void AddClient()
        {
            while (true)
            {
                /*if (_tcpClients.Count == 2)
                {
                    break;
                }*/
                /*nie moge zrobic break, gdyz wtedy glowny watek konczy swoje dzialanie 
                i inne watki, ktore odpowiadaja za nasluchwianie zostaja zamkniete razem z glownym*/
                this._tcpClients.Add(new Client(this._tcpListener.AcceptTcpClient()));

            }
            
        }



    }
}
