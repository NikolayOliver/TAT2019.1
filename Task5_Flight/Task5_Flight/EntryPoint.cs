using System;

namespace Task5_Flight
{
    /// <summary>
    /// the program describes the flight of various flying elements (birds, plane, spaceship)
    /// from one point to another
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// Entry point of the programm
        /// </summary>
        /// <param name="args"></param>
        /// <returns 0> All is good</returns>
        /// <returns 1> Divide by zero or bird's speed is null</returns>
        /// <returns 2> Something error</returns>
        static int Main(string[] args)
        {
            try
            {
                FlyingObject[] flyingObjects = new FlyingObject[3];
                flyingObjects[0] = new Bird(new Point(0, 0, 0));
                flyingObjects[1] = new Plane(new Point(0, 0, 0));
                flyingObjects[2] = new SpaceShip(new Point(0, 0, 0));
                foreach(var fo in  flyingObjects)
                {
                    fo.GetInformation += ShowMessage;
                    fo.FlyTo(new Point(800, 0, 0));
                }
                return 0;
            }
            catch (DivideByZeroException ze)
            {
                Console.WriteLine(ze.Message);
                return 1;
            }
            catch
            {
                Console.WriteLine("Something error!!!");
                return 2;
            }
        }
        public static void ShowMessage(object sender, InformationEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
