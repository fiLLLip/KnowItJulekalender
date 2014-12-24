using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luke22
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var result = "";
            for (int i = 1; i <= 50; i++)
            {
                var tested = new HashSet<int>();
                var temp = i;
                while (temp != 1 && !tested.Contains(temp))
                {
                    var supertemp = 0;
                    for (int j = 0; j < temp.ToString().Length; j++)
                    {
                        supertemp += (int)Char.GetNumericValue(temp.ToString()[j]) * (int)Char.GetNumericValue(temp.ToString()[j]);
                    }
                    tested.Add(temp);
                    temp = supertemp;
                }
                if (temp==1)
                {
                    result += i + ",";
                }
            }
            stopwatch.Stop();
            var nanoseconds = 1000000000.0*(double) stopwatch.ElapsedTicks/Stopwatch.Frequency;
            Console.WriteLine("Found {0} in {1}ns, {2}ms", result.TrimEnd(','), nanoseconds, nanoseconds / 1000000.0);
            Console.ReadLine();
        }
    }
}
