using System;
using System.Collections.Generic;
using System.Linq;

namespace Composure
{
    public partial class CaseWhen : IExpression, IEvaluatable
    {
        public IEnumerable<WhenThen> Cases { get; set; }
        public IExpression Else { get; set; }

        public CaseWhen() { }

        public CaseWhen(IEnumerable<WhenThen> cases)
        {
            Cases = cases;
        }

        public CaseWhen(IEnumerable<WhenThen> cases, IExpression orElse)
        {
            Cases = cases;
            Else = orElse;
        }

        public void AssignParentSet(IAliasedSet set) { }

        public override string ToString()
        {
            var cases = Cases.Select(c => c.ToString());
            var orElse = Else != null ? $"{Sql.ELSE} {Else}" : "";
            return $"{Sql.CASE} {string.Join(" ", cases)} {orElse} {Sql.END}";
        }
    }

    public class WhenThen : ISqlFragment
    {
        public IEvaluatable When { get; set; }
        public IExpression Then { get; set; }

        public WhenThen() { }

        public WhenThen(IEvaluatable when, IExpression then)
        {
            When = when;
            Then = then;
        }

        public override string ToString()
        {
            return $"{Sql.WHEN} {When} {Sql.THEN} {Then}";
        }
    }
}
