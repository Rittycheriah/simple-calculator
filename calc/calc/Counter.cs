using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calc
{
    public class Counter
    {
        public int Count = 0;

        public int CountValue
        {
            get { return Count; }
            set { Count = value; }
        }
    }
}
