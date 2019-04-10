namespace Task6_PatternCommandCars
{
    /// <summary>
    /// Command to cause class countAllCars
    /// </summary>
    class CountAllCommand : ICommand
    {
        CountAllCars countAll;
        /// <summary>
        /// Transform class CarsInfo in CountAllCars
        /// </summary>
        public CountAllCommand(CarsInfo carInfo)
        {
            if (carInfo is CountAllCars)
            {
                countAll = (CountAllCars)carInfo;
            }
        }

        /// <summary>
        /// call DoCommand in AveragePriceCars class
        /// </summary>
        public string Execute()
        {
            return countAll.DoCommand();
        }
    }
}
