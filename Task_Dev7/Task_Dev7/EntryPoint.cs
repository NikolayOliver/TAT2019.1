using System;

namespace Task_Dev7
{
    /// <summary>
    /// the program loading from 2 files in xml format the following information about cars and trucks in stock: 
    /// mark,model,quantity, the cost of one unit.
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// EntryPoint
        /// </summary>
        /// <param name="args"> args[0] - file path</param>
        /// <returns 0>All is good</returns>
        /// <returns 1>Wrong with command</returns>
        /// <returns 2>something error</returns>
        static int Main(string[] args)
        {
            try
            {
                var setCommand = new WorkerWithClient(args[0], args[1]);
                setCommand.WorkWithClient();
                return 0;
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
                return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 2;
            }
        }
    }
}
