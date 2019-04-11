using System;

namespace ClassWork3_ChainOfResponsibility
{
    /// <summary>
    /// Class for create Equilateral triangle 
    /// and calculate square of its
    /// </summary>
    class EquilateralTriangle : Triangle
    {
        public EquilateralTriangle(Point point1, Point point2, Point point3)
            : base(point1, point2, point3)
        {

        }
        /// <summary>
        /// return square of this triangle
        /// </summary>
        public override float GetSquare()
        {
            return (float)Math.Sqrt(3) * ab * ab / 4;
        }
    }
}
