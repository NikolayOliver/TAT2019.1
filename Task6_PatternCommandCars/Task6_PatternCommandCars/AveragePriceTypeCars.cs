using System;

namespace Task6_PatternCommandCars
{
    /// <summary>
    /// class responsible for average price type cars
    /// </summary>
    class AveragePriceTypeCars : CarsInfo
    {
        string type;
        /// <summary>
        /// cause construtor class CarsInfo (file path)
        /// and set type
        /// </summary>
        /// <param name="type">type of machine desired</param>
        public AveragePriceTypeCars(string filePath, string type)
            : base(filePath)
        {
            this.type = type;
            if (!types.ContainsKey(type))
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
            return (types[type][0] / types[type][1]).ToString();
        }
    }
}
