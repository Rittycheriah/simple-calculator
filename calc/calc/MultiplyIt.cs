using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calc
{
    public class MultiplyIt : CalculatorProcesses
    {
        private int answer { get; set; }

        public int Multiplication(int x, int y)
        {
            int answer = x * y;
            return answer;
        }
    }
}
