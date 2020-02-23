using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Program
    {
        public static int[,] ApplyFilter(int[][] image, int[][] filtr)
        {
            int height = image.Length;
            int width = image[0].Length;
            int filterHeight = filtr.Length;
            int filterWidth = filtr[0].Length;
            int[,] result = new int[width, height];

            for (int x = 0; x < width; ++x)
            {
                for (int y = 0; y < height; ++y)
                {
                    result[x, y] = 0;
                    int XActual = -filterWidth / 2;
                    for (int x2 = 0; x2 < filterWidth; ++x2)
                    {
                        if (XActual + x < width && XActual + x >= 0)
                        {
                            int YActual = -filterHeight / 2;
                            for (int y2 = 0; y2 < filterHeight; ++y2)
                            {
                                if (YActual + y < height && YActual + y >= 0)
                                {
                                    result[x, y] += filtr[x2][y2] * image[XActual + x][YActual + y];
                                }
                                ++YActual;
                            }
                        }
                        ++XActual;
                    }
                    Console.Write(result[x, y] + " ");
                }
                Console.WriteLine();
            }
            return result;
        }

        public static int[][] ImgToArray(string nazwa_pliku)
        {
            using (StreamReader file = new StreamReader(nazwa_pliku))
            {
                int counter = 0;
                string ln;
                string dimensions = "";
                string maxPixel = "";
                List<Int32> row;
                List<List<Int32>> matrix = new List<List<Int32>>();
                List<Int32> xy = new List<Int32>();
                int[,] pix_tab;
                while ((ln = file.ReadLine()) != null)
                {
                    counter++;
                    if (counter == 2)
                    {
                        dimensions = ln;
                        xy = dimensions.Split(' ').Select(Int32.Parse).ToList();
                        pix_tab = new int[xy[1], xy[0]];
                    }
                    if (counter == 3)
                        maxPixel = ln;
                    if (counter > 3)
                    {
                        row = ln.Split(' ').Select(Int32.Parse).ToList();
                        matrix.Add(row);
                    }
                }
                file.Close();
                int[][] arrays = matrix.Select(a => a.ToArray()).ToArray();
                for (int j = 0; j < arrays.Length; j++)
                {
                    for (int q = 0; q < arrays[j].Length; q++)
                        Console.Write(arrays[j][q] + " ");
                    Console.WriteLine();
                }
                Console.WriteLine();
                return arrays;
            }

        }

        static int searchMax(int[,] image)
        {
            int max = 0;
            int i = 0;
            foreach (int v in image)
            {
                if (i == 0)
                    max = v;
                else
                {
                    if (v > max)
                        max = v;
                }
                i++;
            }
            return max;
        }

        static void writeToFile(int[,] image, int max)
        {
            int i = 0;
            File.Delete(@"E:/Studia/5 SEMESTR/InzynieriaOprogramowania/InzynieriaOprogramowania/Software-engineering/Lab4/file.pgm");
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"E:/Studia/5 SEMESTR/InzynieriaOprogramowania/InzynieriaOprogramowania/Software-engineering/Lab4/file.pgm", true))
            {
                file.WriteLine("P2");
                file.WriteLine(image.GetLength(0) + " " + image.GetLength(1));
                file.WriteLine(max);
                foreach (int v in image)
                {
                    i++;
                    file.Write(v + " ");
                    if (i % image.GetLength(0) == 0 && i > 0)
                        file.WriteLine();

                }
            }
        }

        static void Main(string[] args)
        {
            var image1 = ImgToArray("file.pgm");
            var image2 = ImgToArray("filtr.pgm");
            var result = ApplyFilter(image1, image2);
            int max = searchMax(result);
            writeToFile(result, max);
            Console.ReadKey();
        }
    }
}

