using System;

namespace ClassWork3_ChainOfResponsibility
{
    /// <summary>
    /// calculates the area of ​​an ordinary triangle 
    /// </summary>
    class SimpleTriangle : Triangle
    {
        float semiPerimeter;
        /// <summary>
        /// claculates semi - perimeter of Triangle
        /// </summary>
        public SimpleTriangle(Point point1, Point point2, Point point3)
            : base(point1, point2, point3)
        {
            semiPerimeter = (ab + bc + ac) / 2;
        }
        /// <summary>
        /// return Square simple triangle
        /// </summary>        
        public override float GetSquare()
        {
            return (float)Math.Sqrt(semiPerimeter * (semiPerimeter - ab) * (semiPerimeter - bc) * (semiPerimeter - ac));
        }
    }
}
