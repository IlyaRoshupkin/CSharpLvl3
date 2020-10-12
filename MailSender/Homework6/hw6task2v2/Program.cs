
//2. * В некой директории лежат файлы. По структуре они содержат 3 числа, 
//разделенные пробелами. Первое число — целое, обозначает действие, 1 — умножение 
//и 2 — деление, остальные два — числа с плавающей точкой. 
//Написать многопоточное приложение, выполняющее вышеуказанные действия 
//над числами и сохраняющее результат в файл result.dat. 
//Количество файлов в директории заведомо много.
//Рощупкин
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace hw6task2v2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            StreamWriter streamWriter;
            string FileName = "expressions.txt";
            try
            {
                var results = await CalculateAsync(FileName).ConfigureAwait(true);
                streamWriter = new StreamWriter("result.txt");
                PrintResultAsync("result.dat", results);
                Console.WriteLine("The calculations have been completed successfully");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private static async void PrintResultAsync(
            string FileName, Dictionary<int, double> results)
        {
            using (var writer = new StreamWriter(FileName))
            {
                foreach (var expression in results.Keys)
                    await writer.WriteLineAsync(
                        results[expression].ToString()).ConfigureAwait(false);
            }
        }

        private static async Task<Dictionary<int, double>> CalculateAsync(string FileName)
        {
            var resultDict = new Dictionary<int, double>();
            int expression = 1;
            using (var reader = new StreamReader(FileName))
            {
                while (!reader.EndOfStream)
                {
                    var line = await reader.ReadLineAsync().ConfigureAwait(false);
                    var numbers = line.Split(' ');
                    await Task.Delay(1);

                    foreach (var number in numbers)
                    {
                        switch (int.Parse(numbers[0]))
                        {
                            case 1:
                                resultDict[expression] =
                                    Double.Parse(numbers[1]) * Double.Parse(numbers[2]);
                                break;
                            case 2:
                                resultDict[expression] =
                                    Double.Parse(numbers[1]) / Double.Parse(numbers[2]);
                                break;
                            default:
                                resultDict[expression] = Double.NaN;
                                break;
                        }
                        expression++;
                    }
                }
            }
            return resultDict;
        }
    }
}
