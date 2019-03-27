using System;

namespace Task4_Syllabus
{
    /// <summary>
    /// 
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// Entry point of the programm
        /// </summary>
        /// <param name="args"></param>
        /// <returns 0> all is good</returns>
        /// <returns 1> wrong line input</returns>
        /// <returns 2> Something error</returns>
        static int Main(string[] args)
        {
            try
            {
                var lec = new Lecture();
                lec[0] = "Physics";
                lec[1] = "Mathematics";
                lec[2] = "Prog";
                lec[3] = "radio electronics";
                lec[4] = "Micro";
                Console.WriteLine(lec.GetDescription());

                return 0;
            }
            catch(FormatException fe)
            {
                Console.WriteLine(fe.Message);
                return 1;
            }
            catch
            {
                Console.WriteLine("Something error!");
                return 2;
            }
        }
    }
}
