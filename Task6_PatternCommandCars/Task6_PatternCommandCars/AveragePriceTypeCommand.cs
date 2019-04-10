namespace Task6_PatternCommandCars
{
    /// <summary>
    /// Command to cause class average price
    /// </summary>
    class AveragePriceTypeCommand : ICommand
    {
        AveragePriceTypeCars averagePriceType;
        /// <summary>
        /// Transform class CarsInfo in AveragePriceTypeCars
        /// </summary>
        public AveragePriceTypeCommand(CarsInfo carInfo)
        {
            if (carInfo is AveragePriceTypeCars)
            {
                averagePriceType = (AveragePriceTypeCars)carInfo;
            }
        }

        /// <summary>
        /// call DoCommand in AveragePriceTypeCars class
        /// </summary>
        public string Execute()
        {
            return averagePriceType.DoCommand();
        }
    }
}
