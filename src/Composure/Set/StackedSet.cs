using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Composure
{
    public abstract class StackedSet : IEnumerable<ISet>, IBaseSet
    {
        readonly List<ISet> Sets = new List<ISet>();

        public void Add(ISet set)
        {
            Sets.Add(set);
        }

        public IEnumerator<ISet> GetEnumerator()
        {
            return Sets.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        internal string InternalToString(string separator)
        {
            var sql = Sets.Select(x => x.ToString());
            return string.Join($" {separator} ", sql);
        }

        public virtual string ToSubQueryString() => $"({ToString()})";
    }

    public class UnionedSet : StackedSet
    {
        readonly UnionType UnionType = UnionType.Unique;

        public UnionedSet() { }

        public UnionedSet(UnionType type)
        {
            UnionType = type;
        }

        public override string ToString()
        {
            var unionType = UnionType == UnionType.Unique ? Sql.UNION : Sql.UNION_ALL;
            return InternalToString(unionType);
        }
    }

    public enum UnionType
    {
        Unique,
        All
    }

    public class IntersectedSet : StackedSet
    {
        public override string ToString()
        {
            return InternalToString(Sql.INTERSECT);
        }
    }

    public class ExceptedSet : StackedSet
    {
        public override string ToString()
        {
            return InternalToString(Sql.EXCEPT);
        }
    }
}
