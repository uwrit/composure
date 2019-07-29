using System;

namespace Composure
{
    public abstract class RangeEval<T> : Evaluation, IEvaluatable
    {
        public T RangeLow { get; set; }
        public T RangeHigh { get; set; }

        public bool Inclusive = true;

        internal string InternalToString(object value)
        {
            var include = Inclusive ? "" : Sql.NOT;
            return $"{value.ToString()} {include} {Sql.BETWEEN} {RangeLow.ToString()} {Sql.AND} {RangeHigh.ToString()}";
        }

        public override string ToString() => "";
    }
}
