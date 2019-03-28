using System.Collections.Generic;

namespace Task3_Company
{
    class Company
    {
        Employee jun = new Junior();
        Employee mid = new Middle();
        Employee sen = new Senior();
        Employee lead = new Lead();

        public List<Employee> employees = new List<Employee>();
        List<Employee> choosedEmployees = new List<Employee>();
        int[] countChosenProgrammers;

        public Company()
        {
            for(int i = 0; i < 10; i ++)
            {
                employees.Add(jun);
                employees.Add(mid);
                employees.Add(sen);
                employees.Add(lead);
            }
        }
        public List<Employee> GetEmpoyees(Optimizer opt)
        {
            countChosenProgrammers = opt.Choose();
            for (int i = 0; i < countChosenProgrammers[0]; i++)
			{
			    choosedEmployees.Add(jun);
			}
            for (int i = 0; i < countChosenProgrammers[1]; i++)
			{
			   choosedEmployees.Add(mid);
			}
            for (int i = 0; i < countChosenProgrammers[2]; i++)
			{
                choosedEmployees.Add(sen);
			}
            for (int i = 0; i < countChosenProgrammers[3]; i++)
			{
                choosedEmployees.Add(lead);
			}
            return choosedEmployees;
        }
    }
}
