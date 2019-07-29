using System;

namespace Composure
{
    public class ExpressionRangeEval : RangeEval<object>, IEvaluatable
    {
        public IExpression Expression { get; set; }

        public ExpressionRangeEval() { }

        public ExpressionRangeEval(IExpression expression, object low, object high)
        {
            Expression = expression;
            RangeLow = low;
            RangeHigh = high;
        }

        public ExpressionRangeEval(IExpression expression, object low, object high, bool inclusive)
        {
            Expression = expression;
            RangeLow = low;
            RangeHigh = high;
            Inclusive = inclusive;
        }

        public override string ToString()
        {
            return InternalToString(Expression);
        }
    }
}
