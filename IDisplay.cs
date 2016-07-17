using System;
using DateTime;

namespace BiggestPrimeIn60s {

    public interface ITimedCalculationDisplay
    {
        public void displayTimeElapsed(DateTime tm);
        public void displayFinalResult(INumber number);
    }
}
