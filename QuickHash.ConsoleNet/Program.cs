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
            bool imIn = false;
            bool validDate = false;
            string date = string.Empty;

            while (!imIn)
            {
                Console.Write("Password: ");
                Console.CursorVisible = false;

                if (psw.Equals(PromptPass()))
                    imIn = true;
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
                string wordInput = Console.ReadLine();

                gen = new HashGenerator(wordInput);
                int failCount = 0;

                do
                {
                    if (failCount > 0)
                        Console.WriteLine("\nInvalid date. Please use the format dddd-mm-yy, for example 2020-08-20:");
                    else
                    {
                        Console.WriteLine("\nSpecify the date that the token should be valid for.");
                        Console.WriteLine("Use the format dddd-mm-yy, for example 2020-08-20: ");
                    }

                    date = Console.ReadLine();
                    if (!(validDate = InputHelper.ValidateDate(date)))
                        failCount++;
                    
                } while (!validDate);

                date = InputHelper.StripHyphens(date);

                Console.WriteLine($"\nOutput: {gen.HashIt(date)}\n");
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
