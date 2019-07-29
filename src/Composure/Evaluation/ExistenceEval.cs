using System;

namespace Composure
{
    public class ExistenceEval : IEvaluatable
    {
        public ISet Set { get; set; }

        public ExistenceEval() { }

        public ExistenceEval(ISet set)
        {
            Set = set;
        }

        public void AssignParentSet(IAliasedSet parent) { }

        public override string ToString()
        {
            return $"{Sql.EXISTS} {Set.ToSubQueryString()}";
        }
    }
}
