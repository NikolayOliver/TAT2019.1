using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Dev7
{
    /// <summary>
    /// class responsible for average price all cars
    /// </summary>
    class AveragePriceAvtos : AvtosInfo
    {
        /// <summary>
        /// cause construtor class CarsInfo (file path)
        /// </summary>
        public AveragePriceAvtos(AvtosDataBase avtosDataBase)
            : base(avtosDataBase)
        {

        }

        /// <summary>
        /// common overriding method
        /// </summary>
        public override string DoCommand()
        {
            return AveragePrice();
        }

        /// <summary>
        /// special method for this class
        /// </summary>
        /// <returns>average price of all cars</returns>
        public string AveragePrice()
        {
            int allPrice = 0;
            foreach (var d in avtosDataBase.priceCountTypeAvtos)
            {
                allPrice += d.Value[0];
            }
            return (allPrice / avtosDataBase.CountAllAvtos).ToString();
        }
    }
}
