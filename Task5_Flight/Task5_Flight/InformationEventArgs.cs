using System;

namespace Task5_Flight
{
    /// <summary>
    /// class for an event that has info
    /// </summary>
    class InformationEventArgs : EventArgs
    {
        /// <summary>
        /// information message
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// constructor 
        /// set message information
        /// </summary>
        /// <param name="info">information</param>
        public InformationEventArgs(string info)
        {
            Message = info;
        }
    }
}
