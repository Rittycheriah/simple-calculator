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
            Console.WriteLine("[0]>");

            bool isRunning = true;

            while (isRunning)
            {
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
                }
            }
        }
    }
}
