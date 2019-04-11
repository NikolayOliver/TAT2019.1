using System;

namespace Task5_Flight
{
    /// <summary>
    /// Child class FlyingObjects
    /// </summary>
    class Bird : FlyingObject
    {
        /// <summary>
        /// information of class SpaceShip
        /// </summary>
        /// <returns></returns>
        public override string WhoAmI()
        {
            return "Bird";
        }

        /// <summary>
        /// constructor which causes constroctor FlyingObject
        /// set random speed 
        /// </summary>
        /// <param name="startPosition">start point</param>
        public Bird(Point startPosition)
            : base(startPosition)
        {
            Speed = (new Random()).Next(0, 21);
        }

        /// <summary>
        /// give flying time for spaceship
        /// </summary>
        /// <returns>time</returns>
        public override double GetFlyTime()
        {
            if (Speed != 0)
            {
                return GetDistance() / Speed;
            }
            // if starting and finishing point are equal
            // and speed = 0
            // will be throw exception
            if (GetDistance() == 0)
            {
                return 0;
            }
            throw new DivideByZeroException("Bird\'s speed is zero");
        }
    }
}
