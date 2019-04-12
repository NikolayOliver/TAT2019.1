namespace Task_Dev7
{    /// <summary>
     /// class responsible for count all cars
     /// </summary>
    class CountAllAvtos : AvtosInfo
    {
        /// <summary>
        /// cause construtor class CarsInfo (file path)
        /// </summary>
        public CountAllAvtos(AvtosDataBase avtosDataBase) : base (avtosDataBase)
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
            return avtosDataBase.CountAllAvtos.ToString();
        }
    }
}
