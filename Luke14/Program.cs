using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Luke14
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            const int limit = 100000;
            var upsidedownchars = new Dictionary<char, char> {{'0', '0'}, {'1', '1'}, {'6', '9'}, {'8', '8'}, {'9', '6'}};
            var count = 0;
            for (int i = 0; i <= limit; i++)
            {
                var temp = i.ToString().ToCharArray();
                var temprev = temp.Reverse().ToArray();
                if (temp.Where((t, j) => !upsidedownchars.ContainsKey(t) || upsidedownchars[t] != temprev[j]).Any())
                {
                    continue;
                }
                count++;
            }
            stopwatch.Stop();
            Console.WriteLine("Found {0} in {1}ms", count, stopwatch.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }
    }
}
