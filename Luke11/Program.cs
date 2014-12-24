using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Luke11
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ranges = {7, 17, 41, 541};
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            const int numberOfPrimes = 1000000;
            var primes = GeneratePrimesSieveOfEratosthenes(numberOfPrimes);
            var length = primes.Count;
            var resultSet = new HashSet<int>(primes);
            var queue = new ConcurrentQueue<int[]>();
            Parallel.ForEach(ranges, i =>
            {
                var workQueue = new ConcurrentQueue<int>();
                Parallel.For(0, length - i, j =>
                {
                    var sum = 0;
                    for (int k = 0; k < i; k++)
                    {
                        sum += primes[j + k];
                    }
                    if (resultSet.Contains(sum))
                    {
                        workQueue.Enqueue(sum);
                    }
                });
                queue.Enqueue(workQueue.ToArray());
            });
            resultSet = queue.Aggregate(resultSet, (current, ints) => new HashSet<int>(Intersect(current, ints)));
            var result = resultSet.Min();
            stopwatch.Stop();
            Console.WriteLine("Found {0} in {1}ms", result, stopwatch.Elapsed.TotalMilliseconds);
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

        static IEnumerable<T> Intersect<T>(HashSet<T> firstHashset, IEnumerable<T> second)
        {
            foreach (var tmp in second)
            {
                if (firstHashset.Contains(tmp)) { yield return tmp; }
            }
        }
    }
}
