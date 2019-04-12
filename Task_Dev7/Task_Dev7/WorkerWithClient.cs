using System;
using System.Collections.Generic;

namespace Task_Dev7
{
    /// <summary>
    /// class that interacts with the client 
    /// and makes commands that the client enters
    /// </summary>
    class WorkerWithClient
    {
        string filePathCars;
        string filePathTrucks;
        string clientChoice;
        ICommand command;
        List<ICommand> allCommands;
        AvtosDataBase avtosDataBase;

        /// <summary>
        /// set paths to files with information about cars and trucks 
        /// </summary>
        public WorkerWithClient(string filePathCars, string filePathTrucks)
        {
            this.filePathCars = filePathCars;
            this.filePathTrucks = filePathTrucks;
        }

        /// <summary>
        /// responds to customer commands
        /// </summary>
        public void WorkWithClient()
        {
            avtosDataBase = AvtosDataBase.getInstance();
            var carWorkWithXML = new CarWorkWithXML(filePathCars);
            var truckWorkWithXML = new TruckWorkWithXML(filePathTrucks);
            avtosDataBase.FillDatabase(carWorkWithXML);
            allCommands = new List<ICommand>()
            {
                new CountAllCommand(new CountAllAvtos(avtosDataBase)),
                new AveragePriceCommand(new AveragePriceAvtos(avtosDataBase)),
                new CountTypesCommand(new CountTypesAvtos(avtosDataBase)),
                new AveragePriceTypeCommand(new AveragePriceTypeAvtos(avtosDataBase,"Opel"))
            };
            avtosDataBase.FillDatabase(truckWorkWithXML);
            allCommands.Add(new CountAllCommand(new CountAllAvtos(avtosDataBase)));
            allCommands.Add(new AveragePriceCommand(new AveragePriceAvtos(avtosDataBase)));
            allCommands.Add(new CountTypesCommand(new CountTypesAvtos(avtosDataBase)));
            allCommands.Add(new AveragePriceTypeCommand(new AveragePriceTypeAvtos(avtosDataBase, "Opel"));
            string type;
            while(clientChoice != "Exit")
            {
                switch (clientChoice)
                {
                    case ("CountAllCars"):
                        avtosDataBase.FillDatabase(carWorkWithXML);
                        command = new CountAllCommand(new CountAllAvtos(avtosDataBase));
                        Console.WriteLine(command.Execute());
                        break;
                    case ("CountAllTrucks"):
                        avtosDataBase.FillDatabase(truckWorkWithXML);
                        command = new CountAllCommand(new CountAllAvtos(avtosDataBase));
                        Console.WriteLine(command.Execute());
                        break;
                    case ("AveragePriceCars"):
                        avtosDataBase.FillDatabase(carWorkWithXML);
                        command = new AveragePriceCommand(new AveragePriceAvtos(avtosDataBase));
                        Console.WriteLine(command.Execute());
                        break;
                    case ("AveragePriceTrucks"):
                        avtosDataBase.FillDatabase(truckWorkWithXML);
                        command = new AveragePriceCommand(new AveragePriceAvtos(avtosDataBase));
                        Console.WriteLine(command.Execute());
                        break;
                    case ("CountTypeCars"):
                        avtosDataBase.FillDatabase(carWorkWithXML);
                        command = new CountTypesCommand(new CountTypesAvtos(avtosDataBase));
                        Console.WriteLine(command.Execute());
                        break;
                    case ("CountTypeTrucks"):
                        avtosDataBase.FillDatabase(truckWorkWithXML);
                        command = new CountTypesCommand(new CountTypesAvtos(avtosDataBase));
                        Console.WriteLine(command.Execute());
                        break;
                    case ("AveragePriceTypeCars"):
                        avtosDataBase.FillDatabase(carWorkWithXML);
                        type = Console.ReadLine();
                        command = new AveragePriceTypeCommand(new AveragePriceTypeAvtos(avtosDataBase, type));
                        Console.WriteLine(command.Execute());
                        break;
                    case ("AveragePriceTypeTrucks"):
                        avtosDataBase.FillDatabase(truckWorkWithXML);
                        type = Console.ReadLine();
                        command = new AveragePriceTypeCommand(new AveragePriceTypeAvtos(avtosDataBase,type));
                        Console.WriteLine(command.Execute());
                        break;
                    case ("execute"):
                        foreach(var l in allCommands)
                        {
                            Console.WriteLine(l.Execute());
                        }
                        break;
                    default:
                        throw new Exception("Unknown command");
                }
            }
        }
    }
}
