using System;

namespace Composure
{
    public class RawEval : ExpressionBase<string>, IEvaluatable
    {
        public RawEval(string eval)
        {
            Value = eval;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
