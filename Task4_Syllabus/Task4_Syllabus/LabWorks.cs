
namespace Task4_Syllabus
{
    /// <summary>
    /// is responsible for the laboratory works logic;
    /// </summary>
    class LabWorks : Discipline
    {
        /// <summary>
        /// override method ToString
        /// </summary>
        /// <returns>discription of class LabWorks</returns>
        public override string ToString()
        {
            return "This is Laboratory Work";
        }

        /// <summary>
        /// deep cloning of class LabWorks
        /// </summary>
        /// <returns>new object of class LabWorks with cloned all fields</returns>
        public object Clone()
        {
            return new LabWorks
            {
                guid = this.guid
            };
        }
    }
}
