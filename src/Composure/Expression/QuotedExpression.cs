using System;
using System.Linq;
using System.Collections.Generic;

namespace Composure
{
    public abstract class QuotedExpressionBase : ExpressionBase<object>
    {
        internal const string quote = "'";
        internal string EscapeQuotes(string expression) => expression.Replace(quote, $"{quote}{quote}");
    }

    public class QuotedExpression : QuotedExpressionBase
    {
        public QuotedExpression(string expression)
        {
            var escaped = EscapeQuotes(expression);
            Value = $"{quote}{escaped}{quote}";
        }
    }

    public class QuotedExpressions : QuotedExpressionBase
    {
        public QuotedExpressions(IEnumerable<string> expressions)
        {
            var quoted = expressions.Select(e => $"{quote}{EscapeQuotes(e)}{quote}");
            Value = EnumerableToString(quoted);
            isEnumerable = true;
        }
    }
}
