using System;

namespace Task2_RussianPhonetics
{
    class EntryPoint
    {
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
