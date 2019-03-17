using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2_RussianPhonetics
{
    class LettersInSounds
    {
        private const string alwRinging = "лмнрй";
        private const string alwDeaf = "хцщч";
        private const string vowel = "аоеияуыэёю";
        private const string after2Sound = "аое ияуыэёьъю";
        Dictionary<char, char> pairedConsonants = new Dictionary<char, char>
        {
            {'б','п'},
            {'в','ф'},
            {'г','к'},
            {'д','т'},
            {'ж','ш'},
            {'з','с'}
        };
        Dictionary<char, char> pairedVowels = new Dictionary<char, char>
        {
            {'е','э'},
            {'ё','о'},
            {'ю','у'},
            {'я','а'},
            {'и','ы'},
        };
        string originalString;
        StringBuilder soundString = new StringBuilder();
        int indexShockVowel;
        bool ifLastSoftSign = false;
        WhatLetter whatPastLetter;
        WhatLetter whatLetter;
        WhatLetter whatNextLetter;
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
        public void CheckOnValudString()
        {
            if(string.IsNullOrEmpty(originalString))
            {
                throw new FormatException();
            }
            int countPlus = 0;
            int countYO = 0;
            // количество слогов
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
        public string FromLettersToSounds()
        {
            // для первого символа
            SoundOfMiddleLetter(originalString[0], ' ', originalString[1]);

            for (int i = 1; i < originalString.Length - 1; i++)
            {
                SoundOfMiddleLetter(originalString[i], originalString[i - 1], originalString[i + 1]);
            }
            // для последнего символа
            SoundOfLastLetter(originalString[originalString.Length - 1], originalString[originalString.Length - 2]);
           
            return soundString.ToString();
        }
        public void SoundOfLastLetter(char sym, char pastSym)
        {
            if(sym == '+')
            {
                return;
            }
            if ((WhatLetter)WhatIsThisLetter(sym) == WhatLetter.PairedRinging)
            {
                if ((WhatLetter)WhatIsThisLetter(pastSym) == WhatLetter.PairedRinging)
                {
                    soundString.Remove(soundString.Length - 1, 1);
                    soundString.Append(pairedConsonants[pastSym]);
                }
                soundString.Append(pairedConsonants[sym]);
            }
            if (sym == 'о' && (WhatLetter)WhatIsThisLetter(sym) == WhatLetter.NonShockVowel)
            {
                soundString.Append('а');
                return;
            }
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

    
            whatNextLetter = (WhatLetter)WhatIsThisLetter(nextSym);

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
        public string ForNonPairedDeaf(char sym, char nextSym)
        {
            if (pairedVowels.ContainsKey(nextSym) || nextSym == 'ь')
            {
                return (sym.ToString() + '\''.ToString());
            }
            return sym.ToString();
        }
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
        public string ForNonPairedRinging(char sym, char nextSym)
        {
            if (pairedVowels.ContainsKey(nextSym) || nextSym == 'ь')
            {
                return (sym.ToString() + '\''.ToString());
            }
            return sym.ToString();
        }
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
