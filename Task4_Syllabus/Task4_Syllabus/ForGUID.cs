using System;

namespace Task4_Syllabus
{
    /// <summary>
    /// use to create an identification number
    /// </summary>
    static class ForGUID
    {
        /// <summary>
        /// extension method
        /// </summary>
        /// <param name="str"></param>
        /// <returns>identification number</returns>
        public static string GuidString(this string str)
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }
    }
}
