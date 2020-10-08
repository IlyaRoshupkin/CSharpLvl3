//2. * Написать приложение, выполняющее парсинг CSV-файла 
//    произвольной структуры и сохраняющее его в обычный TXT-файл. 
//    Все операции проходят в потоках. CSV-файл заведомо имеет большой объём.
//    Рощупкин
using System;
using System.IO;
using System.Threading;

namespace hw5task2
{
    class Program
    {
        static StreamReader streamReader;
        static StreamWriter streamWriter;
        static void Main(string[] args)
        {
            try
            {
                streamReader = new StreamReader("csv.csv");
                Thread myThread = new Thread(new ParameterizedThreadStart(Write));

                while (!streamReader.EndOfStream)
                {
                    string str = streamReader.ReadLine();
                    Console.WriteLine(str);
                    myThread.Start(str); 
                }
                streamReader.Close();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }

        private static void Write(object str)
        {
            streamWriter = new StreamWriter("txt.txt");
            string strout = str.ToString().Replace(",", " ");
            streamWriter.WriteLine(strout);
            streamWriter.Close();
            Console.WriteLine(strout);
        }
    }
}
