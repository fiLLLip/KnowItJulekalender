using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

namespace Luke7
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var count = new Dictionary<int, int>();
            var img = new Bitmap(@"D:\santa.png");
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    var pixel = img.GetPixel(i, j);
                    var color = pixel.ToArgb();
                    if (count.ContainsKey(color))
                    {
                        count[color]++;
                    }
                    else
                    {
                        count.Add(color, 1);
                    }
                }
            }
            var sortedDict = (from entry in count orderby entry.Value descending select entry.Value).ToArray();
            stopwatch.Stop();
            Console.WriteLine("Found {0} as 10th most popular color in {1}ms", sortedDict[9], stopwatch.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
}
