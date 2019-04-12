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
    class AveragePriceCommand : ICommand
    {
        AveragePriceAvtos averagePriceCar;
        /// <summary>
        /// Transform class CarsInfo in AveragePriceCars
        /// </summary>
        public AveragePriceCommand(AvtosInfo carInfo)
        {
            if (carInfo is AveragePriceAvtos)
            {
                averagePriceCar = (AveragePriceAvtos)carInfo;
            }
        }

        /// <summary>
        /// call DoCommand in AveragePriceCars class
        /// </summary>
        public string Execute()
        {
            return averagePriceCar.DoCommand();
        }
    }
}
