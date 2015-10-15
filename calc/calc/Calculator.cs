using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;

namespace calc
{
    public class Calculator
    {
        public int Calculate(string input)
        {
            RegexUtil regexProcessing = new RegexUtil();
            ArrayList integers = regexProcessing.ExtractNums(input);
            string thisOp = regexProcessing.ExtractsOp(input);

            switch (thisOp)
            {
                case "+":
                    AddIt thisExp = new AddIt();

                case 2:
                    Console.WriteLine("Case 2");
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
        }
    }
}
