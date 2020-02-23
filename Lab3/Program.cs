using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Program
    {
        public static void ReadFile()
        {
            var path = @"E:/Studia/5 SEMESTR/InzynieriaOprogramowania/InzynieriaOprogramowania/Software-engineering/Lab3/bin/text.txt";
            var buffer = new byte[new FileInfo(path).Length];
            var fs = new FileStream(path,
                FileMode.Open);
            fs.BeginRead(buffer, 0, buffer.Length, Callback, new object[] { fs, buffer });
        }

        private static void Callback(IAsyncResult iAsyncResult)
        {
            if (iAsyncResult.IsCompleted)
            {
                var state = (object[])iAsyncResult.AsyncState;
                var fs = (FileStream)state[0];
                var buffer = (byte[]) state[1];
                fs.EndRead(iAsyncResult);
                fs.Close();
                var message = Encoding.GetEncoding("UTF-8").GetString(buffer);
                Console.WriteLine($"File Content: {message}");
            }
        }

        static void Main(string[] args)
        {
            ReadFile();
            Console.ReadLine();

        }
    }
}
