using System;
using System.Diagnostics;
using System.Numerics;

namespace Luke16
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var substring = "472047"; 
            var number = 0;
            for (int i = 1; i < 10000; i++)
            {
                if (BigInteger.Pow(2,i).ToString().Contains(substring))
                {
                    number = i;
                    break;
                }
                
            }
            stopwatch.Stop();
            Console.WriteLine("Found {0} in {1}ms", number, stopwatch.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }
    }
}
