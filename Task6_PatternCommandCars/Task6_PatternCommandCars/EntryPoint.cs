using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_PatternCommandCars
{
    /// <summary>
    /// the program loading from the file in xml format the following information about cars in stock: 
    /// mark,model,quantity, the cost of one unit.
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// EntryPoint
        /// </summary>
        /// <param name="args"> args[0] - file path</param>
        /// <returns 0>All is good</returns>
        /// <returns 1>Wrong with command</returns>
        /// <returns 2>something error</returns>
        static int Main(string[] args)
        {
            try
            {
                string filePath = args[0];
                var setCommand = new SetCommand();
                string clientChoice;
                var stringCommand = setCommand.fromStringToCommand;
                string typeChoice;
                ICommand command;
                while (true)
                {
                    clientChoice = Console.ReadLine();
                    if (!stringCommand.ContainsKey(clientChoice))
                    {
                        throw new FormatException("Unknown command");
                    }
                    if (clientChoice.Equals("Exit"))
                    {
                        break;
                    }
                    if (stringCommand[clientChoice] == stringCommand["CountTypes"])
                    {
                        command = new CountTypesCommand(new CountTypesCars(filePath));
                        Console.WriteLine(command.Execute());
                    }
                    if (stringCommand[clientChoice] == stringCommand["CountAll"])
                    {
                        command = new CountAllCommand(new CountAllCars(filePath));
                        Console.WriteLine(command.Execute());
                    }
                    if (stringCommand[clientChoice] == stringCommand["AveragePrice"])
                    {
                        command = new AveragePriceCommand(new AveragePriceCars(filePath));
                        Console.WriteLine(command.Execute());
                    }
                    if (stringCommand[clientChoice] == stringCommand["AveragePriceType"])
                    {
                        typeChoice = Console.ReadLine();
                        command = new AveragePriceTypeCommand(new AveragePriceTypeCars(filePath, typeChoice));
                        Console.WriteLine(command.Execute());
                    }
                }
                return 0;
            }
            catch(FormatException fe)
            {
                Console.WriteLine(fe.Message);
                return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 2;
            }
        }
    }
}
