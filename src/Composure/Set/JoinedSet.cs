using System;
using System.Linq;
using System.Collections.Generic;

namespace Composure
{
    public class JoinedSet : Set
    {
        public override IEnumerable<ISelectable> Select { get; set; }
        public new IEnumerable<IJoinable> From { get; set; }

        public readonly new string Alias;

        internal override void AssignThisAsParent(object val) { }

        internal override string FromToString()
        {
            var sets = From.Select(s => s.ToString());
            return $"{Sql.FROM} {string.Join(" ", sets)}";
        }
    }
}
