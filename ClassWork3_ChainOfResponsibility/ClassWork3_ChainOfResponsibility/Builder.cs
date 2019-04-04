
namespace ClassWork3_ChainOfResponsibility
{
    /// <summary>
    /// base class of all triangles builders
    /// </summary>
    abstract class Builder
    {
        public Builder Successor { get; set; }
        public Builder(Builder builder)
        {
            Successor = builder;
        }
        public abstract Triangle Build(Point point1, Point point2, Point point3);
        protected abstract bool Check(Point point1, Point point2, Point point3);
    }
}
