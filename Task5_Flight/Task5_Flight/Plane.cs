
namespace Task5_Flight
{
    /// <summary>
    /// Child class FlyingObjects
    /// </summary>
    class Plane: FlyingObject
    {
        /// <summary>
        /// information of class SpaceShip
        /// </summary>
        /// <returns></returns>
        public override string WhoAmI()
        {
            return "Plane";
        }

        /// <summary>
        /// constructor which causes constroctor FlyingObject
        /// set starting speed 
        /// </summary>
        /// <param name="startPosition">start point</param>
        public Plane(Point startPosition)
            : base(startPosition)
        {
            Speed = 200;
        }

        /// <summary>
        /// give flying time for spaceship
        /// </summary>
        /// <returns>time</returns>
        public override double GetFlyTime()
        {
            double kilometersIncreaseSpeed = 10;
            double distance = GetDistance();
            double flyTime = 0;
            while (distance > kilometersIncreaseSpeed)
            {
                flyTime += kilometersIncreaseSpeed / Speed;
                Speed += 10;
                distance -= kilometersIncreaseSpeed;
            }
            flyTime += distance / Speed;
            return flyTime;
        }
    }
}
