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
            // creates a new RegexProcessor
            RegexUtil regexProcessing = new RegexUtil();

            // extract integers
            ArrayList integers = regexProcessing.ExtractNums(input);

            // extracts operand
            string thisOp = regexProcessing.ExtractsOp(input);

            // holds answer value 
            int answer;

            // make a new instance of the applicable class per the
            // operand extracted
            switch (thisOp)
            {
                case "+":
                    AddIt thisAddExp = new AddIt();
                    answer = thisAddExp.Addition(integers);
                    return answer;
                case "-":
                    SubtractIt thisSubExp = new SubtractIt();
                    answer = thisSubExp.Subtraction(integers);
                    return answer;
                case "*":
                    MultiplyIt thisMultiExp = new MultiplyIt();
                    answer = thisMultiExp.Multiplication(integers);
                    return answer;
                case "/":
                    DivideIt thisDivExp = new DivideIt();
                    answer = thisDivExp.Division(integers);
                    return answer;
                case "%":
                    ModIt thisModExp = new ModIt();
                    answer = thisModExp.Modulation(integers);
                    return answer;
            }

            throw new ArgumentException("Input doesn't contain an operand understood {0}", thisOp);
        }
    }
}
