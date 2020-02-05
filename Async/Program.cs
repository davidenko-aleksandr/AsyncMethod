using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Async
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(new ThreadStart(DoWork));
            thread.Start();

            Thread thread2 = new Thread(new ParameterizedThreadStart(DoWork2));
            thread2.Start(int.MaxValue);

            int j = 0;
            for (int i = 0; i < int.MaxValue; i++)
            {
                j++;
                if (j % 10000 == 0)
                {
                    Console.WriteLine("Main");
                }
            }
            Console.ReadLine();
        }
        static void DoWork()
        {
            int j=0;
            for (int i = 0; i < int.MaxValue; i++)
            {
                j++;
                if (j%10000==0)
                {
                    Console.WriteLine("DoWork");
                }
            }
        }
        static void DoWork2(object obj)
        {
            int j = 0;
            for (int i = 0; i < (int)obj; i++)
            {
                j++;
                if (j % 10000 == 0)
                {
                    Console.WriteLine("DoWork____2");
                }
            }
        }
    }
}
