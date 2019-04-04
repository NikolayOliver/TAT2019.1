using System;

namespace ClassWork3_ChainOfResponsibility
{
    /// <summary>
    /// checks if the triangle is Eqilateral; if not, then passes the initiative to the next class in the chain.
    /// </summary>
    class BuilderEquilateral : Builder
    { 
        /// <summary>
        /// calls constructor Builder class
        /// </summary>
        /// <param name="builder"></param>
        public BuilderEquilateral(Builder builder) : base (builder)
        {

        }
        /// <summary>
        /// return EquilateralTriangle or passes the initiative to the next class in the chain.
        /// </summary>
        public override Triangle Build(Point point1, Point point2, Point point3)
        {
            if (Check(point1, point2, point3))
            {
                return new EquilateralTriangle(point1, point2, point3);
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
        /// check to equilateral triangle
        /// </summary>
        protected override bool Check(Point point1, Point point2, Point point3)
        {
            float ab = GetDistance(point2, point1);
            float bc = GetDistance(point3, point2);
            float ac = GetDistance(point3, point1);
            return (Math.Abs(ab - bc) < float.Epsilon && Math.Abs(ab - ac) < float.Epsilon) ? true : false;
        }
        float GetDistance(Point point2, Point point1)
        {
            return (float)Math.Sqrt((point2.y - point1.y) * (point2.y - point1.y) + (point2.x - point1.x) * (point2.x - point1.x));
        }
    }
}
