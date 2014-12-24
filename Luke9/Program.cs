using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace Luke9
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var hashSet = new HashSet<int>();
            var sourceSet = new HashSet<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            for (int i = 100; i < 1000; i++)
            {
                for (int j = 100; j < 1000; j++)
                {
                    var testSet = new HashSet<char>(sourceSet);
                    var temp = (i + j).ToString(CultureInfo.InvariantCulture);
                    var success = true;
                    if (temp.Length == 4)
                    {
                        var temparr = ((i).ToString(CultureInfo.InvariantCulture) +
                                      (j).ToString(CultureInfo.InvariantCulture) + temp);
                        if (temparr.Any(t => !testSet.Remove(t)))
                        {
                            success = false;
                        }
                        if (success)
                        {
                            hashSet.Add(i);
                            hashSet.Add(j);   
                        }
                    }
                    if (temp.Length > 4)
                    {
                        break;
                    }
                }
            }
            stopwatch.Stop();
            Console.WriteLine("Found MIN {0} in {1}ms", hashSet.Min(), stopwatch.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
}
