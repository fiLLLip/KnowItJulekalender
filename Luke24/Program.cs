using System;
using System.Diagnostics;

namespace Luke24
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var num = 16;
            while (true)
            {
                var multiplier = 1;
                while (true)
                {
                    if (num < multiplier * 10)
                    {
                        break;
                    }
                    multiplier *= 10;
                }
                if (((6*multiplier) + (num/10)) / 4 == num)
                {
                    break;
                }
                num += 10;
            }
            stopwatch.Stop();
            var nanoseconds = 1000000000.0*stopwatch.ElapsedTicks/Stopwatch.Frequency;
            Console.WriteLine("GOD JUL! Found {0} in {1}ns, {2}ms", num, nanoseconds, nanoseconds/1000000.0);
            Console.ReadLine();
        }
    }
}