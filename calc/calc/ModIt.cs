﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calc
{
    public class ModIt : CalculatorProcesses
    {
        public int Modulation(int x, int y)
        {
            int answer = x % y;
            return answer;
        }
    }
}
