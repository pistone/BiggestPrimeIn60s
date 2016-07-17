using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Threading;
using System.Drawing;

namespace BiggestPrimeIn60s
{
    /// <summary>
    /// A simple windows form to display timer info and prime number found. 
    /// </summary>
    class SimpleDisplayForm : Form
    {
        Label timerBox; 
        Label resultBox;
        /// <summary>
        /// Simple form with labels at fixed positions 
        /// </summary>
        public SimpleDisplayForm()
        {
            timerBox = new Label();
            resultBox = new Label();
            timerBox.Location = new Point(20, 20);
            timerBox.Width = 200;
            resultBox.Location = new Point(20, 70);
            this.Controls.Add(timerBox);
            this.Controls.Add(resultBox);
        }

        public void displayTimerText(String s) {
            timerBox.Text = s;
        }

        public void displayResultText(String s)
        {
            resultBox.Text = s;
        }
    }

    /// <summary>
    /// A simple display to test the design. 
    /// </summary>
    class SimpleFormDisplay : ITimedCalculationDisplay
    {
        SimpleDisplayForm form;
        String timerString;
        String resultString;
        /// <summary>
        /// Display current time on windows form.
        /// </summary>
        /// <param name="tm">Current time</param>
        public void displayTimeElapsed(DateTime tm)
        {
            if (form == null)
            {
                timerString = tm.ToString();
                resultString = "97";
                form = new SimpleDisplayForm();
                form.ShowDialog();
            }
            else
            {
                timerString = tm.ToString();
                form.BeginInvoke(new InvokeDelegate(DisplayTimerStringMethod));
                form.BeginInvoke(new InvokeDelegate(DisplayResultStringMethod));
            }
        }
        public delegate void InvokeDelegate();

        /// <summary>
        /// Helper function to display timer info. 
        /// </summary>
        public void DisplayTimerStringMethod()
        {
            form.displayTimerText(timerString);
        }

        /// <summary>
        /// Helper function to display result info. 
        /// </summary>
        public void DisplayResultStringMethod()
        {
            form.displayResultText(resultString);
        }

        /// <summary>
        /// Display a prime number on a windows form.
        /// </summary>
        /// <param name="num">An object representing the number to be printed.</param>
        public void displayFinalResult(Object num)
        {
            resultString = num.ToString();
            form.BeginInvoke(new InvokeDelegate(DisplayResultStringMethod));            
        }
    }

    class SimpleDisplay : ITimedCalculationDisplay
    {
        /// <summary>
        /// print current time on console.
        /// </summary>
        /// <param name="tm">Current time</param>
        public void displayTimeElapsed(DateTime tm)
        {
            System.Console.WriteLine(tm.ToString());
        }

        /// <summary>
        /// Print a prime number on console.
        /// </summary>
        /// <param name="num">An object representing the number to be printed.</param>
        public void displayFinalResult(Object num)
        {
            System.Console.WriteLine(" final result is:" +num.ToString());
        }
    }
}
