using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class LoadFromFileEventArgs:EventArgs
    {
        public string FileName { get; set; }

        public LoadFromFileEventArgs(string filename)
        {
            FileName = filename;
        }
    }
}
