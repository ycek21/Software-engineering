using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Brudnopis
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem(Thread1);
            ThreadPool.QueueUserWorkItem(Thread2);
            Thread.Sleep(2000);
            //jezeli nie zatrzymamy watku glownego i on sie zakonczy to inne watki sie nie wykonaja

        }

        static void Thread1(Object statinfo)
        {
            Thread.Sleep(1000);
            Console.WriteLine("Thread2 poczekał 1000ms");
        }

        static void Thread2(Object statinfo)
        {
            Thread.Sleep(500);
            Console.WriteLine("Thread2 poczekał 500ms");
        }
    }
}
