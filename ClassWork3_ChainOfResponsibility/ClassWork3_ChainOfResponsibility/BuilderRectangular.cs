using System;

namespace ClassWork3_ChainOfResponsibility
{
    /// <summary>
    /// checks if the triangle is rectangular;
    /// if yes return RectangularTriangle 
    /// if not, then passes the initiative to the next class in the chain.
    /// </summary>
    class BuilderRectangular : Builder
    {
        Point abVector;
        Point acVector;
        Point bcVector;
        /// <summary>
        /// calls constructor Builder class
        /// </summary>
        /// <param name="builder"></param>
        public BuilderRectangular(Builder builder) : base (builder)
        {

        }
        /// <summary>
        /// return RectangularTriangle or passes the initiative to the next class in the chain.
        /// </summary>
        public override Triangle Build(Point point1, Point point2, Point point3)
        {
            if (Check(point1, point2, point3))
            {
                return new RectangularTriangle(point1, point2, point3);
            }
            if (Successor != null)
            {
                return Successor.Build(point1, point2, point3);
            }
            else
            {
                throw new Exception();
            }
            
        }
        /// <summary>
        /// according to mathematical logic checks whether the triangle is rectangular or not
        /// </summary>
        protected override bool Check(Point point1, Point point2, Point point3)
        {
            abVector = new Point(point2.x - point1.x, point2.y - point1.y);
            acVector = new Point(point3.x - point1.x, point3.y - point1.y);
            bcVector = new Point(point3.x - point2.x, point3.y - point2.y);
            if (Math.Abs(ScalarProduct(abVector, acVector)) < float.Epsilon)
            {
                return true;
            }
            if (Math.Abs(ScalarProduct(abVector, bcVector)) < float.Epsilon)
            {
                return true;
            }
            if (Math.Abs(ScalarProduct(acVector, bcVector)) < float.Epsilon)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// calculate scalar composition of two vectors
        /// </summary>
        float ScalarProduct(Point p1, Point p2)
        {
            return p1.x * p2.x + p1.y * p2.y;
        }
    }
}
