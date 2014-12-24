using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luke21
{
    class Program
    {
        static void Main(string[] args)
        {

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var dict = new Dictionary<string, int>();
            var file = new StreamReader("e:\\words.txt");
            string line;
            while ((line = file.ReadLine()) != null)
            {
                int sum = line.Sum(t => (int) t);
                dict.Add(line,sum);
            }
            var totalsum = 0;
            var count = 0;
            foreach (var i in dict.OrderBy(x => x.Value).Reverse())
            {
                totalsum += i.Value;
                count++;
                if (count >= 42)
                {
                    break;
                }
            }
            stopwatch.Stop();
            Console.WriteLine("Found {0} in {1}ms", totalsum, stopwatch.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
}
