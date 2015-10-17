using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace calc
{
    public class ConstantParser
    {
        Regex ConstantPattern = new Regex(@"\s*([a-z]?)\s*([=])\s*(\d+)");
        Regex TooManyConstantsPattern = new Regex(@"\s*([a-z]?)+([a-z]?)\s*([=])\s*(\d+)");

        public bool ConstTest(string input)
        {
            Match ConstantTest = ConstantPattern.Match(input);
            Match TwoConstants = TooManyConstantsPattern.Match(input);

            if (ConstantTest.Success)
            {
                // set constant in constant class
                return true;
            }
            else if (TwoConstants.Success)
            {
                return false;
            }
            else
            {
                return false;
            }
        } 
    }
}
