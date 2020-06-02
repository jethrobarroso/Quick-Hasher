using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickHash.Gen;

namespace QuickHash.ConsoleNet
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintHeader();

            string psw = @"Q@zw1234";
            bool ImIn = false;
            while (!ImIn)
            {
                Console.Write("Password: ");
                Console.CursorVisible = false;

                if (psw.Equals(PromptPass()))
                    ImIn = true;
                else
                    Console.WriteLine("\nInvalid password. Please try again...\n");

            }

            Console.Clear();
            PrintHeader();
            Console.CursorVisible = true;

            HashGenerator gen;

            while (true)
            {
                Console.WriteLine("Insert a string to generate hash or ctrl+c to quit:");
                string input = Console.ReadLine();

                gen = new HashGenerator(input);

                Console.WriteLine($"\nOutput: {gen.HashIt()}\n");
                Console.Write("Export token? (y/n): ");

                if (Console.ReadLine() == "y")
                {
                    gen.ExportTokenFile();
                    Console.WriteLine("\nFile exported to desktop...");
                }

                Console.WriteLine("\nPress any key to restart or ctrl+c to quit...");
                Console.ReadLine();
                Console.Clear();
                PrintHeader();
            }
        }

        private static string PromptPass()
        {
            bool contReading = true;
            StringBuilder sb = new StringBuilder();

            char newLineChar = '\r';

            while (contReading)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
                char pswChar = consoleKeyInfo.KeyChar;

                if (pswChar == newLineChar)
                    contReading = false;
                else
                    sb.Append(pswChar.ToString());
            }

            return sb.ToString();
        }

        private static void PrintHeader()
        {
            string header = @"
 _____            _____            
/  __ \          |  __ \           
| /  \/_ __ _   _| |  \/ ___ _ __  
| |   | '__| | | | | __ / _ \ '_ \ 
| \__/\ |  | |_| | |_\ \  __/ | | |
 \____/_|   \__, |\____/\___|_| |_|
             __/ |                 
            |___/                  " + Environment.NewLine;

            Console.WriteLine(header);

        }
    }
}
