using System.Linq;

namespace Task6_PatternCommandCars
{
    /// <summary>
    /// class responsible for count all cars
    /// </summary>
    class CountTypesCars : CarsInfo
    {
        /// <summary>
        /// cause construtor class CarsInfo (file path)
        /// </summary>
        public CountTypesCars(string filePath)
            : base(filePath)
        {

        }

        /// <summary>
        /// common overriding method
        /// </summary>
        public override string DoCommand()
        {
            return CountTypes();
        }

        /// <summary>
        /// special method for this class
        /// </summary>
        /// <returns>count of all types</returns>
        public string CountTypes()
        {
            return types.Count().ToString();
        }
    }
}
