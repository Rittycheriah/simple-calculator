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
            if (input == "exit")
            {
                Console.WriteLine("Hasta La Vista!");
                return false;
            }
            else if (input == "quit")
            {
                Console.WriteLine("Hasta La Vista!");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
