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
        Regex add_regex = new Regex(@"\s*(\d+)\s+([+])\s+(\d+)");
        Regex multiply_regex = new Regex(@"\s*(\d+)\s+([*])\s+(\d+)");
        Regex divide_regex = new Regex(@"\s*(\d+)\s+([/])\s+(\d+)");
        Regex subt_regex = new Regex(@"\s*(\d+)\s+([-])\s+(\d+)");
        Regex mod_regex = new Regex(@"\s*(\d+)\s+([%])\s+(\d+)");

        // this method takes out numbers
        public ArrayList ExtractNums(string input)
        {
            Regex genExp = new Regex(@"(\d+)\s([+\-%/*])\s(\d+)");

            Match genExpMatch = genExp.Match(input);
            if (genExpMatch.Success)
            {
                ArrayList TheValues = new ArrayList();
                int value1 = int.Parse(genExpMatch.Groups[1].Value);
                int value2 = int.Parse(genExpMatch.Groups[3].Value);
                TheValues.Add(value1);
                TheValues.Add(value2);
                return TheValues;
            }
            else
            {
                throw new ArgumentException("Expression syntax is incorrect");
            }
        }

        // this is going to extract which type of expression it is
        public string ExtractsOp(string input)
        {
            Match AddMatch = add_regex.Match(input);
            Match DivideMatch = divide_regex.Match(input);
            Match MultiMatch = multiply_regex.Match(input);
            Match SubMatch = subt_regex.Match(input);
            Match ModMatch = mod_regex.Match(input);

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
            else
            {
               throw new ArgumentException("No operator provided");
            }

        }
    }
}
