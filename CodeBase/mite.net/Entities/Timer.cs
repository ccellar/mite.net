//-----------------------------------------------------------------------
// <copyright>
// This software is licensed as Microsoft Public License (Ms-PL).
// </copyright>
//-----------------------------------------------------------------------
namespace Mite
{
    /// <summary>
    /// A timer
    /// </summary>
    public class Timer : DomainObject
    {
        /// <summary>
        /// Gets or sets the stopped timer.
        /// </summary>
        /// <value>The stopped timer.</value>
        public StoppedTimer StoppedTimer
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets the running timer.
        /// </summary>
        /// <value>The running timer.</value>
        public RunningTimer RunningTimer
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets the time entry on which this timer is running.
        /// </summary>
        /// <value>The time entry.</value>
        public TimeEntry TimeEntry
        {
            get;
            set;
        }
    }
}