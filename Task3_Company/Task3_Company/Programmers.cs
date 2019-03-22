using System;
namespace Task3_Company
{
    /// <summary>
    /// All this class discribe each of type programmers
    /// </summary>
    class Junior : Employee
    {
        private const float salary = 1;
        private const float perfomance = 1;
        public override float GetSalary()
        {
            return salary;
        }
        public override float GetPerfomance()
        {
 	        return perfomance;
        }
        public override void AboutMyself()
        {
            Console.WriteLine("Junior");
        }
    }
    class Middle : Junior 
    {
        private const float salary = 2;
        private const float perfomance = 3;
        public override float GetSalary()
        {
            return salary;
        }
        public override float GetPerfomance()
        {
            return perfomance;
        }
        public override void AboutMyself()
        {
            Console.WriteLine("Middle");
        }
    }
    class Senior : Middle
    {
        private const float salary = 5;
        private const float perfomance = 7;
        public override float GetSalary()
        {
            return salary;
        } 
        public override float GetPerfomance()
        {
            return perfomance;
        }
        public override void AboutMyself()
        {
            Console.WriteLine("Senior");
        }
    }
    class Lead : Senior 
    {
        private const float salary = 8;
        private const float perfomance = 11;
        public override float GetSalary()
        {
            return salary;
        }
        public override float GetPerfomance()
        {
            return perfomance;
        }
        public override void AboutMyself()
        {
            Console.WriteLine("Lead");
        }
    }
}
