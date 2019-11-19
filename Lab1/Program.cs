using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        // stream to przechowalnia danych z ktorych moze czytac i klient i serwer
        static void Main(string[] args)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), 8080);
            tcpListener.Start();
            var client = tcpListener.AcceptTcpClient();
            var networkStream = client.GetStream();
            var buffer = new byte[64];

            while (true)
            {
                var sizeRead = networkStream.Read(buffer, 0, 64);
                networkStream.Write(buffer, 0, sizeRead);
                //Console.WriteLine(ASCIIEncoding.ASCII.GetString(buffer));
            }
        }
    }
}