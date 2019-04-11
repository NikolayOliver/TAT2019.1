namespace Task6_PatternCommandCars
{
    /// <summary>
    /// Command to cause class average price
    /// </summary>
    class AveragePriceCommand : ICommand
    {
        AveragePriceCars averagePriceCar;
        /// <summary>
        /// Transform class CarsInfo in AveragePriceCars
        /// </summary>
        public AveragePriceCommand(CarsInfo carInfo)
        {
            if (carInfo is AveragePriceCars)
            {
                averagePriceCar = (AveragePriceCars)carInfo;
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
