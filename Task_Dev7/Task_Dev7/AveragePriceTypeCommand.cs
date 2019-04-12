using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Dev7
{
    /// <summary>
    /// Command to cause class average price
    /// </summary>
    class AveragePriceTypeCommand : ICommand
    {
        AveragePriceTypeAvtos averagePriceType;
        /// <summary>
        /// Transform class CarsInfo in AveragePriceTypeAvtos
        /// </summary>
        public AveragePriceTypeCommand(AvtosInfo carInfo)
        {
            if (carInfo is AveragePriceTypeAvtos)
            {
                averagePriceType = (AveragePriceTypeAvtos)carInfo;
            }
        }

        /// <summary>
        /// call DoCommand in AveragePriceTypeAvtos class
        /// </summary>
        public string Execute()
        {
            return averagePriceType.DoCommand();
        }
    }
}
