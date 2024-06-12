using BabkinsDashBoardPlugins.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stringlenghttest
{
    public class StringLength : IPlugin
    {
        public string Explanation
        {
            get
            {
                return "Gets a string as parameter and returns the string length in characters.";
            }
        }

        public string Name
        {
            get
            {
                return "strlength";
            }
        }

        public void Go(string parameters)
        {
            Console.WriteLine(parameters.Length);
        }
    }
}