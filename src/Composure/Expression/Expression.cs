using System;
using System.Linq;
using System.Collections.Generic;

namespace Composure
{
    public abstract partial class ExpressionBase<T> : IExpression, IAggregatable
    {
        internal bool isEnumerable;

        public T Value { get; set; }

        internal string EnumerableToString(IEnumerable<string> vals)
        {
            var strs = vals.Select(v => v.ToString());
            return $"({string.Join(", ", strs)})";
        }

        public override string ToString()
        {
            return typeof(ISet<T>).IsAssignableFrom(Value.GetType()) 
                ? (Value as ISet).ToSubQueryString() 
                :  Value.ToString();
        }

        public void AssignParentSet(IAliasedSet parent) { }
    }
        
    public class Expression : ExpressionBase<object>
    {
        public Expression(object expression)
        {
            Value = expression;
        }
    }

    public class Expressions : ExpressionBase<object>
    {
        void Initialize(IEnumerable<object> expressions)
        {
            Value = EnumerableToString(expressions.Select(e => e.ToString()));
            isEnumerable = true;
        }

        public Expressions(IEnumerable<object> expressions)
        {
            Initialize(expressions);
        }

        public Expressions(IEnumerable<int> expressions)
        {
            Initialize(expressions.Select(e => e.ToString()));
        }

        public Expressions(IEnumerable<double> expressions)
        {
            Initialize(expressions.Select(e => e.ToString()));
        }
    }
}
