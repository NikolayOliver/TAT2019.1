using System;
using System.Collections.Generic;

namespace Task3_Company
{
    /// <summary>
    /// The company has employees of 4 qualifications (Junior, Middle, Senior, Lead), 
    /// differing in salary and productivity (higher productivity, higher salary). 
    /// The customer has a certain amount, 
    /// within which he wants to select a team according to one of the three criteria
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// Entry Point of Programm
        /// </summary>
        /// <param name="args">from command line </param>
        /// <returns 0> Everything is good</returns>
        /// <returns 1> Clients budget is more than programmers in company</returns>
        /// <returns 2>Something is wrong</returns>
         
        static int Main(string[] args)
        {
            try
            {
                List<Employee> employeeList;
                Company comp = new Company();
                int budget = 11;
                //if (int.Parse(args[0]) == 1)
                //{
                //    employeeList = comp.GetEmpoyees(new FirstCriteration(budget, comp.employees));
                //}
                employeeList = comp.GetEmpoyees(new FirstCriteration(budget, comp.employees));
                foreach (var k in employeeList)
                {
                    k.AboutMyself();
                }
                return 0;
            }
            catch(OverflowException over)
            {
                Console.WriteLine(over.Message);
                return 1;
            }
            catch(Exception)
            {
                Console.WriteLine("Smth Error!");
                return 2;
            }
        }
    }
}
