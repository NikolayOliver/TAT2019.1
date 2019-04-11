
namespace Task5_Flight
{
    /// <summary>
    /// Interface for Flying objects
    /// </summary>
    interface IFlyable
    {
       
        string WhoAmI();

        double GetFlyTime();

        void FlyTo(Point newPoint);
    }
}
