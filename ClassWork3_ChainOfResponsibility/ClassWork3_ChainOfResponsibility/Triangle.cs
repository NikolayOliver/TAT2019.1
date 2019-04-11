using System;

namespace ClassWork3_ChainOfResponsibility
{
    /// <summary>
    /// base class for logic triangle
    /// </summary>
    abstract class Triangle
    {
        protected Point aPoint;
        protected Point bPoint;
        protected Point cPoint;
        /// <summary>
        /// sides
        /// </summary>
        protected float ab;
        protected float bc;
        protected float ac;
        /// <summary>
        /// checks whether it is possible to create a triangle of points, 
        /// and if so, consider the sides of the triangle
        /// </summary>
        public Triangle(Point point1, Point point2, Point point3)
        {
            aPoint = point1;
            bPoint = point2;
            cPoint = point3;
            ab = GetDistance(bPoint, aPoint);
            bc = GetDistance(cPoint, bPoint);
            ac = GetDistance(cPoint, aPoint);
            if (ab < float.Epsilon || bc < float.Epsilon || ac < float.Epsilon)
            {
                throw new FormatException("Two points are similar");
            }
            if (Math.Abs((cPoint.y - aPoint.y) / (bPoint.y - aPoint.y) - (cPoint.x - aPoint.x)/(bPoint.x - aPoint.x)) <= float.Epsilon)
            {
                throw new FormatException("Three points in one line");
            }
        }
        abstract public float GetSquare();
        /// <summary>
        /// calculates distance of side
        /// </summary>
        float GetDistance(Point point2, Point point1)
        {
            return (float)Math.Sqrt((point2.y - point1.y) * (point2.y - point1.y) + (point2.x - point1.x) * (point2.x - point1.x)); 
        }
    }
}
