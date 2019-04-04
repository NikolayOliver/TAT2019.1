using System;

namespace ClassWork3_ChainOfResponsibility
{
    /// <summary>
    /// by three points we determine the type of triangle 
    /// and calculate its square
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// Entry Point of progam
        /// </summary>
        /// <param name="args"></param>
        /// <returns 0> all is good </returns>
        /// <returns 1> wrong setting of points </returns>
        /// <returns 2> something error </returns>
        static int Main(string[] args)
        {
            try
            {
                Point point1 = new Point(5, 2);
                Point point2 = new Point(1, 21);
                Point point3 = new Point(11, 1);
                Builder mainBuiler = new BuilderRectangular(
                                     new BuilderEquilateral(
                                     new BuilderSimple(null)));
                Triangle triangle = mainBuiler.Build(point1,point2,point3);
                Console.WriteLine(triangle.GetSquare());
                return 0;
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
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
