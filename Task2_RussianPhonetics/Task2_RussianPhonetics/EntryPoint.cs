using System;

namespace Task2_RussianPhonetics
{
    /// <summary>
    /// program that accepts a sequence of characters (a line) from the command line 
    /// with the highlighted vowel (+) as an argument in Russian,
    /// and converts it into a sound representation (phonemes
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// Entry Point of the program
        /// </summary>
        /// <param name="args">argument of command line</param>
        /// <returns 0>The program worked fine</returns>
        /// <returns 1>Problems with line</returns>
        /// <returns 2>an unexpected error occurred</returns>
        static int Main(string[] args)
        {
            try
            {
                LettersInSounds lettersInSounds = new LettersInSounds(args[0]);
                Console.WriteLine(lettersInSounds.FromLettersToSounds());
                return 0;
            }
            catch (FormatException)
            {
                Console.WriteLine("Nonvalud string");
                return 1;
            }
            catch(Exception)
            {
                Console.WriteLine("Error!");
                return 2;
            }
        }
    }
}
