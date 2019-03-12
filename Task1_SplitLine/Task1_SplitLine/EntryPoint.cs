using System;

namespace Task_1_SplitLine
{
    /// <summary>
    /// accepts a sequence of symbols as an argument from the command line,
    /// and which outputs to the console all subsequences (two or more symbols)
    /// in which there are no two consecutive repeated symbols
    /// </summary>
    /// <returns> 0 if all is good</returns>
    /// <returns> 1 if args[0] consits of less 2 symbols</returns>
    /// <returns> 2 if there are unforeseen errors</returns>
    class EntryPoint
    {
        /// <summary>
        /// Entry Point of programm
        /// </summary>
        /// <param name="args"></param>
        static int Main(string[] args)
        {
            try
            {
                var splitLine = new SplitLine(args[0]);
                foreach (string substr in splitLine.ListSubstringFromLine();)
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
