using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luke6
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            const int limit = 8000;
            var hash = new HashSet<long>();
            for (int i = 1; i <= limit; i++)
            {
                for (int j = i; j <= limit; j++)
                {
                    hash.Add(j*i);
                }
            }
            stopwatch.Stop();
            Console.WriteLine("Found {0} unique products in {1}ms", hash.Count, stopwatch.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
}
