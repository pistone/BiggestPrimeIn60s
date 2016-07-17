using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BiggestPrimeIn60s
{
    /// <summary>
    /// An interface that represents the calculator in BiggestPrimeIn60s. It encapsulates the search of
    /// a prime number as big as possible before the search is called off by the main controller of the application.
    /// 
    /// The interface allows all kinds of prime searching. Namely, the algorithms listed "CommandLineOptionParser.cs" can all be implemented
    /// using this interface. 
    /// 
    /// 
    /// </summary>
    interface ICalculator
    {
        /// <summary>
        /// Start searching for prime numbers.
        /// </summary>
        void start();
        /// <summary>
        /// Stop the search for prime numbers. The function should ensures a result can be read afterwards. 
        /// </summary>
        void end();
        /// <summary>
        /// The result of searching for prime numbers, representing the biggest that we found. It is of type Object
        /// as we only care about its string representation. None cheating algoritms may use biginteger. 
        /// </summary>
        Object Result { get; }
    }
}
