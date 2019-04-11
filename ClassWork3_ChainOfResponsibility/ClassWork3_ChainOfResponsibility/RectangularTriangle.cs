
namespace ClassWork3_ChainOfResponsibility
{    
    /// <summary>
    /// Class for create Equilateral triangle 
    /// and calculate square of its
    /// </summary>
    class RectangularTriangle : Triangle
    {
        float hypotence;
        /// <summary>
        /// causes Triangle class constructor 
        /// and calculate hypotence of rectangular triangle
        /// </summary>
        public RectangularTriangle(Point point1, Point point2, Point point3)
            : base(point1, point2, point3)
        {
            hypotence = ab;
            if (hypotence < bc)
            {
                hypotence = bc;
            }
            if (hypotence < ac)
            {
                hypotence = ac;
            }
        }
        /// <summary>
        /// return square of this triangle
        /// </summary>
        public override float GetSquare()
        {
            return ab * ac * bc / (2 * hypotence);
        }

    }
}
