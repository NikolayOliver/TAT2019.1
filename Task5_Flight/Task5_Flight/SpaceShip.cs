
namespace Task5_Flight
{
    /// <summary>
    /// Child class FlyingObjects
    /// </summary>
    class SpaceShip : FlyingObject
    {
        /// <summary>
        /// const value speed
        /// </summary>
        const double _speed = 800;
        /// <summary>
        /// constructor which causes constroctor FlyingObject
        /// </summary>
        /// <param name="startPosition">start point</param>
        public SpaceShip(Point startPosition)
            : base(startPosition)
        {

        }

        /// <summary>
        /// information of class SpaceShip
        /// </summary>
        /// <returns></returns>
        public override string WhoAmI()
        {
            return "SpaceShip";
        }

        /// <summary>
        /// give flying time for spaceship
        /// </summary>
        /// <returns>time</returns>
        public override double GetFlyTime()
        {
            return GetDistance() / _speed;
        }
    }
}
