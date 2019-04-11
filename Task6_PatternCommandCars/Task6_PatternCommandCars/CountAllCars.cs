namespace Task6_PatternCommandCars
{
    /// <summary>
    /// class responsible for count all cars
    /// </summary>
    class CountAllCars : CarsInfo
    {
        /// <summary>
        /// cause construtor class CarsInfo (file path)
        /// </summary>
        public CountAllCars(string filePath)
            : base(filePath)
        {

        }

        /// <summary>
        /// common overriding method
        /// </summary>
        public override string DoCommand()
        {
            return CountAll();
        }

        /// <summary>
        /// special method for this class
        /// </summary>
        /// <returns>count of all cars</returns>
        public string CountAll()
        {
            return countAll.ToString();
        }
    }
}
