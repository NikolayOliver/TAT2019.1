namespace Task_Dev7
{
    /// <summary>
    /// class for setting the path and elements of the file with information about cars
    /// </summary>
    class CarWorkWithXML : AvtoWorkWithXML
    {
        public CarWorkWithXML(string filePath) : base(filePath, "cars", "car")
        {

        }
    }
}
