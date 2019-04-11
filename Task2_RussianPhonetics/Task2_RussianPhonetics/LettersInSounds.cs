using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2_RussianPhonetics
{
    /// <summary>
    /// accepts a string in Russian, checks it for correctness and returns a string from sounds
    /// </summary>
    class LettersInSounds
    {
        /// <summary>
        /// Always ringing Consonants
        /// </summary>
        private const string alwRinging = "лмнрй";
        /// <summary>
        /// Always deaf Consonants
        /// </summary>
        private const string alwDeaf = "хцщч";
        /// <summary>
        /// Vowels
        /// </summary>
        private const string vowel = "аоеияуыэёю";
        /// <summary>
        /// Letter after which russian letters е,ё,ю,я,и have 2 sound
        /// </summary>
        private const string after2Sound = "аое ияуыэёьъю";
        /// <summary>
        /// Pairs ringing - deaf letters
        /// </summary>
        Dictionary<char, char> pairedConsonants = new Dictionary<char, char>
        {
            {'б','п'},
            {'в','ф'},
            {'г','к'},
            {'д','т'},
            {'ж','ш'},
            {'з','с'}
        };
        /// <summary>
        /// pairs vowels
        /// </summary>
        Dictionary<char, char> pairedVowels = new Dictionary<char, char>
        {
            {'е','э'},
            {'ё','о'},
            {'ю','у'},
            {'я','а'},
            {'и','ы'},
        };
        /// <summary>
        /// original string from command line
        /// </summary>
        string originalString;
        /// <summary>
        /// output of this class
        /// </summary>
        StringBuilder soundString = new StringBuilder();
        int indexShockVowel;
        /// <summary>
        /// Check to last soft sign
        /// </summary>
        bool ifLastSoftSign = false;
        /// <summary>
        /// show what kind of letter belongs
        /// </summary>
        WhatLetter whatPastLetter;
        /// <summary>
        /// show what kind of past letter belongs
        /// </summary>
        WhatLetter whatLetter;
        /// <summary>
        /// show what kind of next letter belongs
        /// </summary>
        WhatLetter whatNextLetter;
        /// <summary>
        /// all types of lettes
        /// </summary>
        enum WhatLetter
        {
            PairedRinging = 1,
            NonPairedRinging = 2,
            PairedDeaf = 3,
            NonPairedDeaf = 4,
            ShockVowel = 5,
            NonShockVowel = 6
        }

        public LettersInSounds(string originalStr)
        {
            this.originalString = originalStr.ToLower();
            CheckOnValudString();
            if (originalString[originalString.Length - 1] == 'ь')
            {
                originalString = originalString.Remove(originalString.Length - 1, 1);
                ifLastSoftSign = true;
            }
            
            whatPastLetter = (WhatLetter)WhatIsThisLetter(originalString[0]);
            
            whatLetter = (WhatLetter)WhatIsThisLetter(originalString[0]);
        }
        /// <summary>
        /// check on valud letter
        /// </summary>
        public void CheckOnValudString()
        {
            if(string.IsNullOrEmpty(originalString))
            {
                throw new FormatException();
            }
            int countPlus = 0;
            int countYO = 0;
            int countSyllable = 0;
            foreach (char s in originalString)
            {
                if (s == 'ё')
                {
                    countYO++;
                }
                if (s == '+')
                {
                    countPlus++;
                }
                if ((s < 'a' || s > 'я') && 
                    (s != 'ё' && s != ' ' && s != '+'))
                {
                    throw new FormatException();
                }
            }
            if (countPlus + countYO > 1)
            {
                throw new FormatException();
            }
            foreach (char c in originalString)
            {
                if (vowel.IndexOf(c) != -1)
                {
                    indexShockVowel = originalString.IndexOf(c);
                    countSyllable++;
                }
            }

            if (countSyllable < 1)
            {
                throw new FormatException();
            }
            if (countSyllable == 1 && countPlus > 0 && countYO == 0)
            {
                throw new FormatException();
            }
            if (countSyllable > 1 && countPlus < 1 && countYO == 0)
            {
                throw new FormatException();
            }
            if (originalString.IndexOf('ё') == -1)
            {
                indexShockVowel = originalString.IndexOf('ё');
            }
        }
        /// <summary>
        /// To convert input string to string from sound
        /// </summary>
        /// <returns>output string from sound</returns>
        public string FromLettersToSounds()
        {
            // for the first letter
            SoundOfMiddleLetter(originalString[0], ' ', originalString[1]);

            for (int i = 1; i < originalString.Length - 1; i++)
            {
                SoundOfMiddleLetter(originalString[i], originalString[i - 1], originalString[i + 1]);
            }
            // for the last letter
            SoundOfLastLetter(originalString[originalString.Length - 1], originalString[originalString.Length - 2]);
            return soundString.ToString();
        }
        /// <summary>
        /// convert the last letter to sound
        /// </summary>
        /// <param name="sym">last letter</param>
        /// <param name="pastSym">last but one letter</param>
        public void SoundOfLastLetter(char sym, char pastSym)
        {
            if(sym == '+')
            {
                return;
            }
            // the last paired ringing letter converts to deaf
            // and if last but one ringing letter converts to deaf too
            if ((WhatLetter)WhatIsThisLetter(sym) == WhatLetter.PairedRinging)
            {
                if ((WhatLetter)WhatIsThisLetter(pastSym) == WhatLetter.PairedRinging)
                {
                    soundString.Remove(soundString.Length - 1, 1);
                    soundString.Append(pairedConsonants[pastSym]);
                }
                soundString.Append(pairedConsonants[sym]);
            }
            // nonshock 'о' converts to 'а'
            if (sym == 'о' && (WhatLetter)WhatIsThisLetter(sym) == WhatLetter.NonShockVowel)
            {
                soundString.Append('а');
                return;
            }
            // 'е' 'ё' 'ю' 'я' 'и' convers to 2 or 1 sounds 
            // and soften the past consonants 
            if (pairedVowels.ContainsKey(sym))
            {
                if (after2Sound.Contains(pastSym))
                {
                    soundString.Append("й\'");
                    soundString.Append(pairedVowels[sym]);
                }
                else
                {
                    soundString.Append(pairedVowels[sym]);
                }
            }
            if (pairedVowels.ContainsValue(sym))
            {
                soundString.Append(sym);
            }
            if( ifLastSoftSign)
            {
                soundString.Append('\'');
            }
        }
        /// <summary>
        /// for each type of letter depending on the last or next letter converts them into sounds
        /// </summary>
        /// <param name="sym">considered letter </param>
        /// <param name="pastSym"> past letter</param>
        /// <param name="nextSym">next letter</param>
        public void SoundOfMiddleLetter(char sym, char pastSym, char nextSym)
        {
            if (nextSym == '+')
            {
                soundString.Append(ForShockVowel(sym, pastSym));
                return;
            }
            if (sym == '+')
            {
                whatPastLetter = whatLetter;
                whatLetter = (WhatLetter)WhatIsThisLetter(nextSym);
                return;
            }

            // check what next letter type    
            whatNextLetter = (WhatLetter)WhatIsThisLetter(nextSym);
            // for each letters its own conversions
            switch (whatLetter)
            {
                case WhatLetter.PairedRinging:
                    soundString.Append(ForPairedRinging(sym, nextSym));
                    break;
                case WhatLetter.NonPairedRinging:
                    soundString.Append(ForNonPairedRinging(sym, nextSym));
                    break;
                case WhatLetter.PairedDeaf:
                    soundString.Append(ForPairedDeaf(sym, nextSym));
                    break;
                case WhatLetter.NonPairedDeaf:
                    soundString.Append(ForNonPairedDeaf(sym, nextSym));
                    break;
                case WhatLetter.ShockVowel:
                    soundString.Append(ForShockVowel(sym, pastSym));
                    break;
                case WhatLetter.NonShockVowel:
                    soundString.Append(ForNonShockVowel(sym, pastSym));
                    break;
                default:
                    soundString.Append(sym);
                    break;
            }
            whatPastLetter = whatLetter;
            whatLetter = whatNextLetter;

        }
        /// <summary>
        /// logic conversion for nonshock vowels
        /// </summary>
        /// <param name="sym">considered letter</param>
        /// <param name="pastSym">past letter</param>
        /// <returns>string sound from "sym"</returns>
        public string ForNonShockVowel(char sym, char pastSym)
        {
            if (sym == 'о')
            {
                return 'а'.ToString();
            }
            if (pairedVowels.ContainsKey(sym) )
            {
                if (after2Sound.Contains(pastSym))
                {
                    return ("й\'" + pairedVowels[sym].ToString());
                }
                else
                {
                    return (pairedVowels[sym].ToString());
                }
            }
            return sym.ToString();
        }
        /// <summary>
        /// logic conversion for shock vowels
        /// </summary>
        /// <param name="sym">considered letter</param>
        /// <param name="pastSym">past letter</param>
        /// <returns>string sound from "sym"</returns>
        public string ForShockVowel(char sym, char pastSym)
        {
            if (pairedVowels.ContainsKey(sym))
            {
                if (after2Sound.Contains(pastSym))
                {
                    return ("й\'" + pairedVowels[sym].ToString());
                }
                else
                {
                    return (pairedVowels[sym].ToString());
                }
            }
            return sym.ToString();
        }
        /// <summary>
        /// logic conversion for nonpaired deaf consonants
        /// </summary>
        /// <param name="sym">considered letter</param>
        /// <param name="pastSym">next letter</param>
        /// <returns>string sound from "sym"</returns>
        public string ForNonPairedDeaf(char sym, char nextSym)
        {
            if (pairedVowels.ContainsKey(nextSym) || nextSym == 'ь')
            {
                return (sym.ToString() + '\''.ToString());
            }
            return sym.ToString();
        }
        /// <summary>
        /// logic conversion for paired deaf consonants
        /// </summary>
        /// <param name="sym">considered letter</param>
        /// <param name="pastSym">next letter</param>
        /// <returns>string sound from "sym"</returns>
        public string ForPairedDeaf(char sym, char nextSym)
        {
            if (whatNextLetter == WhatLetter.PairedRinging)
            {
                foreach (char c in pairedConsonants.Keys)
                {
                    if (sym == pairedConsonants[c])
                    {
                        return c.ToString();
                    }
                }
            }
            if (pairedVowels.ContainsKey(nextSym) || nextSym == 'ь')
            {
                return (sym.ToString() + '\''.ToString());
            }
            return sym.ToString();
        }
        /// <summary>
        /// logic conversion for nonpaired ringing consonants
        /// </summary>
        /// <param name="sym">considered letter</param>
        /// <param name="pastSym">next letter</param>
        /// <returns>string sound from "sym"</returns>
        public string ForNonPairedRinging(char sym, char nextSym)
        {
            if (pairedVowels.ContainsKey(nextSym) || nextSym == 'ь')
            {
                return (sym.ToString() + '\''.ToString());
            }
            return sym.ToString();
        }
        /// <summary>
        /// logic conversion for paired ringing consonants
        /// </summary>
        /// <param name="sym">considered letter</param>
        /// <param name="pastSym">next letter</param>
        /// <returns>string sound from "sym"</returns>
        public string ForPairedRinging(char sym, char nextSym)
        {
            if (whatNextLetter == WhatLetter.PairedDeaf || whatNextLetter == WhatLetter.NonPairedDeaf)
            {
                return pairedConsonants[sym].ToString();
            }
            if (pairedVowels.ContainsKey(nextSym) || nextSym == 'ь')
            {
                return (sym.ToString() + '\''.ToString());
            }
            return sym.ToString();
        }
        /// <summary>
        /// indicate type of considered letter
        /// </summary>
        /// <param name="sym">considered letter</param>
        /// <returns>what type of "sym"</returns>
        public int WhatIsThisLetter(char sym)
        {
            if (pairedConsonants.ContainsKey(sym))
            {
                return 1;
            }
            if (alwRinging.Contains(sym))
            {
                return 2;
            }
            if (pairedConsonants.ContainsValue(sym))
            {
                return 3;
            }
            if (alwDeaf.Contains(sym))
            {
                return 4;
            }
            if (pairedVowels.ContainsKey(sym) || pairedVowels.ContainsValue(sym))
            {
                return 6;
            }
            return 0;
        }
    }
}
