namespace Task_Dev7
{  
   /// <summary>
   /// Command to cause class CountTypesCars
   /// </summary>
    class CountTypesCommand : ICommand
    {
        CountTypesAvtos countTypesCars;
        /// <summary>
        /// Transform class CarsInfo in CountAllAvtos
        /// </summary>
        public CountTypesCommand(AvtosInfo carInfo)
        {
            if (carInfo is CountTypesAvtos)
            {
                countTypesCars = (CountTypesAvtos)carInfo;
            }
        }

        /// <summary>
        /// call DoCommand in AveragePriceAvtos class
        /// </summary>
        public string Execute()
        {
            return countTypesCars.DoCommand();
        }
    }
}
