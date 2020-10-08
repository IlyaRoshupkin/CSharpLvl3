//Написать приложение, считающее в раздельных потоках: 
//1) факториал числа N, которое вводится с клавиатуры;
//2) сумму целых чисел до N.
//Рощупкин
using System;
using System.Threading;

namespace hw5task1b
{
    class Program
    {
        static int sum=0;
        static int n = 1;
        static int N;
        static object locker = new object();

        static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            try
            {
                N = int.Parse(Console.ReadLine());
                if (N <= 2) // Первые два числа (a и b) равны 1
                    Console.WriteLine("1");
                else
                {
                    for (int i = 0; i < N; i++)
                    {
                        Thread myThread = new Thread(Count);
                        myThread.Name = "Поток " + i.ToString();
                        myThread.Start();
                    }
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("\n" + exp.Message);
            }

            Console.ReadLine();
        }

        public static void Count()
        {
            lock (locker)
            {
                sum += n;
                Console.WriteLine("{0}: {1}", Thread.CurrentThread.Name, sum);
                n++;
                Thread.Sleep(100);
            }
        }

    }
}
