
namespace ClassWork3_ChainOfResponsibility
{
    /// <summary>
    /// the last element of the chain
    /// return SimpleTriangle
    /// </summary>
    class BuilderSimple : Builder
    {
        /// <summary>
        /// calls constructor Builder class
        /// </summary>
        public BuilderSimple(Builder builder) : base(builder)
        {

        }
        /// <summary>
        /// return SimpleTriangle
        /// </summary>
        public override Triangle Build(Point point1, Point point2, Point point3)
        {
            return new SimpleTriangle(point1, point2, point3);
        }
        /// <summary>
        /// just override method
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <param name="point3"></param>
        /// <returns></returns>
        protected override bool Check(Point point1, Point point2, Point point3)
        {
            return false;
        }
    }
}
