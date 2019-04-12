using System.Collections.Generic;
using System.Xml.Linq;

namespace Task_Dev7
{
    /// <summary>
    /// class work with XML file 
    /// and takes from there information about avtos
    /// </summary>
    abstract class AvtoWorkWithXML
    {
        /// <summary>
        /// information about cars 
        /// string - type
        /// int[0] - all price cars in type
        /// int[1] - count type cars
        /// </summary>
        protected Dictionary<string, int[]> types = new Dictionary<string, int[]>();
        protected int countAll = 0;
        string filePath;
        XDocument xmlDoc;
        string mainElementInXml;
        string elementInXml;
        /// <summary>
        /// load xmlFile
        /// </summary>
        public AvtoWorkWithXML(string filePath, string mainElementInXml, string elementInXml)
        {
            this.filePath = filePath;
            xmlDoc = XDocument.Load(filePath);
            this.mainElementInXml = mainElementInXml;
            this.elementInXml = elementInXml;
            WorkWithXml();
        }
        /// <summary>
        /// Work with XmlFile 
        /// and puts information into variables
        /// </summary>
        void WorkWithXml()
        {
            foreach (XElement carElement in xmlDoc.Element(mainElementInXml).Elements(elementInXml))
            {
                string typeElement = carElement.Element("type").Value;
                int? priceElement = (int?)(int.Parse(carElement.Element("price").Value));
                if (typeElement != null && priceElement != null)
                {
                    AddToTypes(typeElement, (int)priceElement);
                    countAll++;
                }
            }
        }

        public int GetCountAll()
        {
            return countAll;
        }

        public Dictionary<string, int[]> GetTypes()
        {
            return types;
        }

        /// <summary>
        /// Add to types information about cars
        /// if this type is not, then it adds
        /// or add price  and count type cars
        /// </summary>
        void AddToTypes(string type, int price)
        {
            int[] k = new int[]
            {
                0,0
            };
            if (types.ContainsKey(type))
            {
                types[type][0] += price;
                types[type][1]++;
            }
            else
            {
                types.Add(type, k);
                types[type][0] = price;
                types[type][1] = 1;
            }
        }
    }
}
