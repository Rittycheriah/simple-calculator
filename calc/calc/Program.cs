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
                Console.Write("[" + thisCounterInst.CountValue + "]");
                string input = Console.ReadLine();
                ValidInputs validating = new ValidInputs();
                bool ValidateResult = validating.BreakingLoop(input);

                if (ValidateResult == false)
                {
                    isRunning = false;
                    break;
                }
                else
                {
                    Calculator CalculatorInstance = new Calculator();
                    Console.WriteLine(CalculatorInstance.Calculate(input));

                    thisCounterInst.CountValue = thisCounterInst.Count + 1;
                }
            }
        }
    }
}
