using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BiggestPrimeIn60s
{
    /// <summary>
    /// This interface describes the display used in the BiggestPrimeIn60s application. 
    /// </summary>
    interface ITimedCalculationDisplay
    {
        /// <summary>
        /// Display a timer. There is no restriction what the display format is: counting down, counting up, print current time, all work.  
        /// </summary>
        /// <param name="tm">current time when the function is called. </param>
        void displayTimeElapsed(DateTime tm);
        /// <summary>
        /// Display the prime number per request from the controller. 
        /// </summary>
        /// <param name="number"></param>
        void displayFinalResult(Object number);
    }
}
