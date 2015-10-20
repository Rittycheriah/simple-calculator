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

                    // try to use one of the default triggers
                    try
                    {
                        if (input == "lastq" || input == " lastq")
                        {
                            // show the last question
                            Console.WriteLine(LastQnA.LastQ);
                        }
                        else if (input == "last" || input == " last")
                        {
                            // show last answer
                            Console.WriteLine(LastQnA.LastAns);
                        }
                        else
                        {
                            // new calculator instance and begin calculation
                            string thisAnswer = CalculatorInstance.Calculate(input);
                            Console.WriteLine(thisAnswer);
                        }
                    } // if not, throw an exception with the message text
                    catch (ArgumentException thisOne)
                    {
                        string response = thisOne.Message;
                        Console.WriteLine(response);
                    }

                    // increment counter
                    thisCounterInst.CountValue = thisCounterInst.Count + 1;
                }
            }
        }
    }
}
