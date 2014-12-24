using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luke10
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            const int persons = 1500;
            var people = new List<int>();
            for (int i = 1; i <= persons; i++)
            {
                people.Add(i);
            }
            var index = 0;
            while (people.Count > 1)
            {
                //index = (index + 1) % people.Count;
                if (index + 1 > people.Count)
                {
                    index = 0;
                }
                else if (index + 1 >= people.Count)
                {
                    index = -1;
                }
                people.RemoveAt(index + 1); //get the next one drunk
                index++;
            }
            stopwatch.Stop();
            Console.WriteLine("Personr nr {0} is the only sober one, found in {1}ms", people[0], stopwatch.Elapsed.TotalMilliseconds);
            stopwatch.Restart();
            int person = (int) (2*(persons - Math.Pow(2, Math.Floor(Math.Log(persons)/Math.Log(2)))) + 1);
            stopwatch.Stop();
            Console.WriteLine("Personr nr {0} is the only sober one, found in {1}ms", person, stopwatch.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }
    }
}
