using System;
using System.Diagnostics;

namespace Luke12
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int fridaythirteenth = 0;
            for (int year = 1337; year <= DateTime.Now.Year ; year++)
            {
                for (int month = 1; month <= 12; month++)
                {
                    if ((new DateTime(year, month, 13)).DayOfWeek == DayOfWeek.Friday)
                    {
                        fridaythirteenth++;
                    }
                }
            }
            stopwatch.Stop();
            Console.WriteLine("{0} friday 13th, found in {1}ms", fridaythirteenth, stopwatch.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }
    }
}
