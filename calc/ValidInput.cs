using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calc
{
    public class ValidInputs
    {
        public bool BreakingLoop(string input)
        {
            if (input == "exit" || input == " exit")
            {
                Console.WriteLine("Hasta La Vista!");
                Console.ReadLine();
                return false;
            }
            else if (input == "quit" || input == " quit")
            {
                Console.WriteLine("Hasta La Vista!");
                Console.ReadLine();
                return false;
            }
            else 
            {
                // starting calculations & will test for syntax of expression
                return true;
            }
        }
    }
}
