using System;

namespace Composure
{
    public partial class ColumnsEval : Evaluation
    {
        public IColumn Left { get; set; }
        public IColumn Right { get; set; }

        public override void AssignParentSet(IAliasedSet parent)
        {
            Left.Set = Left.Set ?? parent;
            Right.Set = Right.Set ?? parent;
        }

        public ColumnsEval() { }

        public ColumnsEval(IColumn left, EvalType type, IColumn right)
        {
            Left = left;
            Type = type;
            Right = right;
        }

        public override string ToString()
        {
            return $"{Left} {OperatorToString()} {Right}";
        }
    }
}
