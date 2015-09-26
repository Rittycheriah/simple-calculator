using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace calc
{
    public class CalculatorProcesses
    {
        // parsing the individual inputs
        //public class ParseExp
        //{
        //    Regex digit = new Regex(@"\d+");
        //    Regex subOp = new Regex(@"[-]");
        //    Regex divOp = new Regex(@"[/]");
        //    Regex modOp = new Regex(@"[%]");
        //    Regex addOp = new Regex(@"[+]");

        //    public void expression(string inputs)
        //    {
        //        char[] charInputs = inputs.ToArray();

        //        foreach (char input in charInputs)
        //        {
        //            if ("-".Contains(input))
        //            {
        //                var opIndex = charInputs.IndexOf("-");          
        //            }
        //        }
        //    }
        //}

        // Regex expression that works \d+[-+\*%]+\d
        public class RegexUtil
        {

            static Regex add_regex = new Regex(@"(\d+)\s+([+])\s+(\d+)");
            static Regex multiply_regex = new Regex(@"(\d+)+[*]+(\d+)");
            static Regex divide_regex = new Regex(@"(\d+)+[/]+(\d+)");
            static Regex subt_regex = new Regex(@"(\d+)+[-]+(\d+)");
            static Regex mod_regex = new Regex(@"(\d+)+[%]+(\d+)");

            static public void MatchKey(string input)
            {
                Match AddMatch = add_regex.Match(input);
                Match DivideMatch = divide_regex.Match(input);
                Match MultiMatch = multiply_regex.Match(input);
                Match SubMatch = subt_regex.Match(input);
                Match ModMatch = mod_regex.Match(input);

                if (AddMatch.Success)
                {
                    var value1 = int.Parse(AddMatch.Groups[1].Value);
                    var value2 = int.Parse(AddMatch.Groups[3].Value);
                    AddIt addThis = new AddIt();
                    string answer = addThis.Addition(value1, value2).ToString();
                    Console.WriteLine(answer);
                    Console.ReadLine();
                }
                else if (DivideMatch.Success)
                {
                    Console.WriteLine("divide");
                }
                else if (MultiMatch.Success)
                {
                    Console.WriteLine("multiply");
                }
                else if (SubMatch.Success)
                {
                    Console.WriteLine("subtract");
                }
                else if (ModMatch.Success)
                {
                    Console.WriteLine("moddddd");
                }
                else
                {
                    Console.WriteLine("improper exp");
                }
            }
        }

        public class loopIt
        {
            static public void Execute(string input)
            {
                string quitStr = "quit";
                string exitStr = "exit";

                if (input == quitStr || input == exitStr)
                {
                    Console.WriteLine("Bye now! Hasta La Vista");
                    Console.ReadLine();
                }
                else
                {
                    RegexUtil.MatchKey(input);
                }
            }
        }
    }
}
