using System;

namespace Composure
{
    public partial class ExpressionEval : Evaluation, IEvaluatableAggregate
    {
        public IExpression Expression { get; set; }
        public IExpression Value { get; set; }

        public ExpressionEval() { }

        public ExpressionEval(IExpression expression, EvalType type, IExpression value)
        {
            Expression = expression;
            Type = type;
            Value = value;
        }

        public override string ToString()
        {
            return $"{Expression} {OperatorToString()} {Value}";
        }
    }
}
