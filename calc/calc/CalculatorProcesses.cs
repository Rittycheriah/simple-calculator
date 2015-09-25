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
        // Regex expression that works \d+[-+\*%]+\d
        public class RegexUtil
        {
            static Regex add_regex = new Regex(@"\d+[+]+\d");
            static Regex multiply_regex = new Regex(@"\d+[*]+\d");
            static Regex divide_regex = new Regex(@"\d+[/]+\d");
            static Regex subt_regex = new Regex(@"\d+[-]+\d");
            static Regex mod_regex = new Regex(@"\d+[%]+\d");

            static public void MatchKey(string input)
            {
                Match AddMatch = add_regex.Match(input);
                Match DivideMatch = divide_regex.Match(input);
                Match MultiMatch = multiply_regex.Match(input);
                Match SubMatch = subt_regex.Match(input);
                Match ModMatch = mod_regex.Match(input);

                if (AddMatch.Success)
                {
                    Console.WriteLine("add exp");
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
            
        }
    }
}
