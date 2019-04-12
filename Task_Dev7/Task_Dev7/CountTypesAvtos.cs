using System.Linq;

namespace Task_Dev7
{
    /// <summary>
    /// class responsible for count types
    /// </summary>
    class CountTypesAvtos : AvtosInfo
    {
        /// <summary>
        /// cause construtor class CarsInfo (file path)
        /// </summary>
        public CountTypesAvtos(AvtosDataBase avtosDataBase)
            : base(avtosDataBase)
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
            return avtosDataBase.priceCountTypeAvtos.Count().ToString();
        }
    }
}
