//-----------------------------------------------------------------------
// <copyright>
// This software is licensed as Microsoft Public License (Ms-PL).
// </copyright>
//-----------------------------------------------------------------------

namespace Mite
{
    using System;
    using System.Collections.Generic;

    internal class QueryTranslator
    {
        private readonly QueryExpression _expression;

        private readonly ICollection<string> _supportedCriterias;

        public QueryTranslator(QueryExpression expression) : this(expression, null)
        {
        }

        public QueryTranslator(QueryExpression expression, ICollection<string> supportedCriterias)
        {
            _expression = expression;
            _supportedCriterias = supportedCriterias ?? new List<string>();
        }

        private static string GetValueAttributeValue(Enum value)
        {
            // Get the type
            var type = value.GetType();

            // Get fieldinfo for this type
            var fieldInfo = type.GetField(value.ToString());

            // Get the valueattributes
            var attribs = fieldInfo.GetCustomAttributes(typeof(ValueAttribute), false) as ValueAttribute[];

            if (attribs == null || attribs.Length == 0)
            {
                return null;
            }

            // Return the first if there was a match.
            return attribs[0].Value;
        }


        public string Translate()
        {
            if (_expression.Conditions.Count == 0)
            {
                return string.Empty;
            }

            var criterias = new List<string>();
            foreach (var condition in _expression.Conditions)
            {
                criterias.Add(this.GetCriteriaForCondition(condition)); 
            }

            if (criterias.Count == 0)
            {
                return string.Empty;
            }

            return string.Concat("?", string.Join("&", criterias.ToArray()));
        }


        private string GetCriteriaForCondition(Condition condition)
        {
            if (string.IsNullOrEmpty(condition.Property))
            {
                throw new NotSupportedException("Empty property is not supported.");
            }

            if (_supportedCriterias != null)
            {
                if (_supportedCriterias.Count > 0 && !_supportedCriterias.Contains(condition.Property))
                {
                    throw new NotSupportedException(string.Format("The criteria {0} is not supported.", condition.Property));
                }
            }

            string value;

            if (condition.Value is DateTime)
            {
                value = ((DateTime)condition.Value).ToString("yyyy-MM-dd");
            }
            else
            {
                value = condition.Value.ToString();
            }

            var op = GetValueAttributeValue(condition.Operator) ?? condition.Operator.ToString();

            return string.Format("{0}{1}{2}", condition.Property, op, value);
        }
    }
}