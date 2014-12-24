using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luke15
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var hashset = new HashSet<int>();
            for (int i = 10; i < 100; i++)
            {
                for (int j = 10; j < 100; j++)
                {
                    var res = i*j;
                    if (res.ToString().Length != 4)
                    {
                        continue;
                    }
                    if (j%10==0 && i%10==0)
                    {
                        continue;
                    }
                    var temp = (j.ToString() + i.ToString()).ToCharArray().OrderBy(t=>t).ToArray();
                    var temp2 = res.ToString().ToCharArray().OrderBy(t => t).ToArray();
                    var success = !temp.Where((t, k) => t != temp2[k]).Any();
                    if (!success)
                    {
                        continue;
                    }
                    Console.WriteLine("Found {0}*{1}={2}", i, j, res);
                    hashset.Add(i*j);
                }
            }
            stopwatch.Stop();
            Console.WriteLine("Found {0} in {1}ms", hashset.Count, stopwatch.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }
    }
}
