using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Dev7
{
    class AvtosDataBase
    {
        public int CountAllAvtos { get; set; }
        public int CountTypesAvtos { get; set; }
        public Dictionary<string, int[]> priceCountTypeAvtos;
        private static AvtosDataBase instance;

        private AvtosDataBase()
        {

        }

        public static AvtosDataBase getInstance()
        {
            if (instance == null)
            {
                instance = new AvtosDataBase();
            }
            return instance;
        }

        public void FillDatabase(AvtoWorkWithXML avtoWorkWithXML)
        {
            CountAllAvtos = avtoWorkWithXML.GetCountAll();
            CountTypesAvtos = avtoWorkWithXML.GetTypes().Count;
            priceCountTypeAvtos = avtoWorkWithXML.GetTypes();
        }

    }
}
