using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Luke20
{
    class Program
    {
        private static HashSet<string> set; 
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            set = new HashSet<string>();
            int x = 0, y = 0;
            CheckAll(x, y);
            stopwatch.Stop();
            Console.WriteLine("Found {0} in {1}ms", set.Count, stopwatch.ElapsedMilliseconds);
            Console.ReadLine();
        }

        static void CheckAll(int x, int y)
        {
            if (set.Contains(x + "," + y))
            {
                return;
            }
            if (DigitSum(x,y) <= 19)
            {
                set.Add(x + "," + y);
                set.Add((x*-1) + "," + (y*-1));
                set.Add((x*-1) + "," + y);
                set.Add(x + "," + (y*-1));
                CheckAll(x + 1, y + 1);
                CheckAll(x + 1, y);
                CheckAll(x, y + 1);
            }
        }


        static int DigitSum(int digit1, int digit2)
        {
            int sum = 0;
            digit1 = Math.Abs(digit1);
            digit2 = Math.Abs(digit2);
            while (digit1 != 0)
            {
                sum += digit1 % 10;
                digit1 /= 10;
            }
            while (digit2 != 0)
            {
                sum += digit2 % 10;
                digit2 /= 10;
            }
            return sum;
        }
    }
}
