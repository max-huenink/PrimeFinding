using System;
using System.Linq;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;

namespace PrimeFinding
{
    class Primes
    {
        static Stopwatch sw = new Stopwatch();

        delegate IEnumerable<int> PrimeFinder(int n);

        static void Main(string[] args)
        {
            Console.WriteLine("Limit: ");
            int limit = int.Parse(Console.ReadLine());

            Dictionary<string, PrimeFinder> attempts = new Dictionary<string, PrimeFinder>
            {
                { "Check Not Prime", checkNotPrime },
                { "Optimized Check Not Prime", optimizedCheckNotPrime },
                { "Array Check Not  Prime", arrayCheckNotPrime },
                { "Declan", declan },
                { "Declan Array", declanArray },
                { "Test", test },
                { "Test Array", testArr }
            };

            foreach (KeyValuePair<string, PrimeFinder> x in attempts)
            {
                sw.Start();
                IEnumerable<int> results = x.Value?.Invoke(limit);
                sw.Stop();
                Console.WriteLine($"{x.Key} found {results.Where(i => i != 0).Count()} in {sw.ElapsedMilliseconds}ms");
                sw.Reset();
            }
            Console.ReadLine();
        }
        static PrimeFinder checkNotPrime = n =>
        {
            // This method is deprecated because the implementation was stupid
            Console.WriteLine("checkNotPrime is deprecated because the implementation was stupid");
            return new int[] { 0 };
        };
        static PrimeFinder optimizedCheckNotPrime = n =>
        {
            // This method is deprecated because the implementation was stupid
            Console.WriteLine("optimizedCheckNotPrime is deprecated because the implementation was stupid");
            return new int[] { 0 };
        };
        static PrimeFinder arrayCheckNotPrime = n =>
        {
            // This method id deprecated because the implementation was stupid
            Console.WriteLine("arrayCheckNotPrime is deprecated because the implementation was stupid");
            return new int[] { 0 };
            int k = 0;
            int[] primes = new int[n];
            for (int i = 2; i < n; i++)
            {
                primes[k] = i;
                k++;
            }
            for (int p = 2; p < (int)Math.Ceiling(Math.Sqrt(n)); p++)
            {
                for (int j = p * p; j < n; j += p)
                {
                    int exist = Array.Find(primes, element => element == j);
                    if (exist != 0)
                    {
                        int index = Array.IndexOf(primes, j);
                        primes[index] = 0;
                    }
                }
            }
            return primes;
        };
        static PrimeFinder test = n =>
        {
            List<int> primes = new List<int> { 2 };
            for (int i = 3; i < n; i += 2)
            {
                bool fail = false;
                int sqrt = (int)Math.Ceiling(Math.Sqrt(i));
                foreach (int prime in primes)
                {
                    if (i % prime <= 0) { fail = true; break; }
                    if (prime > sqrt) { break; }
                }
                if (!fail)
                {
                    primes.Add(i);
                }
            }
            return primes;
        };

        static PrimeFinder testArr = n =>
        {
            int[] primes = new int[n];
            int count = 1;
            primes[0] = 2;
            for (int i = 3; i < n; i += 2)
            {
                bool fail = false;
                int sqrt = (int)Math.Ceiling(Math.Sqrt(i));
                foreach (int prime in primes)
                {
                    if (prime == 0) { break; }
                    if (i % prime <= 0) { fail = true; break; }
                    if (prime > sqrt) { break; }
                }
                if (!fail)
                {
                    primes[count] = i;
                    count++;
                }
            }
            return primes;
        };
        static PrimeFinder declan = n =>
        {
            List<int> primes = new List<int> { 2 };
            int i = 3;
            do
            {
                bool fail = false;
                int sqrt = (int)Math.Ceiling(Math.Sqrt(i));
                for (int j = 0; j < primes.Count; j++)
                {
                    int k = primes[j];
                    if (i % k <= 0) { fail = true; break; }
                    if (k > sqrt) { break; }
                }
                if (!fail)
                {
                    primes.Add(i);
                }
                i += 2;
            } while (i < n);
            return primes;
        };
        static PrimeFinder declanArray = n =>
        {
            int[] primes = new int[n];
            int count = 1;
            int i = 3;
            primes[0] = 2;
            do
            {
                bool fail = false;
                int sqrt = (int)Math.Ceiling(Math.Sqrt(i));
                for(int j = 0; j < count; j++)
                {
                    int k = primes[j];
                    if (i % k <= 0) { fail = true; break; }
                    if (k > sqrt) { break; }
                }
                if (!fail)
                {
                    primes[count] = i;
                    count++;
                }
                i += 2;
            } while (i < n);
            return primes;
        };
    }
}