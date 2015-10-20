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
        public string Calculate(string input)
        {

            // creates a new RegexProcessor
            RegexUtil regexProcessing = new RegexUtil();

            // extract integers
            ArrayList integers = regexProcessing.ExtractNums(input);

            // extracts operand
            string thisOp = regexProcessing.ExtractsOp(input);

            // holds answer value
            string answer;

            // make a new instance of the applicable class per the
            // operand extracted
            switch (thisOp)
            {
                case "+":
                    AddIt thisAddExp = new AddIt();
                    answer = thisAddExp.Addition(integers).ToString();
                    LastQnA.LastAns = Convert.ToInt32(answer);
                    LastQnA.LastQ = input;
                    return answer;
                case "-":
                    SubtractIt thisSubExp = new SubtractIt();
                    answer = thisSubExp.Subtraction(integers).ToString();
                    LastQnA.LastAns = Convert.ToInt32(answer);
                    LastQnA.LastQ = input;
                    return answer;
                case "*":
                    MultiplyIt thisMultiExp = new MultiplyIt();
                    answer = thisMultiExp.Multiplication(integers).ToString();
                    LastQnA.LastAns = Convert.ToInt32(answer);
                    LastQnA.LastQ = input;
                    return answer;
                case "/":
                    DivideIt thisDivExp = new DivideIt();
                    answer = thisDivExp.Division(integers).ToString();
                    LastQnA.LastAns = Convert.ToInt32(answer);
                    LastQnA.LastQ = input;
                    return answer;
                case "%":
                    ModIt thisModExp = new ModIt();
                    answer = thisModExp.Modulation(integers).ToString();
                    LastQnA.LastAns = Convert.ToInt32(answer);
                    LastQnA.LastQ = input;
                    return answer;
                case "=":
                    answer = "Your value has been set";
                    return answer;
                default: throw new ArgumentException("Input doesn't contain an operand understood {0}", thisOp);
            }
        }
    }
}
