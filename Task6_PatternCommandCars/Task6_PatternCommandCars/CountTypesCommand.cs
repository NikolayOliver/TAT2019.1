namespace Task6_PatternCommandCars
{
    /// <summary>
    /// Command to cause class CountTypesCars
    /// </summary>
    class CountTypesCommand : ICommand
    {
        CountTypesCars countTypesCars;
        /// <summary>
        /// Transform class CarsInfo in CountAllCars
        /// </summary>
        public CountTypesCommand(CarsInfo carInfo)
        {
            if (carInfo is CountTypesCars)
            {
                countTypesCars = (CountTypesCars)carInfo;
            }
        }

        /// <summary>
        /// call DoCommand in AveragePriceCars class
        /// </summary>
        public string Execute()
        {
            return countTypesCars.DoCommand();
        }
    }
}
