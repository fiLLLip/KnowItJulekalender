using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luke18
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
                var text = line.Trim().ToLower().ToCharArray().OrderBy(x => x).Aggregate("", (current, c) => current + c);
                if (dict.ContainsKey(text))
                {
                    dict[text]++;

                }
                else
                {
                    dict.Add(text, 1);
                }
            }
            var max = dict.Values.Max();
            var selected = dict.FirstOrDefault(x => x.Value == max);
            stopwatch.Stop();
            Console.WriteLine("Found {0} with {1} occurences in {2}ms", selected.Key, selected.Value, stopwatch.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
}
