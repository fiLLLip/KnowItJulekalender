using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Luke23
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var numbers = new HashSet<int>();
            for (var i = 10; i < 1000000; i++)
            {
                for (var j = 10; j < i; j *= 10)
                {
                    var t = (i % j) + (i / j);
                    var number = t * t;
                    if (number != i) continue;
                    numbers.Add(number);
                    break;
                }
            }
            stopwatch.Stop();
            Console.WriteLine("Found {0} in {1}ms", numbers.Count, stopwatch.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
}