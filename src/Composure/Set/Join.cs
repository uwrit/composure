using System;
using System.Linq;
using System.Collections.Generic;

namespace Composure
{
    public class Join : IAliasedSet, IJoinable
    {
        public IBaseSet Set { get; set; }
        public JoinType Type = JoinType.None;
        public string Alias { get; set; }

        IEnumerable<IEvaluatable> on;
        public IEnumerable<IEvaluatable> On
        {
            get { return on; }
            set
            {
                (value as IEnumerable<IEvaluatable>)
                    .ToList()
                    .ForEach(v => v.AssignParentSet(this));
                on = value;
            }
        }

        string JoinTypeToString()
        {
            switch (Type)
            {
                case JoinType.Inner:
                    return Sql.INNER_JOIN;
                case JoinType.Outer:
                    return Sql.OUTER_JOIN;
                case JoinType.Left:
                    return Sql.LEFT_JOIN;
                case JoinType.Right:
                    return Sql.RIGHT_JOIN;
                default:
                    return "";
            }
        }

        public IColumn GetColumn(string name)
        {
            if (typeof(ISet).IsAssignableFrom(Set.GetType()))
            {
                var col = (Set as ISet)
                    .Select
                    .Where(c => c is Column && (c as Column).Name == name)
                    .Select(c => c as Column)
                    .FirstOrDefault();
                return col;
            }
            return null;
        }

        public override string ToString()
        {
            var setSql = $"{Set.ToSubQueryString()} {Sql.AS} {Alias}";
            if (On != null && On.Any())
            {
                var joinSql = On.Select(x => x.ToString());
                return $"{JoinTypeToString()} {setSql} {Sql.ON} {string.Join($" {Sql.AND} ", joinSql)}";
            }
            return setSql;
        }

        public string ToSubQueryString()
        {
            return $"({ToString()})";
        }
    }

    public enum JoinType
    {
        None,
        Inner,
        Outer,
        Left,
        Right,
    }
}
