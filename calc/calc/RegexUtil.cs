using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace calc
{
    // Refactoring this whole problem
    public class RegexUtil
    {
    //    public void MatchKey(string input)
    //    {
    //        Match AddMatch = add_regex.Match(input);
    //        Match DivideMatch = divide_regex.Match(input);
    //        Match MultiMatch = multiply_regex.Match(input);
    //        Match SubMatch = subt_regex.Match(input);
    //        Match ModMatch = mod_regex.Match(input);

    //        if (AddMatch.Success)
    //        {
    //            var value1 = int.Parse(AddMatch.Groups[1].Value);
    //            var value2 = int.Parse(AddMatch.Groups[3].Value);
    //            AddIt addThis = new AddIt();
    //            Console.WriteLine("using AddMatch.Success {0}", input);
    //            Console.ReadLine();
    //        }
    //        else if (DivideMatch.Success)
    //        {
    //            var value1 = int.Parse(DivideMatch.Groups[1].Value);
    //            var value2 = int.Parse(DivideMatch.Groups[3].Value);
    //            DivideIt divideThis = new DivideIt();
    //            string answer = divideThis.Division(value1, value2).ToString();
    //            Console.WriteLine("using DivideMatch.Success {0}", input);
    //            Console.WriteLine(answer);
    //            Console.ReadLine();
    //        }
    //        else if (MultiMatch.Success)
    //        {
    //            var value1 = int.Parse(MultiMatch.Groups[1].Value);
    //            var value2 = int.Parse(MultiMatch.Groups[3].Value);
    //            MultiplyIt multiThis = new MultiplyIt();
    //            string answer = multiThis.Multiplication(value1, value2).ToString();
    //            Console.WriteLine(answer);
    //            Console.ReadLine();
    //        }
    //        else if (SubMatch.Success)
    //        {
    //            var value1 = int.Parse(SubMatch.Groups[1].Value);
    //            var value2 = int.Parse(SubMatch.Groups[3].Value);
    //            SubtractIt subThis = new SubtractIt();
    //            string answer = subThis.Subtraction(value1, value2).ToString();
    //            Console.WriteLine(answer);
    //            Console.ReadLine();
    //        }
    //        else if (ModMatch.Success)
    //        {
    //            var value1 = int.Parse(ModMatch.Groups[1].Value);
    //            var value2 = int.Parse(ModMatch.Groups[3].Value);
    //            ModIt modThis = new ModIt();
    //            string answer = modThis.Modulation(value1, value2).ToString();
    //            Console.WriteLine(answer);
    //            Console.ReadLine();
    //        }
    //        else
    //        {
    //            Console.WriteLine("improper expression -- please try again");
    //        }
    //    }

        // these are the regex's for each type of match 
        Regex add_regex = new Regex(@"(\d+)\s+([+])\s+(\d+)");
        Regex multiply_regex = new Regex(@"(\d+)\s+([*])\s+(\d+)");
        Regex divide_regex = new Regex(@"(\d+)\s+([/])\s+(\d+)");
        Regex subt_regex = new Regex(@"(\d+)\s+([-])\s+(\d+)");
        Regex mod_regex = new Regex(@"(\d+)\s+([%])\s+(\d+)");

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
