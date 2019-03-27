using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_Syllabus
{
    /// <summary>
    /// is responsible for the seminars logic;
    /// </summary>
    class Seminar : Discipline
    {
        /// <summary>
        /// description of seminar assignments
        /// </summary>
        string tasks;
        /// <summary>
        /// list of test questions and answers to them
        /// </summary>
        Dictionary<string, string> testAnswer = new Dictionary<string, string>();
        
        /// <summary>
        /// initializes with validation field tasks
        /// </summary>
        /// <param name="tasks">description of seminar assignments</param>
        public void AddDescribtionTasks(string tasks)
        {
            if (tasks.Length > 0)
            {
                this.tasks = tasks;
            }
            else
            {
                throw new FormatException("Tasks cannot be empty");
            } 
        }

        /// <summary>
        /// add question - answer in list of test questions and answers to them
        /// </summary>
        /// <param name="question"></param>
        /// <param name="answer"></param>
        public void AddTestAnswer(string question, string answer)
        {
            testAnswer[question] = answer;
        }

        /// <summary>
        /// override method ToString
        /// </summary>
        /// <returns>description of class Seminar</returns>
        public override string ToString()
        {
            return "This is Seminar";
        }

        /// <summary>
        /// deep cloning
        /// </summary>
        /// <returns>create new object of class Seminar with all cloned fields</returns>
        public object Clone()
        {
            return new Seminar
            {
                guid = this.guid,
                tasks = this.tasks,
                testAnswer = this.testAnswer
            };
        }

    }
}
