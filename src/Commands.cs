using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public static class Commands
    {
        public const string HELP = "help";
        public const string FILENAME = "-f [filename].txt";
        public const string ADD = "add";
        public const string SUBTRUCT = "subtruct";
        public const string MULTIPLY = "multiply";
        public const string DIVIDE = "divide";
        public const string APPLY = "apply";
        public static string[] CommandsArr = new string[] { HELP, ADD,SUBTRUCT,MULTIPLY, DIVIDE, APPLY};
    }
}
