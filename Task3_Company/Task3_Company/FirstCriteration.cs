using System;
using System.Collections.Generic;

namespace Task3_Company
{
    /// <summary>
    /// Maximum productivity within the sum
    /// </summary>
    class FirstCriteration : Optimizer
    {
        private float[,] connCoefCount = new float[3, 4];
        /// <summary>
        /// 0 row - coefficient = perfomance / salary
        /// 1 row - count each type of programmers
        /// 2 row - salary each type of programmers
        /// </summary>
        /// <param name="budget">client budget</param>
        /// <param name="employees">list of all programmers in company</param>
        public FirstCriteration(int budget, List<Employee> employees) : base(budget,employees) 
        {
            connCoefCount[0, 0] = junior.GetPerfomance() / junior.GetSalary();
            connCoefCount[0, 1] = middle.GetPerfomance() / middle.GetSalary();
            connCoefCount[0, 2] = senior.GetPerfomance() / senior.GetSalary();
            connCoefCount[0, 3] = lead.GetPerfomance() / lead.GetSalary();
            connCoefCount[1, 0] = countJunior;
            connCoefCount[1, 1] = countMiddle;
            connCoefCount[1, 2] = countSenior;
            connCoefCount[1, 3] = countLead;
            connCoefCount[2, 0] = junior.GetSalary();
            connCoefCount[2, 1] = middle.GetSalary() ;
            connCoefCount[2, 2] = senior.GetSalary();
            connCoefCount[2, 3] = lead.GetSalary();
        }
        /// <summary>
        /// fill massive countChosen programmers
        /// 0 index - junior
        /// 1 index - middle
        /// 2 index - senior
        /// 3 index - lead
        /// </summary>
        /// <returns>this massive</returns>
        public override int[] Choose()
        {
            int indexMaxCoef = 0;
            float maxCoef = 0;
            while (clientBudget > lead.GetSalary())
            {
                if (connCoefCount[0,0] == 0 && connCoefCount[0,1] == 0 &&
                    connCoefCount[0,2] == 0 && connCoefCount[0,3] == 0)
                {
                    throw new OverflowException("Do not enough people in our company!");
                }
                for (int i = 0; i < 4; i++)
                {
                    if (connCoefCount[0, i] > maxCoef)
                    {
                        maxCoef = connCoefCount[0, i];
                        indexMaxCoef = i;
                    }
                }
                Console.Write("Max coef = " + maxCoef + " ");
                Console.WriteLine("index = " + indexMaxCoef);
                if (connCoefCount[1, indexMaxCoef] < clientBudget / connCoefCount[2, indexMaxCoef])
                {
                    countChosenProgrammers[indexMaxCoef] = (int)connCoefCount[1, indexMaxCoef];
                }
                else
                {
                    countChosenProgrammers[indexMaxCoef] = (int)(clientBudget / connCoefCount[2, indexMaxCoef]);
                }
                connCoefCount[0, indexMaxCoef] = 0;
                clientBudget -= (int)connCoefCount[2, indexMaxCoef] * countChosenProgrammers[indexMaxCoef];
                indexMaxCoef = 0;
                maxCoef = 0;
            }
            while (clientBudget > 0)
            {
                if (clientBudget >= senior.GetSalary())
                {
                    countChosenProgrammers[2]++;
                    clientBudget -= (int)senior.GetSalary();
                }
                if (clientBudget >= middle.GetSalary())
                {
                    countChosenProgrammers[1]++;
                    clientBudget -= (int)middle.GetSalary();
                }
                if (clientBudget >= junior.GetSalary())
                {
                    countChosenProgrammers[0]++;
                    clientBudget -= (int)junior.GetSalary();
                }
            }
            return countChosenProgrammers;
        }
        
    }
}
