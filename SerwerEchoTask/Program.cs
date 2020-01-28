using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SerwerEchoTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t = ServerTask();
            Task c = ClientTask();
            Task.WaitAll(t, c);

        }

        static async Task ServerTask()
        {
            TcpListener server = new TcpListener(IPAddress.Any, 2048);
            server.Start();

            while (true)
            {
                TcpClient client = await server.AcceptTcpClientAsync();
                byte[] buffer = new byte[1024];
                client.GetStream().ReadAsync(buffer, 0, buffer.Length).ContinueWith(
                    async (t) =>
                    {
                        int i = t.Result;
                        while (true)
                        {
                            client.GetStream().WriteAsync(buffer, 0, i);
                            Console.WriteLine(Encoding.ASCII.GetString(buffer));
                            i = await client.GetStream().ReadAsync(buffer, 0, buffer.Length);
                        }
                    });
            }
        }

        static async Task ClientTask()
        {
            var buffer = Encoding.ASCII.GetBytes("Test");
            TcpClient client = new TcpClient();
            await client.ConnectAsync("127.0.0.1", 2048);
            Thread.Sleep(400);
            await client.GetStream().WriteAsync(buffer, 0, buffer.Length);
        }
    }

}
