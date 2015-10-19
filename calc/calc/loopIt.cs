using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace calc
{
    public class loopIt
    {
        public void loop()
        {
            // gets input
            string input = Console.ReadLine();

            // instance of validating input
            ValidInputs ValidateIt = new ValidInputs();
            bool TestResult = ValidateIt.BreakingLoop(input);

            // tests input
            while (TestResult)
            {
                ExecuteFunc thisInstance = new ExecuteFunc();
                thisInstance.Execute(input);
                loopIt NewOne = new loopIt();
            }
        }
    }
}
