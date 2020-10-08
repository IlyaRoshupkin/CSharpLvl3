using System;
using System.Threading;
//Написать приложение, считающее в раздельных потоках: 
//1) факториал числа N, которое вводится с клавиатуры;
//2) сумму целых чисел до N.
//Рощупкин
namespace hw5task1
{
    class Program
    {
        static int x0 = 1;
        static int x1 = 1;
        static int x2;
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
            catch(Exception exp)
            {
                Console.WriteLine("\n" + exp.Message);
            }
            
            Console.ReadLine();
        }

        public static void Count()
        {
            lock (locker)
            {
                
                    x2 = x1 + x0;
                    x1 = x0;
                    x0 = x2;
                    Console.WriteLine("{0}: {1}", Thread.CurrentThread.Name, x0);

                    Thread.Sleep(100);
                
            }
        }

    }
}

