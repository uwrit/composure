using System;
using System.Linq;
using System.Collections.Generic;

namespace Composure
{
    public abstract class Set : ISet
    {
        public string Alias { get; set; }

        public virtual IBaseSet From { get; set; }

        /*
         * Columns to be returned in the SELECT clause.
         */
        IEnumerable<ISelectable> columns = new List<ISelectable>();
        public virtual IEnumerable<ISelectable> Select
        {
            get { return columns; }
            set { AssignThisAsParent(value); columns = value; }
        }

        /*
         * Criteria to evaluated in the WHERE clause.
         */
        IEnumerable<IEvaluatable> where = new List<IEvaluatable>();
        public IEnumerable<IEvaluatable> Where
        {
            get { return where; }
            set { AssignThisAsParent(value); where = value; }
        }

        /*
         * Criteria to be grouped in the GROUP BY clause.
         */
        IEnumerable<IAggregatable> groupBy = new List<IAggregatable>();
        public IEnumerable<IAggregatable> GroupBy
        {
            get { return groupBy; }
            set { AssignThisAsParent(value); groupBy = value; }
        }

        /*
         * Criteria to be evaluated in the HAVING clause.
         */
        IEnumerable<IEvaluatableAggregate> having = new List<IEvaluatableAggregate>();
        public IEnumerable<IEvaluatableAggregate> Having
        {
            get { return having; }
            set { AssignThisAsParent(value); having = value; }
        }

        /*
         * Columns to be selected in the ORDER clause.
         */
        IEnumerable<IOrderable> orderBy = new List<IOrderable>();
        public IEnumerable<IOrderable> OrderBy
        {
            get { return orderBy; }
            set { AssignThisAsParent(value); orderBy = value; }
        }

        /*
         * Assigns this as the parent to any IEnumerable<ISetComponent>.
         */
        internal virtual void AssignThisAsParent(object val)
        {
            if (val is IEnumerable<ISetComponent> comps)
            {
                comps.ToList().ForEach(x => x.AssignParentSet(this));
            }
        }

        /*
         * Get SQL statement to output for a given enumeration (e.g., SELECT ..., WHERE ...)
         */
        internal string GetExpressionSql(string clause, string separator, IEnumerable<ISqlFragment> expressions)
        {
            if (expressions != null && expressions.Any())
            {
                var str = expressions.Where(x => x != null).Select(x => x.ToString());
                return $"{clause} {string.Join($" {separator} ", str)}";
            }
            return "";
        }

        internal virtual string SelectToString()
        {
            string cols = Select != null ? GetExpressionSql("", Sql.COMMA, Select) : Sql.ALL_COLUMNS;
            return $"{Sql.SELECT} {cols}";
        }

        internal virtual string FromToString()
        {
            string from = From.ToSubQueryString();
            return string.IsNullOrWhiteSpace(Alias)
                ? $"{Sql.FROM} {from}"
                : $"{Sql.FROM} {from} {Sql.AS} {Alias}";
        }

        internal virtual string WhereToString() => GetExpressionSql(Sql.WHERE, Sql.AND, Where);

        internal virtual string GroupByToString() => GetExpressionSql(Sql.GROUP_BY, Sql.COMMA, GroupBy);

        internal virtual string HavingToString() => GetExpressionSql(Sql.HAVING, Sql.AND, Having);

        internal virtual string OrderByToString() => GetExpressionSql(Sql.ORDER_BY, Sql.COMMA, OrderBy);

        public IColumn GetColumn(string name)
        {
            if (typeof(ISet).IsAssignableFrom(From.GetType()))
            {
                var col = (From as ISet)
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
            var parts = new List<string>
            {
                SelectToString(),
                FromToString(),
                WhereToString(),
                GroupByToString(),
                HavingToString(),
                OrderByToString()
            };
            parts.ForEach(p => p.Trim());
            return string.Join(" ", parts).Trim();
        }

        public string ToSubQueryString()
        {
            return $"({ToString()})";
        }
    }
}
