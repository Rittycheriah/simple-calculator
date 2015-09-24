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
            var input = Console.ReadLine();
            int inputConverted;
            bool parsedInput = Int32.TryParse(input, out inputConverted);


            if (!parsedInput)
            {
                Console.WriteLine("Improper Input -- please put in an integer");
            } else {
               
            }
        }
    }
}
