using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        public static object Locker = new object();
        static void Main(string[] args)
        {
            //Console.WriteLine("Begin Main");

            //DoWorcAsync();
            //Console.WriteLine("Continue Main");

            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine("Main");
            //}
            //Console.WriteLine("End Main");
            //Console.ReadLine();
            var result = SaveFileAsync("e:\\test.txt");
            var imput = Console.ReadLine();
            Console.WriteLine(result.Result);

        }


        //static async Task DoWorcAsync()
        //{
        //    Console.WriteLine("Begin Async");
        //    await Task.Run(() => Dowork());
        //    Console.WriteLine("End Async");
        //}
        //static void Dowork()
        //{
            
        //    for (int i = 0; i < 10; i++)
        //    {
                               
        //            Console.WriteLine("DoWork");
                
        //    }
        //}
        static async Task<bool> SaveFileAsync(string path)
        {
            var result = await Task<bool>.Run(() => (SaveFile(path)));
            return result;
        }
        static bool SaveFile(string path)
        {
            lock (Locker)
            {
                var rnd = new Random();
                var text = "";
                for (int i = 0; i < 100; i++)
                {
                    text += rnd.Next();
                    Console.WriteLine(text);
                }
                using (var sw = new StreamWriter("e://test.txt", true, Encoding.UTF8))
                {
                    sw.WriteLine(text);
                }
                return true;
            }
        }


    }

}
