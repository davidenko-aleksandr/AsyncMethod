using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            
            FactorialAsync();
            WriteReadText();
            Console.ReadLine();
        }
         
        static async void FactorialAsync()
        {
            Console.WriteLine("Начало метода Factorial");
            await Task.Run(() => Factorial());
            Console.WriteLine("Конец метода Factorial");
        }
        static int Factorial()
        {
            int n = 1;
            for (int i = 1; i <= 5; i++)
            {
                n *= i;
                Console.WriteLine($"Факториал числа равен{n}");
            }
            return n;
            
        }
        static async void WriteReadText()
        {
            string text = "Simple text";
            using(StreamWriter writer = new StreamWriter("write_read.txt", false, Encoding.UTF8))
            {
                await writer.WriteLineAsync(text);
            }
            using (var sr = new StreamReader("write_read.txt"))
            {
                string result = await sr.ReadToEndAsync();
                Console.WriteLine(result);
            }
        }


    }
}
