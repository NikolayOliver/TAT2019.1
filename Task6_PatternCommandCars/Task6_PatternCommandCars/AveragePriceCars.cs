namespace Task6_PatternCommandCars
{
    /// <summary>
    /// class responsible for average price all cars
    /// </summary>
    class AveragePriceCars : CarsInfo
    {
        /// <summary>
        /// cause construtor class CarsInfo (file path)
        /// </summary>
        public AveragePriceCars(string filePath)
            : base(filePath)
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
            foreach(var d in types)
            {
                allPrice += d.Value[0];
            }
            return (allPrice / countAll).ToString();
        }
    }
}
