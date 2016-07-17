using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BiggestPrimeIn60s
{
    /// <summary>
    /// A simple display to test the design. 
    /// </summary>
    class SimpleDisplay : ITimedCalculationDisplay
    {
        /// <summary>
        /// print current time.
        /// </summary>
        /// <param name="tm">Current time</param>
        public void displayTimeElapsed(DateTime tm)
        {
            System.Console.WriteLine("...." + tm);
        }

        /// <summary>
        /// Print a prime number.
        /// </summary>
        /// <param name="num">An object representing the number to be printed.</param>
        public void displayFinalResult(Object num)
        {
            System.Console.WriteLine(" final result is:" + num);
        }
    }
}
