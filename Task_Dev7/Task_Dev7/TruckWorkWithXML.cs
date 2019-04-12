namespace Task_Dev7
{
    /// <summary>
    /// class for setting the path and elements of the file with information about trucks
    /// </summary>
    class TruckWorkWithXML : AvtoWorkWithXML
    {
        public TruckWorkWithXML(string filePath) : base (filePath,"trucks","truck")
        {

        }
    }
}
