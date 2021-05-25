using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class App
    {
        KeyboardReader kReader;
        Operations operations;
        int result = 0;
        bool readingFromFile = false;

        public App()
        {
            //Initialize Operation class
            InitOperations();
            //Initialize KeyboardReader Class
            InitKeyboardReader();
        }

        void InitKeyboardReader()
        {
            kReader = new();
            kReader.ShowHelp += DisplayHelp;
            kReader.Keyword += AddNewOperation;
            kReader.UnknownCommand += UnknownCommandError;
            kReader.LoadInstructionsFromFile += LoadInstructionsFromFile;
            WaitForCommand();
        }

        void InitOperations()
        {
            operations = new();
        }

        void DisplayHelp(object sender, EventArgs e)
        {
            Console.WriteLine("Help: ");
            Console.WriteLine("1) Type keyword and a number. " +
                "\nKeyword and number must be seperated by a space character.");
            Console.WriteLine("List of possible keywords:");
            foreach(string key in Commands.CommandsArr)
            {
                Console.WriteLine(key);
            }
            Console.WriteLine("\n");
            Console.WriteLine("2) Type '-f [filename].txt' to load instructions from file. Files are placed in 'Instructions' folder." );
            WaitForCommand();
        }

        void AddNewOperation(object sender,KeywordeventArgs e)
        {
            operations.AddKeyword(e.Keyword);
            operations.AddValue(e.Value);

            if(e.Keyword.Equals(Commands.APPLY))
            {
                CountResult();
                DisplayResult();
            }
            else
            {
                if(!readingFromFile)
                {
                    WaitForCommand();
                }
               
            }
        }

        void LoadInstructionsFromFile(object sender , LoadFromFileEventArgs e)
        {
            readingFromFile = true;
            FileReader fr = new FileReader(e.FileName);
            fr.Keyword += AddNewOperation;
            fr.UnknownCommand += UnknownCommandError;
            fr.LoadFile();
        }

        void WaitForCommand()
        {
            kReader.ReadLine();
        }

        void CountResult()
        {
            operations.PrepareData(); 
            for(int i =0; i< operations.keywords.Count; i++)
            {
                int currValue = operations.values[i];
                switch (operations.keywords[i])
                {
                    case Commands.APPLY:
                        result = currValue;
                        break;
                    case Commands.ADD:
                        result += currValue;
                        break;
                    case Commands.SUBTRUCT:
                        result -= currValue;
                        break;
                    case Commands.MULTIPLY:
                        result *= currValue;
                        break;
                    case Commands.DIVIDE:
                        result /= currValue;
                        break;
                }
            }
           
        }

        void DisplayResult()
        {
            Console.WriteLine("result : " + result);
            Console.ReadLine();
        }

        void UnknownCommandError(object sender , EventArgs e)
        {
            Console.WriteLine("Unknown Command! ");
        }
    }
}
