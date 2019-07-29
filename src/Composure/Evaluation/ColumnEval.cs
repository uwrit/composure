using System;

namespace Composure
{
    public partial class ColumnEval : Evaluation
    {
        public IColumn Column { get; set; }
        public IExpression Value { get; set; }

        public override void AssignParentSet(IAliasedSet parent)
        {
            Column.Set = Column.Set ?? parent;
        }

        public ColumnEval() { }

        public ColumnEval(IColumn column, EvalType type, IExpression value)
        {
            Column = column;
            Type = type;
            Value = value;
        }

        public ColumnEval(IExpression value, EvalType type, IColumn column)
        {
            Column = column;
            Type = type;
            Value = value;
        }

        public override string ToString()
        {
            return $"{Column} {OperatorToString()} {Value}";
        }
    }
}
