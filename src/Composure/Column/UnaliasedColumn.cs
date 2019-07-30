using System;

namespace Composure
{
    public class UnaliasedColumn : Column
    {
        public UnaliasedColumn(IColumn column) : base(column) { }

        public UnaliasedColumn(string name) : base(name) { }

        public UnaliasedColumn(string name, IAliasedSet set) : base(name, set) { }

        public UnaliasedColumn(ExpressedColumn column) : base(column.Name) { }

        public override string ToString()
        {
            return Name;
        }
    }
}
