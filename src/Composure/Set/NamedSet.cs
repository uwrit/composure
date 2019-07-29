using System;
using System.Collections.Generic;

namespace Composure
{
    public class NamedSet : Set
    {
        public new RawSet From { get; set; }

        public NamedSet() { }

        public NamedSet(RawSet fullyQualifiedNameOrSubstring, string alias)
        {
            From = fullyQualifiedNameOrSubstring;
            Alias = alias;
        }

        public NamedSet(RawSet fullyQualifiedNameOrSubstring, string alias, IEnumerable<ISelectable> columns)
        {
            Select = columns;
            From = fullyQualifiedNameOrSubstring;
            Alias = alias;
        }

        internal override string FromToString()
        {
            string from = From.ToSubQueryString();
            return string.IsNullOrEmpty(Alias)
                ? $"{Sql.FROM} {from}"
                : $"{Sql.FROM} {from} {Sql.AS} {Alias}";
        }
    }
}
