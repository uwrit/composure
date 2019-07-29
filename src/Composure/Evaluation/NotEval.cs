using System;

namespace Composure
{
    public class NotEval : Evaluation
    {
        readonly IEvaluatable Evaluatable;

        public NotEval(IEvaluatable eval)
        {
            Evaluatable = eval;
        }

        public override string ToString()
        {
            return $"{Sql.NOT} ({Evaluatable})";
        }
    }
}
