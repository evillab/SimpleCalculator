using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class KeyboardReader
    {
        public event EventHandler ShowHelp;
        public event EventHandler<KeywordeventArgs> Keyword;
        public event EventHandler<LoadFromFileEventArgs> LoadInstructionsFromFile;
        public event EventHandler UnknownCommand; 

        public KeyboardReader()
        {
           
        }
        public void ReadLine()
        {
            string command = Console.ReadLine();
            ParseInput(command);
        }

        void ParseInput(string command)
        {
            string[] commandParts;

            if(command.StartsWith("-f"))
            {
                commandParts = new string[] { Commands.FILENAME , command.Split(" ")[1] };
            }
            else if (command.Split(" ").Length >1)
            {
                commandParts = command.Split(" ");
            }
            else
            {
                commandParts = new string[] {command};
            }

            switch(commandParts[0].ToLower())
            {
                case Commands.HELP:
                    ShowHelp.Invoke(this, null);
                    break;
                case Commands.FILENAME:
                    LoadInstructionsFromFile.Invoke(this, new LoadFromFileEventArgs(commandParts[1]));
                    break;
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
    }
}
