using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luke8
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 1; i < 10000; i++)
            {
                var sum = 0;
                for (int j = 1; j < i; j++)
                {
                    if (i%j == 0) sum += j;
                    if(sum>i) break;
                }
                if (sum==i) Console.Write(i+",");
            }
            Console.WriteLine();
            stopwatch.Stop();
            Console.WriteLine("Finished in {0}ms", stopwatch.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
}
