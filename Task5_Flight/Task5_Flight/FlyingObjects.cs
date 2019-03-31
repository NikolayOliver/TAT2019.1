using System;

namespace Task5_Flight
{
    /// <summary>
    /// common class for all flying objects
    /// </summary>
    abstract class FlyingObject : IFlyable
    {
        /// <summary>
        /// Start point
        /// </summary>
        protected Point startPoint;
        /// <summary>
        /// setting point
        /// </summary>
        protected Point newPoint;
        /// <summary>
        /// delegate 
        /// </summary>
        /// <typeparam name="T">eventArgs</typeparam>
        /// <param name="sender">class sender</param>
        /// <param name="e">child EventArgs class instance</param>
        public delegate void InformationStateHandler<T>(object sender, T e)
                                           where T : EventArgs;
        /// <summary>
        /// event containing delegate InformationStateHandler
        /// </summary>
        public event InformationStateHandler<InformationEventArgs> GetInformation;
        /// <summary>
        /// flying elements speed
        /// </summary>
        public double Speed {  get; set; }
        /// <summary>
        /// Costructor
        /// set starting point
        /// </summary>
        /// <param name="startPosition">start point</param>
        public FlyingObject(Point startPosition)
        {
            startPoint = startPosition;
        }

        /// <summary>
        /// set finishing point
        /// get infotmation about objects
        /// </summary>
        /// <param name="newPoint">finishing point</param>
        public void FlyTo(Point newPoint)
        {
            this.newPoint = newPoint;
            if (GetInformation != null)
            {
                GetInformation(this, new InformationEventArgs(GetInformationInString()));
            }
        }

        /// <summary>
        /// turns information if one string
        /// </summary>
        /// <returns>information</returns>
        public string GetInformationInString()
        {
            return WhoAmI() + " gets to the point in time " + GetFlyTime().ToString();
        }

        /// <summary>
        /// Give Distance
        /// </summary>
        /// <returns>distance</returns>
        public double GetDistance()
        {
            return Math.Sqrt((startPoint.x - newPoint.x) * (startPoint.x - newPoint.x) +
                             (startPoint.y - newPoint.y) * (startPoint.y - newPoint.y) +
                             (startPoint.z - newPoint.z) * (startPoint.z - newPoint.z));
        }

        /// <summary>
        /// give information about this class
        /// </summary>
        /// <returns>information about this class</returns>
        public abstract string WhoAmI();

        /// <summary>
        /// give time from starting point to finishing point
        /// </summary>
        /// <returns>time</returns>
        public abstract double GetFlyTime();
    }
}
