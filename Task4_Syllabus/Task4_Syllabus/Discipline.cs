using System;

namespace Task4_Syllabus
{
    /// <summary>
    /// parent of the class Lecture, LabWorks and Senimar
    /// </summary>
    class Discipline : ICloneable
    {
        /// <summary>
        /// unique identification number for each entity
        /// </summary>
        protected string guid;
        /// <summary>
        /// override ToString
        /// </summary>
        /// <returns>Discription of class</returns>
        public override string ToString()
        {
            return "This is Discipline";
        }

        /// <summary>
        /// Constructor, assigns an identification number
        /// </summary>
        public Discipline()
        {
            guid = guid.GuidString();
        }

        /// <summary>
        /// return identification number of this class
        /// </summary>
        /// <returns>guid</returns>
        public string GetGuid()
        {
            return guid;
        }

        /// <summary>
        /// Override Equals method 
        /// </summary>
        /// <param name="obj">some object but work only with class Discipline</param>
        /// <returns true> if identification numbers equal</returns>
        /// <returns false> if identification numbers nonequal</returns>
        public override bool Equals(object obj)
        {
            if (obj is Discipline)
            {
                Discipline dis = (Discipline)obj;
                return (dis.GetGuid()).Equals(guid);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// deep cloning
        /// </summary>
        /// <returns>class Discipline with all cloned fields</returns>
        public object Clone()
        {
            return new Discipline
            {
                guid = this.guid
            };
        }
    }
}
