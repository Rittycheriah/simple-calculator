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
        Regex TooManyConstantsPattern = new Regex(@"\s*([a-z]{1})+\s*([a-z]{1})\s*([=])\s*(\d+)");

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
                // this is still failing. not sure why. have played with regex, but 
                // no results yet. 
                return false;
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
