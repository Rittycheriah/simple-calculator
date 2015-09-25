using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calc
{
    public class Program : CalculatorProcesses 
    {

        static void Main(string[] args)
        {
            Console.WriteLine("[0]>");
            string rawInput = Console.ReadLine();
            RegexUtil.MatchKey(rawInput);
            Console.Read();
        }
    }
}
