using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BiggestPrimeIn60s
{
    /// <summary>
    /// A simple calculator used to test the design of BiggestPrimeIn60s.   
    /// </summary>
    class SimpleCalculator : ICalculator
    {
        int result;
        bool _stopRequested;
        public void start()
        {
            result = 113;
            _stopRequested = false;
            while (!_stopRequested)
            {
                result = 113; // do nothing
            }
            // System.Console.WriteLine("finished\n");
        }

        public void end()
        {
            _stopRequested = true;
        }

        public Object Result
        {
            get
            {
                return result;
            }
        }
    }
}
