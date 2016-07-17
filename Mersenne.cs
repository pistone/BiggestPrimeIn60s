using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Numerics;
using System.Threading;

namespace BiggestPrimeIn60s
{
    /// <summary>
    /// A "cheating" algorithm that utilizes historical Mersenne conjecture to produces a series of prime numbers. We say it is 
    /// "cheating" because it avoids the laborious work of an Eratosthenes sieve based search algorithm and possibly could produce
    /// a larger prime in 60s. It also demonstrates a strategy similar to a parallel sieve based algorithm. 
    /// 
    /// www.mersenne.org/primes listed all the known number p such that 2^p is a prime. For the sake of this exercises, we use two threads.
    /// One calculates a series of small prime numbers; the goal was to guarantee we have an legitimate answer before time expires, regardless of
    /// machine speed, etc. The other attempts at a larger p, which has a larger chance to time out in some environments. 
    /// </summary>
    class Mersenne : ICalculator
    {
        BigInteger result = new BigInteger(8291); // 2^13 -1
        int [] mersennes = new int [] {13, 17, 19, 31, 61, 89, 107, 127, 521};

        Thread smaller;
        Thread larger;
        public void start() {
            try
            {
                smaller = new Thread(new ThreadStart(attempt_smaller));
                larger = new Thread(new ThreadStart(attemp_larger));
                smaller.Start();
                larger.Start();
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Thread operation failure\n");
            }
        }
        public void end()
        {
        }
        /// <summary>
        /// Try the smaller Mersenne numbers. If finished, first to see if someone else, meaning the attempt of larger numbers
        /// has changed the result, if so, leave the result untouched and exit, otherwise, update the result. 
        /// </summary>
        void attempt_smaller()
        {
            for (int i = 1; i < 5; i++)
            {
                BigInteger oldValue = result;
                BigInteger two = new BigInteger(2);
                BigInteger current = BigInteger.pow(two, mersennes[i]);
                current = BigInteger.Substract(current, new BigInteger(1));
                if (oldValue != Interlocked.CompareExchange(ref result, current, oldvalue))
                {
                    return; // do not write.
                }
                else
                {
                    oldValue = current;
                };
            }
        }
        /// <summary>
        /// Try larger mersenne numbers. Keep anything that we have calculated. 
        /// </summary>
        void attempt_larger()
        {
            for (int i = 5; i < mersennes.Count; i++)
            {
                BigInteger oldValue = result;
                BigInteger two = new BigInteger(2);
                BigInteger current = BigInteger.pow(two, mersennes[i]);
                current = BigInteger.Substract(current, new BigInteger(1));
                Interlocked.Exchange(ref result, current);
            }
        }

        /// <summary>
        /// Result of prime number searching. 
        /// </summary>
        public Object Result
        {
            get
            {
                return result;
            }
        }
    }
}
