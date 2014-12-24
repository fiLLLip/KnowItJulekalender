using System;
using System.Collections.Generic;

namespace Luke17
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Dictionary<int, int[]> dict = new Dictionary<int, int[]>
            {
                {0, new[] {4, 6}},
                {1, new[] {6, 8}},
                {2, new[] {7, 9}},
                {3, new[] {4, 8}},
                {4, new[] {3, 9, 0}},
                {5, null},
                {6, new[] {1, 7, 0}},
                {7, new[] {6, 2}},
                {8, new[] {1, 3}},
                {9, new[] {4, 2}}
            };
            var currentValues = new List<int> {1};
            for (var steps = 2; steps <= 10; steps++)
            {
                var newValues = new List<int>();
                foreach (var currentValue in currentValues)
                {
                    if (dict[currentValue] == null)
                    {
                        continue;
                    }
                    newValues.AddRange(dict[currentValue]);
                }
                currentValues = newValues;
            }
            Console.WriteLine("Found {0}", currentValues.Count);
            Console.ReadLine();
        }
    }
}