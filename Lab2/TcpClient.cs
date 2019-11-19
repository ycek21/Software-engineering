using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab2
{
    public class TcpClient
    {
        private System.Net.Sockets.TcpClient tcpClient;

        public TcpClient(System.Net.Sockets.TcpClient client)
        {
            this.tcpClient = client;
            ThreadPool.QueueUserWorkItem(ReadMessage);
        }
        //dlaczego musi byc obiekt jako parametr, albo dlaczego dziala tak jak wojtas

        public void ReadMessage(Object state)
        {
            var networkStream = tcpClient.GetStream();
            var buffer = new byte[1024];

            while (true)
            {
                var sizeRead = networkStream.Read(buffer, 0, buffer.Length);
                var sendData = new byte[sizeRead];
                for (int i = 0; i < sizeRead; i++)
                {
                    sendData[i] = buffer[i];
                }
                writeConsoleMessage(Encoding.ASCII.GetString(sendData),ConsoleColor.Red);
                networkStream.Write(buffer,0,sizeRead);
                writeConsoleMessage(Encoding.ASCII.GetString(sendData), ConsoleColor.Cyan);
            }


        }

        private void writeConsoleMessage(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }


    }

}

