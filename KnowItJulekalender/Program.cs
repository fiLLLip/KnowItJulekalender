using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Luke5
{
    class Program
    {
        private HashSet<long> _bigNumbers;
        private char[] _validCharacters;

        public Program()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            _bigNumbers = new HashSet<long>();
            _validCharacters = new []{'1','2','3','4','5','6','7','8','9'};
            var permutations = new Permutations<char>(_validCharacters);
            foreach (IList<char> permutation in permutations)
            {
                var test = permutation.Aggregate("", (current, c) => current + c);
                _bigNumbers.Add(Convert.ToInt64(test));
            }
            stopwatch.Stop();
            Console.WriteLine("Found {0} permutations of 123456789 in {1}ms", _bigNumbers.Count, stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();
            stopwatch.Start();
            var lowestPrime = _bigNumbers.Select(MaxFactorFaster).Min();
            stopwatch.Stop();
            Console.WriteLine("Found {0} as lowest prime factor in {1}ms!", lowestPrime, stopwatch.ElapsedMilliseconds);
            Console.ReadLine();

        }

        static void Main(string[] args)
        {
            new Program();
        }

        static private long MaxFactorFaster(long n)
        {
            unchecked
            {
                while (n > 3 && 0 == (n & 1)) n >>= 1;

                int k = 3;
                long k2 = 9;
                long delta = 16;
                while (k2 <= n)
                {
                    if (n % k == 0)
                    {
                        n /= k;
                    }
                    else
                    {
                        k += 2;
                        if (k2 + delta < delta) return n;
                        k2 += delta;
                        delta += 8;
                    }
                }
            }

            return n;
        }
    }
}
