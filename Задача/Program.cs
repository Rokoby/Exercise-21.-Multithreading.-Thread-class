using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Задача
{
    internal class Program
    {
        const int n = 5;
        const int m = 6;
        static int[,] field = new int[n, m] { { 1, 2, 3, 4, 5, 6 }, { 7, 8, 9, 10, 11, 12 }, { 13, 14, 15, 14, 13, 12 }, { 11, 10, 9, 8, 7, 6 }, { 5, 4, 3, 2, 1, 0 } };

        static void Main(string[] args)
        {
            ThreadStart threadStart = new ThreadStart(Gardener2);
            Thread thread = new Thread(threadStart);
            thread.Start();

            Gardener1();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write($"{-field[i, j],4} ");
                Console.WriteLine();
            }

            Console.ReadKey();
            
        }
        static void Gardener1() 
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (field[i, j] >= 0)
                    {
                        int delay = field[i, j];
                        Thread.Sleep(delay);
                        field[i, j] = -1;
                    }
        }
        static void Gardener2() 
        {
            for (int i = m; i > 0; i--)
                for (int j = n; j > 0; j--)
                    if (field[j-1, i-1] >= 0)
                    {
                        Thread.Sleep(field[j-1, i-1]);
                        field[j - 1, i-1] = -2;
                    }
        }
    }
}
