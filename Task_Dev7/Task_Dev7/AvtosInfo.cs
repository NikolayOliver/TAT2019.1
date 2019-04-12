namespace Task_Dev7
{
    /// <summary>
    /// to set the object of class AvtosDataBase 
    /// </summary>
    abstract class AvtosInfo
    {
        protected AvtosDataBase avtosDataBase;

        /// <summary>
        /// set AvtosDataBase
        /// </summary>
        public AvtosInfo(AvtosDataBase avtosDataBase)
        {
            this.avtosDataBase = avtosDataBase;
        }

        /// <summary>
        /// common method for all heirs to this class
        /// </summary>
        /// <returns></returns>
        public abstract string DoCommand();
    }
}
