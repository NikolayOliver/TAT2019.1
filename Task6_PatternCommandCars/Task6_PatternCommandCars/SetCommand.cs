using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_PatternCommandCars
{
    /// <summary>
    /// class for Dictionary fromStringToCommand
    /// </summary>
    class SetCommand
    {
        /// <summary>
        /// sets the name of the team and number
        /// </summary>
        public Dictionary<string, int> fromStringToCommand = new Dictionary<string, int>()
        {
            {"CountTypes", 0},
            {"CountAll", 1},
            {"AveragePrice", 2},
            {"AveragePriceType", 3},
            {"Exit", 4}
        };
    }
}
