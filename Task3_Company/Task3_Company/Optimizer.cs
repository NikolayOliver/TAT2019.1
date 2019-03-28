using System.Collections.Generic;

namespace Task3_Company
{
    /// <summary>
    /// aprent class of classes Criteration
    /// </summary>
    abstract class Optimizer
    {
        protected int clientBudget;

        //protected Employee[] employees;

        protected int countLead;
        protected int countSenior;
        protected int countMiddle;
        protected int countJunior;
        protected int[] countChosenProgrammers = new int[4];

        protected Junior junior = new Junior();
        protected Middle middle = new Middle();
        protected Senior senior = new Senior();
        protected Lead lead = new Lead();

        public Optimizer() { }
        public Optimizer(int budget, List<Employee> employees) 
        {
            clientBudget = budget;
            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i] is Lead)
                {
                    countLead++;
                    continue;
                }
                if (employees[i] is Senior)
                {
                    countSenior++;
                    continue;
                }
                if (employees[i] is Middle)
                {
                    countMiddle++;
                    continue;
                }
                if (employees[i] is Junior)
                {
                    countJunior++;
                    continue;
                }
            }
        }
        public abstract int[] Choose();
    }
}
