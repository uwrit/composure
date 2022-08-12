using System;
using System.Linq;
using System.Collections.Generic;

namespace Composure
{
    public abstract class ConditionalEval : IEvaluatable
    {
        readonly List<IEvaluatable> Evaluatables;

        protected ConditionalEval()
        {
            Evaluatables = new List<IEvaluatable>();
        }

        protected ConditionalEval(IEvaluatable evaluatable)
        {
            Evaluatables = new List<IEvaluatable> { evaluatable };
        }

        protected ConditionalEval(IEvaluatable evaluatable1, IEvaluatable evaluatable2)
        {
            Evaluatables = new List<IEvaluatable> { evaluatable1, evaluatable2 };
        }

        protected ConditionalEval(params IEvaluatable[] evaluatables)
        {
            Evaluatables = evaluatables.ToList();
        }

        public void Add(IEvaluatable evaluatable)
        {
            Evaluatables.Add(evaluatable);
        }

        public void Add(IEvaluatable evaluatable1, IEvaluatable evaluatable2)
        {
            Evaluatables.Add(evaluatable1);
            Evaluatables.Add(evaluatable2);
        }

        public void Add(IEnumerable<IEvaluatable> evaluatables)
        {
            evaluatables.Union(evaluatables);
        }

        public virtual void AssignParentSet(IAliasedSet parent)
        {
            Evaluatables.ForEach(e => e.AssignParentSet(parent));
        }

        internal string InternalToString(string separator)
        {
            var conditions = Evaluatables.Select(e => e.ToString());
            return $"({string.Join($" {separator} ", conditions)})";
        }

        public override string ToString() => "";
    }

    public partial class OrEval : ConditionalEval
    {
        public override string ToString()
        {
            return InternalToString(Sql.OR);
        }

        public OrEval(IEvaluatable evaluatable1, IEvaluatable evaluatable2) : base(evaluatable1, evaluatable2) { }

        public OrEval(params IEvaluatable[] evaluatables) : base(evaluatables) { }
    }

    public partial class AndEval : ConditionalEval
    {
        public AndEval(IEvaluatable evaluatable1, IEvaluatable evaluatable2) : base(evaluatable1, evaluatable2) { }

        public AndEval(params IEvaluatable[] evaluatables) : base(evaluatables) { }

        public override string ToString()
        {
            return InternalToString(Sql.AND);
        }
    }
}
