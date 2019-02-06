using System;
using System.Diagnostics;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите размерность матрицы в виде m x n: ");
            string size = Console.ReadLine();
            int R = Convert.ToInt32(size.Split('x')[0]);
            int C = Convert.ToInt32(size.Split('x')[1]);
            int[,] Matrix = new int[R, C];
            Console.WriteLine("Матрица:");
            Random rnd = new Random();
            for (int i = 0; i < R; i++)
            {
                for (int j = 0; j < C; j++)
                {
                    Matrix[i, j] = rnd.Next(0, 9);
                    Console.Write("{0,1}\t", Matrix[i, j]);
                }
                Console.WriteLine();
            }
            Connector.CounterClient Connection = new Connector.CounterClient();
            double Result = 0;
            for (int i = 0; i < C; i++)
            {
                Process.Start(@"D:\Учёба\III курс\СПО\LAB21WCF\SubClient\SubClient\bin\Debug\SubClient.exe");
                int[] tmp = new int[R];
                for (int j = 0; j < R; j++)
                    tmp[j] = Matrix[i, j];
                Connection.AddColumn(tmp);
                double itmp = 0;
                while (true)
                {
                    itmp = Connection.GetAverage();
                    if (itmp != -1)
                        break;
                }
                Result += itmp;
            }
            Console.WriteLine("Среднее арифметическое матрицы: {0:F2}", Result / C);
            Console.ReadKey();
        }
    }
}
