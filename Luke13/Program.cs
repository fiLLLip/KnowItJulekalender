using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luke13
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var primes = new HashSet<int>(GeneratePrimesSieveOfEratosthenes(1000));
            var mirps = new List<int>();
            foreach (var prime in primes)
            {
                if (prime >= 1000)
                {
                    break;
                }
                if (prime.ToString().Length < 2)
                {
                    continue;
                }
                var chararr = prime.ToString().ToCharArray();
                var chararrrev = chararr.Reverse().ToArray();
                if (!chararr.Where((t, i) => t != chararrrev[i]).Any())
                {
                    continue;
                }
                var tempstring = chararrrev.Aggregate("", (current, t) => current + t.ToString());

                if (primes.Contains(Convert.ToInt32(tempstring)))
                {
                    Console.WriteLine("Found {0}", prime);
                    mirps.Add(prime);
                }
                else
                {
                    Console.WriteLine("Skipped {0}", prime);
                }
            }
            stopwatch.Stop();
            Console.WriteLine("Found {0} in {1}ms", mirps.Count, stopwatch.Elapsed.TotalMilliseconds);
            Console.ReadLine();
            
        }

        #region Prime generation
        // stole from http://stackoverflow.com/questions/1042902/most-elegant-way-to-generate-prime-numbers

        // Find all primes up to and including the limit
        public static BitArray SieveOfEratosthenes(int limit)
        {
            BitArray bits = new BitArray(limit + 1, true);
            bits[0] = false;
            bits[1] = false;
            for (int i = 0; i * i <= limit; i++)
            {
                if (bits[i])
                {
                    for (int j = i * i; j <= limit; j += i)
                    {
                        bits[j] = false;
                    }
                }
            }
            return bits;
        }

        public static List<int> GeneratePrimesSieveOfEratosthenes(int n)
        {
            int limit = ApproximateNthPrime(n);
            BitArray bits = SieveOfEratosthenes(limit);
            List<int> primes = new List<int>();
            for (int i = 0, found = 0; i < limit && found < n; i++)
            {
                if (bits[i])
                {
                    primes.Add(i);
                    found++;
                }
            }
            return primes;
        }

        private static int ApproximateNthPrime(int nn)
        {
            var n = (double)nn;
            double p;
            if (nn >= 7022)
            {
                p = (n * Math.Log(n)) + (n * (Math.Log(Math.Log(n)) - 0.9385));
            }
            else if (nn >= 6)
            {
                p = (n * Math.Log(n)) + (n * Math.Log(Math.Log(n)));
            }
            else if (nn > 0)
            {
                p = new[] { 2, 3, 5, 7, 11 }[nn - 1];
            }
            else
            {
                p = 0;
            }

            return (int)p;
        }
        #endregion
    }
}
