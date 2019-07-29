using System;

namespace Composure
{
    public abstract partial class Evaluation : IEvaluatable
    {
        public EvalType Type { get; set; }

        public virtual void AssignParentSet(IAliasedSet parent) { }

        internal string OperatorToString()
        {
            switch (Type)
            {
                case EvalType.Equal:
                    return "=";
                case EvalType.NotEqual:
                    return "!=";
                case EvalType.GreaterThan:
                    return ">";
                case EvalType.GreaterThanOrEqualTo:
                    return ">=";
                case EvalType.LessThan:
                    return "<";
                case EvalType.LessThanOrEqualTo:
                    return "<=";
                case EvalType.In:
                    return "IN";
                case EvalType.NotIn:
                    return "NOT IN";
                default:
                    return "";
            }
        }
    }

    public enum EvalType
    {
        Equal,
        NotEqual,
        LessThan,
        LessThanOrEqualTo,
        GreaterThan,
        GreaterThanOrEqualTo,
        In,
        NotIn,
        Like
    }
}
