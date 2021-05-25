using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Operations
    {
        public List<string> keywords { get;}
        public List<int> values { get;}

        public Operations()
        {
            keywords = new List<string>();
            values = new List<int>();
        }

        public void AddKeyword(string keyword)
        {
           
            keywords.Add(keyword);
        }

        public void AddValue(int val)
        {
            values.Add(val);
        }

        internal void PrepareData()
        {
            keywords.Insert(0, keywords[keywords.Count - 1]);
            keywords.RemoveAt(keywords.Count - 1);

            values.Insert(0, values[values.Count - 1]);
            values.RemoveAt(values.Count - 1);
        }

    }
}
