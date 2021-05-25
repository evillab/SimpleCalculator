using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class KeywordeventArgs:EventArgs
    {
        public string Keyword { get; set; }
        public int Value { get; set; }
        public KeywordeventArgs(string keyword,int value)
        {
            Keyword = keyword;
            Value = value;
        }
    }
}
