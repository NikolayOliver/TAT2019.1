using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Dev7
{
    /// <summary>
    /// class responsible for average price type cars
    /// </summary>
    class AveragePriceTypeAvtos : AvtosInfo
    {
        string type;
        /// <summary>
        /// cause construtor class CarsInfo (file path)
        /// and set type
        /// </summary>
        /// <param name="type">type of machine desired</param>
        public AveragePriceTypeAvtos(AvtosDataBase avtosDataBase, string type)
            : base(avtosDataBase)
        {
            this.type = type;
            if (!avtosDataBase.priceCountTypeAvtos.ContainsKey(type))
            {
                throw new FormatException("No this type");
            }
        }

        /// <summary>
        /// common overriding method
        /// </summary>
        public override string DoCommand()
        {
            return AveragePriceType();
        }

        /// <summary>
        /// special method for this class
        /// [0] -  price type
        /// [1] - count type cars
        /// </summary>
        /// <returns>average price of type cars</returns>
        public string AveragePriceType()
        {
            return (avtosDataBase.priceCountTypeAvtos[type][0] / avtosDataBase.priceCountTypeAvtos[type][1]).ToString();
        }
    }
}
