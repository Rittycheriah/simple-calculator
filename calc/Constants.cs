using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calc
{
    public static class Constants
    {
        // Dictionary for this instance of calc
        private static Dictionary<string, int> thisInstanceConst = new Dictionary<string, int>();

        // public data member to interact with Dictionary
        public static Dictionary<string, int> SessionConstants 
        {
            get { return thisInstanceConst; }
        }

        // set new key value pair for dictionary
        public static void AddKey2Dictionary(string input1, int input2)
        {
            thisInstanceConst.Add(input1, input2);
        }
    }
}
