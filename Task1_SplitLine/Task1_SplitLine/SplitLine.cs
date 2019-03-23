using System;
using System.Collections.Generic;


namespace Task_1_SplitLine
{
    /// <summary>
    /// accepts a sequence of symbols as an argument
    /// and output list of all subsequences (two or more symbols)
    /// in which there are no two consecutive repeated symbols
    /// </summary>
    class SplitLine
    {
        /// <summary>
        /// outing list of all subsequences with two unequal characters in a row
        /// </summary>
        List<string> listSubstring;
        /// <summary>
        /// arg from command line
        /// </summary>
        string line;
        /// <summary>
        /// position of the first symbol or repeating
        /// </summary>
        int startPosition = 0;
        string substring;
        public SplitLine(string line)
        {
            if (String.IsNullOrEmpty(line) || line.Length < 2)
            {
                throw new FormatException();
            }
            this.line = line;
            listSubstring = new List<string>();
        }
        /// <summary>
        /// Add to listsubstring some substring of argsInLine
        /// </summary>
        /// <param name="position"></param>
        public void AddToSubStringList(int position)
        {
            for (int i = 1; i <= position - startPosition; i++)
            {
                substring = line.ToString().Substring(position - i, i + 1);
                if (!listSubstring.Contains(substring))
                    listSubstring.Add(substring);
            }
        }
        /// <summary>
        /// go to each sybmol of argsInLine
        /// find two consecutive repeated symbols
        /// and transfer startposition on position of this symbol
        /// or to work AddToSubStringList()
        /// </summary>
        /// <returns> listSubString - list consisting of all subsequences (two or more symbols)
        /// in which there are no two consecutive repeated symbols
        /// </returns>
        public List<string> ListSubstringFromLine()
        {
            for (int i = 1; i < line.Length; i++)
            {
                if (line[i] != line[i - 1])
                {
                    AddToSubStringList(i);
                }
                else
                {
                    startPosition = i;
                }
            }
            return listSubstring;
        }
    }
