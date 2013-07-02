//-----------------------------------------------------------------------
// <copyright>
// This software is licensed as Microsoft Public License (Ms-PL).
// </copyright>
//-----------------------------------------------------------------------
using System.Diagnostics;

namespace Mite
{
    /// <summary>
    /// Error message of mite
    /// </summary>
    [DebuggerDisplay("{Message}")]
    public class MiteError
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MiteError"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public MiteError(string message)
        {
            Message = message;
        }

        public MiteError(string message, string property) : this(message)
        {
            Property = property;
        }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; set; }

        public string Property { get; set; }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that contains the error message.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that contains the error message>.
        /// </returns>
        public override string ToString()
        {
            return Message;
        }
    }
}