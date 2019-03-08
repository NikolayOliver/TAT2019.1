using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task_1_SplitLine
{
    /// <summary>
    /// accepts a sequence of symbols as an argument from the command line,
    /// and which outputs to the console all subsequences (two or more symbols)
    /// in which there are no two consecutive repeated symbols
    /// </summary>
    class EntryPoint
    {

        static List<string> listSubstring;
        /// <summary>
        /// Entry Point of programm
        /// </summary>
        /// <param name="args"></param>
        static int Main(string[] args)
        {
            try
            {
                if (args[0].Length < 2 && args.Length < 2)
                {
                    throw new FormatException();
                }
                var splitLine = new SplitLine(args);
                listSubstring = splitLine.ListSubstringFromLine();
                foreach (string substr in listSubstring)
                {
                    Console.WriteLine(substr);
                }
                return 0;
            }
            catch (FormatException)
            {
                Console.WriteLine("In the line must be more than 2 symbols");
                return 1;
            }
            catch (Exception)
            {
                Console.WriteLine("Something error!");
                return 2;
            }
        }
    }
}
