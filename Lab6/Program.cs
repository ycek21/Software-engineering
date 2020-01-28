using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://pl.wikipedia.org/wiki/Splot_(analiza_matematyczna)
            //  https://pl.wikipedia.org/wiki/Portable_anymap
            //https://en.wikipedia.org/wiki/Netpbm_format
            // przeprowadzic operacje splotu na tym obrazie
            // po wykonaniu filtru splotowego zapisac plik
            // nalezy dopisac te wszytskie rzeczy, ktore zobaczymy jak otworzymy przykladowy obraz w tym folderze
            //najpierw zapisac obraz
            // potem zapisac drugi obraz, ktory jest po zastosowaniu filtra


            var picture = new int[,] {{1,2,3}, {4,5,6},{7,8,9}};

            var filtr = new int[,] {{1, 0, 1}, {0, 1, 0}, {1, 0, 1}};

            var sb = new StringBuilder();

            sb.Append("P2\n");
            sb.Append("3 3\n");
            sb.Append("10\n");
            

            //float *tmp = (float*)malloc(sizeof(float)*w*h);


            for (var i = 0; i < picture.GetLength(0); i++)
            {
                for (var j = 0; j < picture.GetLength(1); j++)
                {
                    sb.Append(picture.GetValue(i,j));
                    sb.Append(" ");
                }

                sb.Append("\n");
            }

            var file = sb.ToString();
            File.WriteAllText("E:/Studia/5 SEMESTR/InzynieriaOprogramowania/file.pgm", file);

            // dorobic filtr i zapisac znowu

         


        }
    }
}
