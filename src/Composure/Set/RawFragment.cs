using System;

namespace Composure
{
    public class RawFragment : ISelectable, IJoinable, IEvaluatable, IAggregatable, IEvaluatableAggregate, IOrderable
    {
        readonly object Value;

        public void AssignParentSet(IAliasedSet set) { }

        public RawFragment(object sqlFragment)
        {
            Value = sqlFragment;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
