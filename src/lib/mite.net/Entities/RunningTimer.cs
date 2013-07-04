//-----------------------------------------------------------------------
// <copyright>
// This software is licensed as Microsoft Public License (Ms-PL).
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace Mite
{
    /// <summary>
    /// A running timer
    /// </summary>
    public class RunningTimer : TimerBase
    {
        /// <summary>
        /// Gets or sets the start of the timer.
        /// </summary>
        /// <value>The start.</value>
        public DateTime Start
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Base class for timers
    /// </summary>
    public class TimerBase
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the minutes which are elapsed on this timer.
        /// </summary>
        /// <value>The minutes.</value>
        public int Minutes
        {
            get;
            set;
        }
    }
}