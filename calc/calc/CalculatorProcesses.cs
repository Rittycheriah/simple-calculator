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
        public class RegexUtil
        {

            static Regex add_regex = new Regex(@"(\d+)\s+([+])\s+(\d+)");
            static Regex multiply_regex = new Regex(@"(\d+)\s+([*])\s+(\d+)");
            static Regex divide_regex = new Regex(@"(\d+)\s+([/])\s+(\d+)");
            static Regex subt_regex = new Regex(@"(\d+)\s+([-])\s+(\d+)");
            static Regex mod_regex = new Regex(@"(\d+)\s+([%])\s+(\d+)");

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
                    var value1 = int.Parse(DivideMatch.Groups[1].Value);
                    var value2 = int.Parse(DivideMatch.Groups[3].Value);
                    DivideIt divideThis = new DivideIt();
                    string answer = divideThis.Division(value1, value2).ToString();
                    Console.WriteLine(answer);
                    Console.ReadLine();
                }
                else if (MultiMatch.Success)
                {
                    var value1 = int.Parse(MultiMatch.Groups[1].Value);
                    var value2 = int.Parse(MultiMatch.Groups[3].Value);
                    MultiplyIt multiThis = new MultiplyIt();
                    string answer = multiThis.Multiplication(value1, value2).ToString();
                    Console.WriteLine(answer);
                    Console.ReadLine();
                }
                else if (SubMatch.Success)
                {
                    var value1 = int.Parse(SubMatch.Groups[1].Value);
                    var value2 = int.Parse(SubMatch.Groups[3].Value);
                    SubtractIt subThis = new SubtractIt();
                    string answer = subThis.Subtraction(value1, value2).ToString();
                    Console.WriteLine(answer);
                    Console.ReadLine();
                }
                else if (ModMatch.Success)
                {
                    var value1 = int.Parse(ModMatch.Groups[1].Value);
                    var value2 = int.Parse(ModMatch.Groups[3].Value);
                    ModIt modThis = new ModIt();
                    string answer = modThis.Modulation(value1, value2).ToString();
                    Console.WriteLine(answer);
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("improper expression -- please try again");
                }
            }
        }

        public class loopIt
        {
            static public void Execute(string input)
            {
                string quitStr = "quit";
                string exitStr = "exit";

                do
                {
                    Regex mathExp = new Regex(@"(\d+)\s*([-+*/%])\s*(\d+)");
                    Match mathExpMatch = mathExp.Match(input);

                    if (mathExpMatch.Success)
                    {
                        RegexUtil.MatchKey(input);
                    }
                    else
                    {
                        Console.WriteLine("Improper Input, please try again");
                    }
                }
                while (input != quitStr || input != exitStr);

                if (input == quitStr || input == exitStr)
                {
                    Console.WriteLine("Hasta La Vista Babe!");
                }
            }
        }
    }
}
