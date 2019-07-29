using System;

namespace Composure
{
    public class ColumnRangeEval : RangeEval<object>
    {
        public IColumn Column { get; set; }

        public override void AssignParentSet(IAliasedSet parent)
        {
            Column.Set = Column.Set ?? parent;
        }

        public ColumnRangeEval() { }

        public ColumnRangeEval(IColumn column, object low, object high)
        {
            Column = column;
            RangeLow = low;
            RangeHigh = high;
        }

        public ColumnRangeEval(IColumn column, object low, object high, bool inclusive)
        {
            Column = column;
            RangeLow = low;
            RangeHigh = high;
            Inclusive = inclusive;
        }

        public override string ToString()
        {
            return InternalToString(Column);
        }
    }
}
