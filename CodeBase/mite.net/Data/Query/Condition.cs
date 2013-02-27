//-----------------------------------------------------------------------
// <copyright>
// This software is licensed as Microsoft Public License (Ms-PL).
// </copyright>
//-----------------------------------------------------------------------
namespace Mite
{
    /// <summary>
    /// Condition for querying
    /// </summary>
    public class Condition
    {
        /// <summary>
        /// Gets or sets the operator for this condition.
        /// </summary>
        /// <value>The operator.</value>
        public ConditionOperator Operator { get; set; }

        /// <summary>
        /// Gets or sets the compare value.
        /// </summary>
        /// <value>The value.</value>
        public object Value { get; set; }

        /// <summary>
        /// Gets or sets the property on which the operator will be used.
        /// </summary>
        /// <value>The property.</value>
        public string Property { get; set; }
    }
}