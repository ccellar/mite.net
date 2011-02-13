//-----------------------------------------------------------------------
// <copyright>
// This software is licensed as Microsoft Public License (Ms-PL).
// </copyright>
//-----------------------------------------------------------------------
using System.Text;

namespace Mite
{
    internal class QueryTranslator
    {
        private readonly QueryExpression _expression;

        public QueryTranslator(QueryExpression expression)
        {
            _expression = expression;
        }

        public string Translate()
        {
            if (_expression.Conditions.Count == 0)
            {
                return string.Empty;
            }
            
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("?");

            foreach (Condition condition in _expression.Conditions)
            {
                stringBuilder.AppendFormat("{0}{1}{2}", condition.Property, condition.Operator,
                                           condition.Value);

            }

            return stringBuilder.ToString();
        }
    }
}