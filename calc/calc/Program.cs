using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calc
{
    public class Program
    {
        static void Main(string[] args)
        {
            // new counter for program
            Counter thisCounterInst = new Counter();

            // boolean for running program and breaking out of while loop
            bool isRunning = true;

            // while bool = true, run this loop
            while (isRunning)
            {
                // writing the counter
                Console.Write("[" + thisCounterInst.CountValue + "]");

                // accepting the input
                string input = Console.ReadLine();

                // validating that syntax is right and not exiting loop
                ValidInputs validating = new ValidInputs();
                bool ValidateResult = validating.BreakingLoop(input);

                // if not valid result, exit loop
                if (ValidateResult == false)
                {
                    isRunning = false;
                    break;
                }
                else
                {
                    // other wise, valid result -- new Calculator instance
                    Calculator CalculatorInstance = new Calculator();

                    // write the solution for expression
                    Console.WriteLine(CalculatorInstance.Calculate(input));

                    // increment counter
                    thisCounterInst.CountValue = thisCounterInst.Count + 1;
                }
            }
        }
    }
}
