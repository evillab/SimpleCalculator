using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Calculator
{
    class FileReader
    {
        string FileName;
        public event EventHandler<KeywordeventArgs> Keyword;
        public event EventHandler UnknownCommand;
        public FileReader(string fn)
        {
            FileName = fn;
        }

        public void LoadFile()
        {
            try
            {
                using (var sr = new StreamReader("Instructions/"+FileName))
                {
                    string line;
                    string[] commandParts;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                        if (line.Split(" ").Length > 1)
                        {
                            commandParts = line.Split(" ");
                            switch(commandParts[0].ToLower())
                            {
                                case Commands.ADD:
                                case Commands.SUBTRUCT:
                                case Commands.MULTIPLY:
                                case Commands.DIVIDE:
                                case Commands.APPLY:
                                    Keyword.Invoke(this, new KeywordeventArgs(commandParts[0], Int32.Parse(commandParts[1])));
                                    break;
                                default:
                                    UnknownCommand.Invoke(this, null);
                                    break;
                            }
                        }
                        else
                        {
                            UnknownCommand.Invoke(this, null);
                        }
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
