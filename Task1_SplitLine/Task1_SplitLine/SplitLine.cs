using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        /// arguments from the command line
        /// </summary>
        string[] args;
        /// <summary>
        /// outing list of all subsequences
        /// </summary>
        List<string> listSubstring;
        /// <summary>
        /// args in one line splited ' '
        /// </summary>
        StringBuilder argsInLine;
        /// <summary>
        /// position of the first symbol or repeating
        /// </summary>
        int startPosition = 0;
        string substring;
        public SplitLine(string[] args)
        {
            this.args = args;
            listSubstring = new List<string>();
            argsInLine = new StringBuilder();
            // connect in one string spliting ' '
            foreach (string arg in args)
            {
                argsInLine.Append(arg);
                argsInLine.Append(' ');
            }
            //delete the last ' '
            argsInLine.Remove(argsInLine.Length - 1, 1);
        }
        /// <summary>
        /// Add to listsubstring some substring of argsInLine
        /// </summary>
        /// <param name="position"></param>
        public void AddToSubStringList(int position)
        {
            for (int i = 1; i <= position - startPosition; i++)
            {
                substring = argsInLine.ToString().Substring(position - i, i + 1);
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
            for (int i = 1; i < argsInLine.Length; i++)
            {
                if (argsInLine[i] != argsInLine[i - 1])
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
}
