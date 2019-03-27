using System;
using System.Text;

namespace Task4_Syllabus
{
    /// <summary>
    /// is responsible for the lecture logic;
    /// the lecture stores arbitrary non-empty text (maximum length is 10 000 characters), 
    /// and presentation material, including: Content URI (non-empty string), 
    /// indicating the presentation format (value from a fixed set: Unknown, PPT, PDF)
    /// Each lecture can correspond to one (or several) seminar lessons, and one (or several) laboratory lessons.
    /// </summary>
    class Lecture: Discipline
    {
        /// <summary>
        /// Text of lecture
        /// </summary>
        string lectureText;
        /// <summary>
        /// url Presentation of lecture
        /// </summary>
        const string urlPresentasion = @"https://poezd.rw.by/wps/portal/home/rp";
        FormatPresentasion formatPresentasion;
        /// <summary>
        /// Each lecture can correspond to one (or several) seminar lessons, and one (or several) laboratory lessons.
        /// </summary>
        Seminar[] seminars;
        LabWorks[] labs;
        /// <summary>
        /// all information of lecture
        /// </summary>
        StringBuilder descriptionLecture = new StringBuilder();
        int countLabs;
        int countSeminars;
        private readonly string[] lecture = new string[5];
        /// <summary>
        /// use to set a random presentation format, the number of workshops and laboratory work
        /// </summary>
        Random random = new Random();
       /// <summary>
       /// Presentation formats
       /// </summary>
        enum FormatPresentasion
        {
            PPT,
            PDF,
            Unknown
        }

        /// <summary>
        /// indexer, value - text lecture
        /// </summary>
        /// <param name="i">index</param>
        /// <returns></returns>
        public string this[int i]
        {
            get
            {
                return lecture[i];
            }
            set
            {
                countSeminars = random.Next(0, 11);
                countLabs = random.Next(0, 11);

                formatPresentasion = (FormatPresentasion)random.Next(0, 3);
                seminars = new Seminar[countSeminars];

                if (value.Length < 10000 && value.Length > 0)
                {
                    lectureText = value;
                    lecture[i] = value;
                }
                else
                {
                    throw new FormatException("Text lecture should be less than 10000 symbols!");
                }
            }
        }

        /// <summary>
        /// Override ToString method
        /// </summary>
        /// <returns>discription of calss lecture</returns>
        public override string ToString()
        {
            return "This is lecture";
        }
        
        /// <summary>
        /// all description consists of lecture text
        /// count labs and seminars
        /// </summary>
        /// <returns>all description</returns>
        public string GetDescription()
        {
            descriptionLecture.Append("Discription:\n");
            descriptionLecture.Append(lectureText);
            descriptionLecture.Append("\nCount of Labs are ");
            descriptionLecture.Append(countLabs);
            descriptionLecture.Append("\nCount of Seminars are ");
            descriptionLecture.Append(countSeminars);
            return descriptionLecture.ToString();
        }
        
        /// <summary>
        /// deep cloning of class lecture
        /// </summary>
        /// <returns>new object of class lecture with all fields</returns>
        public object Clone()
        {
            return new Lecture
            {
                guid = this.guid,
                lectureText = this.lectureText,
                formatPresentasion = this.formatPresentasion,
                seminars = this.seminars,
                labs = this.labs,
                descriptionLecture = this.descriptionLecture,
                countLabs = this.countLabs,
                countSeminars = this.countSeminars,
                random = this.random,
            };
        }
    }
}
