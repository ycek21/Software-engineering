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
        static void myAsyncCallback(Object state)
        {
            var myObj = ((object[])state)[1];
            //var myString = (string) myObj;
            Console.WriteLine(myObj.ToString());

            var stream = ((object[])state)[0];

            stream.EndStream();

        }

        static void Main(string[] args)
        {
            /* zadanie 6*/

            FileStream filestream = new FileStream("file.txt",FileMode.Open);
            var buffer = new byte[64];
            filestream.BeginRead(buffer, 0, 64, myAsyncCallback, new object[] { filestream, buffer});
            



        }
    }
}
