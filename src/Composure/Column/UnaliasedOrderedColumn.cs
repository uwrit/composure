using System;

namespace Composure
{
    public class UnaliasedOrderedColumn : OrderedColumn
    {
        public UnaliasedOrderedColumn(IColumn column, OrderType type) : base(column, type) { }

        public UnaliasedOrderedColumn(string name, OrderType type) : base(name, type) { }

        public UnaliasedOrderedColumn(ExpressedColumn column, OrderType type) : base(column.Name, type) { }

        public override string ToString()
        {
            return $"{Name} {OrderTypeToString()}";
        }
    }
}
