using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calc
{
    public static class LastQnA
    {
        private static string lastq = null;

        private static int? lastans = null;
         
        public static string LastQ
        {
            get { return lastq; }
            set { lastq = value; }
        }

        public static int? LastAns
        {
            get { return lastans; }
            set { lastans = value; }
        }
    }
}
