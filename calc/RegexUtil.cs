using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace calc
{
    public class RegexUtil
    {
        // these are the regex's for each type of match 
        Regex add_regex = new Regex(@"\s*(\d+|[a-z])\s*([+])\s*(\d+|[a-z])");
        Regex multiply_regex = new Regex(@"\s*(\d+|[a-z])\s*([*])\s*(\d+|[a-z])");
        Regex divide_regex = new Regex(@"\s*(\d+|[a-z])\s*([/])\s*(\d+|[a-z])");
        Regex subt_regex = new Regex(@"\s*(\d+|[a-z])\s*([-])\s*(\d+|[a-z])");
        Regex mod_regex = new Regex(@"\s*(\d+|[a-z])\s*([%])\s*(\d+|[a-z])");
        Regex ConstantPattern = new Regex(@"\s*([a-z]?)\s*([=])\s*(\d+)");
        Regex genExp = new Regex(@"\s*(\d+|[a-z])\s*([+=*/%-])\s*(\d+|[a-z])");

        public bool ConstantValue = false;

        // this method takes out numbers
        public ArrayList ExtractNums(string input)
        {
            // general simple exp match
            Match genExpMatch = genExp.Match(input);
            Match ConstSetMatch = ConstantPattern.Match(input);

            string ConstSet;
            int value1;
            int value2;

            if (genExpMatch.Success)
            {
                // try to parse out the integers
                bool ParseFirstGroup = Int32.TryParse(genExpMatch.Groups[1].Value, out value1);
                bool ParseSecondGroup = Int32.TryParse(genExpMatch.Groups[3].Value, out value2);

                ArrayList TheValues = new ArrayList();

                if (ConstSetMatch.Success)
                {
                    ConstSet = ConstSetMatch.Groups[1].Value;
                    bool ConstSetValue = Int32.TryParse(ConstSetMatch.Groups[3].Value, out value2);
                    Constants.AddKey2Dictionary(ConstSet, value2);
                    TheValues.Add(ConstSet);
                    TheValues.Add(value2);
                    return TheValues;
                }
                // if firstgroup = false, then it is a constant and look it up. 
                // and if ParseSecGroup = true, then it's an integer and add to TheValues
                else if (!ParseFirstGroup && ParseSecondGroup)
                {
                    if (Constants.SessionConstants.TryGetValue(genExpMatch.Groups[1].Value, out value1))
                    {
                        TheValues.Add(value1);
                        TheValues.Add(value2);
                        return TheValues;
                    }
                    else
                    {
                        throw new ArgumentException("No value found for constant");
                    }
                }
                else if (ParseFirstGroup && !ParseSecondGroup)
                {
                    // the reverse situation of the above
                    if (Constants.SessionConstants.TryGetValue(genExpMatch.Groups[3].Value, out value2))
                    {
                        TheValues.Add(value1);
                        TheValues.Add(value2);
                        return TheValues;
                    }
                    else
                    {
                        throw new ArgumentException("Constant value not found");
                    }

                }
                else if (!ParseFirstGroup && !ParseSecondGroup)
                {
                    // if neither passes, then they are both constants and look up their value.

                    if (Constants.SessionConstants.TryGetValue(genExpMatch.Groups[1].Value, out value1) && Constants.SessionConstants.TryGetValue(genExpMatch.Groups[3].Value, out value2))
                    {
                        TheValues.Add(value1);
                        TheValues.Add(value2);
                        return TheValues;
                    }
                    else
                    {
                        throw new ArgumentException("One of the constants wasn't found");
                    }
                }
                else if (ParseFirstGroup && ParseSecondGroup)
                {
                    // then they are both constants and add to the arraylist with the integers
                    TheValues.Add(value1);
                    TheValues.Add(value2);
                    return TheValues;
                }
                
            }

            throw new ArgumentException("Expression syntax is incorrect");
        }

        // this is going to extract which type of expression it is
        public string ExtractsOp(string input)
        {
            Match AddMatch = add_regex.Match(input);
            Match DivideMatch = divide_regex.Match(input);
            Match MultiMatch = multiply_regex.Match(input);
            Match SubMatch = subt_regex.Match(input);
            Match ModMatch = mod_regex.Match(input);
            Match ConstantMatch = ConstantPattern.Match(input);

            if (AddMatch.Success)
            {
                AddIt thisAdd = new AddIt();
                return "+";
            }
            else if (SubMatch.Success)
            {
                SubtractIt thisSub = new SubtractIt();
                return "-";
            }
            else if (MultiMatch.Success)
            {
                MultiplyIt thisMult = new MultiplyIt();
                return "*";
            }
            else if (DivideMatch.Success)
            {
                DivideIt thisDiv = new DivideIt();
                return "/";
            }
            else if (ModMatch.Success)
            {
                ModIt thisMod = new ModIt();
                return "%";
            }
            else if (ConstantMatch.Success)
            {
                return "=";
            }
            else
            {
                throw new ArgumentException("No operator provided");
            }

        }

        public int GetsValue()
        {
            throw new NotImplementedException();
        }
    }
}
