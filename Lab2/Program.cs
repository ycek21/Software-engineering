using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpServer server = new TcpServer("127.0.0.1",8080);
            server.AddClient();


            //zadanie1

            //ThreadPool.QueueUserWorkItem(ThreadProc, 5000);
            //ThreadPool.QueueUserWorkItem(ThreadProc, 6000);
            //ThreadPool.QueueUserWorkItem(ThreadProc, 3000);
            //Thread.Sleep(15000);

            //Console.ReadLine();

        }
        // static void ThreadProc(object stateInfo)
        //{
        //    var waitedTime = (int) stateInfo;
        //    Thread.Sleep(waitedTime);
        //    Console.WriteLine($"I waited {waitedTime}");
        //}
    }
}
