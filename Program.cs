using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace BiggestPrimeIn60s
{
    class Program
    {
        static ITimedCalculationDisplay display;
        static ICalculator calculator;
        static int count = 0;
        static System.Timers.Timer aTimer;
        const long TIMER_INTERVAL = 1000;
        const long SIXTY_SECONDS = 60000;
        /// <summary>
        /// Main fuction analyzes command line arguments, starts a timer, initializes 
        /// a display that displays progress and final result, as well as the calculation.
        /// When time is up, the calculation is stopped and results are displayed. 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            CommandLineOptionParser parser = new CommandLineOptionParser(args);
            display = parser.Display;
            calculator = parser.Calculator;
            aTimer = new System.Timers.Timer();
            aTimer.Elapsed+=new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval=TIMER_INTERVAL;
            aTimer.Enabled=true;
            calculator.start();
            System.Console.WriteLine("program started...\n");
            System.Console.ReadLine();
        }

        /// <summary>
        /// Called by the time at timer's interval (TIMER_INTERVAL). When time is up,
        /// stops the calculation of prime number, gets the result and displays it. 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            display.displayTimeElapsed(e.SignalTime);
            count++;
            if (count > SIXTY_SECONDS/TIMER_INTERVAL)
            {
                calculator.end();
                display.displayFinalResult(calculator.Result);
                aTimer.Enabled = false; 
            }
        }
    }
}
