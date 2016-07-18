using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BiggestPrimeIn60s 
{
    /// <summary>
    /// The class analyzes the command line and the user setting to select an algorithm (to search for biggest prime number) and 
    /// a display to show the results. 
    /// </summary>
    class CommandLineOptionParser
    {
    /// This enum selects which algoritm to use. Let's pretend we support the following algorithms. 
    /// 
    /// A sequential, sift based algorithm that has no memory of previous runs.
    /// A stateful sift based algorithm: each time the search starts from what has been remembered from previous runs. For example, the memory includes but not limited 
    /// to which primes whose multiples have been sifted upto which bound.
    /// A multi-thread version of the search algorithm.
    /// A CUDA version of the search, if a supporting GPU is available. 
    /// A cheating algorithm that attempts to find the answer directly. For example, it parses google results of "largest known prime number.". Or if there is a GIMPS server, such information should be available. 
    /// A chearing algorithm that uses the theorem " 2 ^ (2 ^(2 ^ n)) -1 is prime". The theorem doesn't hold but it is known for certain n (for example n less than or equal to 5) it holds. A small n
    /// will defeat most sift based algorithms.  
        public enum PrimeSearchAlgorithms
        {
            SimpleCal, // dummy search for test
            SequentialSift,
            SequentialPersistentSift,
            ConcurrentSift,
            CUDASift,
            AskServer,
            MersenneC,
            UseTheorem
        };
        public enum DisplayChoice
        {
            Text,
            SimpleForm
        };
        PrimeSearchAlgorithms algorithmChoice = PrimeSearchAlgorithms.SimpleCal;
        DisplayChoice displayChoice = DisplayChoice.SimpleForm;
        String[] args; // a local copy of the args.
        ITimedCalculationDisplay display; // display object of the selected display method.
        ICalculator calculator; // calculator object of the selected algorithm.
        public CommandLineOptionParser(String[] args)
        {
            this.args = args;
            foreach (var str in args) {
                if (str.Equals("-textonly", StringComparison.OrdinalIgnoreCase)) {
                    displayChoice = DisplayChoice.Text;
                }
                if (str.Equals("-mersenne", StringComparison.OrdinalIgnoreCase))
                {
                    algorithmChoice = PrimeSearchAlgorithms.MersenneC;
                }
            }
        }
        /// <summary>
        /// Accessor of @display.
        /// </summary>
        public ITimedCalculationDisplay Display {
            get {
                if (display == null)
                {
                    try
                    {
                        display = createDisplay();
                    }
                    catch (NotImplementedException)
                    {
                        display = new SimpleDisplay();
                    }
                }
                return display;
            }
        }

        /// <summary>
        /// Create a display according display choices. 
        /// </summary>
        /// <returns>Display object created or NotImplemented exception will be thrown.</returns>
        ITimedCalculationDisplay createDisplay() 
        {
            if (displayChoice == DisplayChoice.Text)
            {
                return new SimpleDisplay();
            }
            else if (displayChoice == DisplayChoice.SimpleForm)
            {
                return new SimpleFormDisplay();
            }
            throw new NotImplementedException();
        }
        /// <summary>
        /// Accessor of @calculator
        /// </summary>
        public ICalculator Calculator
        {
            get
            {
                if (calculator == null)
                {
                    if (algorithmChoice ==  PrimeSearchAlgorithms.MersenneC)
                        calculator = new Mersenne();
                    else 
                    calculator = new Mersenne();
                }
                return calculator;
            }
        }
    }
}
