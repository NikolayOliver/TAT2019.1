namespace Task_Dev7
{
    /// <summary>
    /// Command to cause class countAllCars
    /// </summary>
    class CountAllCommand : ICommand
    {
        CountAllAvtos countAll;
        /// <summary>
        /// Transform class CarsInfo in CountAllAvtos
        /// </summary>
        public CountAllCommand(AvtosInfo avtoInfo)
        {
            if (avtoInfo is CountAllAvtos)
            {
                countAll = (CountAllAvtos)avtoInfo;
            }
        }

        /// <summary>
        /// call DoCommand in AveragePriceAvtos class
        /// </summary>
        public string Execute()
        {
            return countAll.DoCommand();
        }
    }
}
