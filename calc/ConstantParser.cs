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
        Regex ConstantPattern = new Regex(@"\s*([a-z]{1})\s*([=])\s*(\d+)");
        Regex TooManyConstantsPattern = new Regex(@"\s*([a-z]{2})\s*([=])\s*(\d+)");

        public bool ConstTest(string input)
        {
            Match ConstantTest = ConstantPattern.Match(input);
            Match TwoConstants = TooManyConstantsPattern.Match(input);

            if (TwoConstants.Success)
            {
                return false;
            }
            else if (ConstantTest.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int ConstNum(string input)
        {
            Match ConstantTest = ConstantPattern.Match(input);

            if (ConstantTest.Success)
            {
                int theValue;
                theValue = int.Parse(ConstantTest.Groups[3].Value);
                return theValue;
            }
            else
            {
                throw new ArgumentException("Constant Doesn't Contain Integer Value");
            }
        }

        public string ConstKey(string input)
        {
            Match ConstantTest = ConstantPattern.Match(input);

            if (ConstantTest.Success)
            {
                string theKey;
                theKey = ConstantTest.Groups[1].Value.ToString();
                return theKey;
            }
            else
            {
                throw new ArgumentException("Constant Doesn't Contain AlphaChar Key");
            }
        }
    }
}
