//1.Даны 2 двумерных матрицы.
//Размерность 100х100 каждая. Напишите приложение, 
//производящее параллельное умножение матриц.
//Матрицы заполняются случайными целыми числами от 0 до10.
//Рощупкин
using System;
using System.Threading.Tasks;

namespace hw6task1
{
    class Program
    {
        static Random rnd;
        private static int[,] GetMatrix(int n)
        {
            rnd = new Random();
            int[,] matrix = new int[n, n];
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j] = rnd.Next(1, 10);
            Console.WriteLine("Matrix1 had been created");

            return matrix;
        }
        // определение асинхронного метода
        static async Task<int[,]>  MultiplyTwoMatrix()
        {
            int[,] m1 = Task.Run(() => GetMatrix(100)).Result;
            int[,] m2 = Task.Run(() => GetMatrix(100)).Result;
            await Task.WhenAll();
            return await Task.Run(() => MultiplyMatrix(m1, m2));
        }

        private static int[,] MultiplyMatrix(int[,] m1, int[,] m2)
        {
            int[,] result = new int[m1.GetLength(0), m2.GetLength(1)];
            Parallel.For(0, m1.GetLength(0), i =>
            {
                for (int j = 0; j < m2.GetLength(1); j++)
                    for (int k = 0; k < m2.GetLength(0); k++)
                        result[i, j] += m1[i, k] * m2[k, j];
            });
            Console.WriteLine("Multiplication had been completed");
            return result;
        }
        public static void Print(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write("{0} ", matrix[i, j]);
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            int[,] result =MultiplyTwoMatrix().Result;
            Print(result);
            Console.ReadLine();
        }
    }
}

