using System;

namespace Composure
{
    public class OrderedColumn : Column
    {
        public OrderType Type { get; set; }

        internal string OrderTypeToString()
        {
            return Type == OrderType.DESC ? Sql.DESC : Sql.ASC;
        }

        public OrderedColumn(IColumn column, OrderType type) : base(column)
        {
            Type = type;
        }

        public OrderedColumn(ExpressedColumn column, OrderType type) : base(column.Name)
        {
            Type = type;
        }

        public OrderedColumn(string name, OrderType type) : base(name)
        {
            Type = type;
        }

        public OrderedColumn(string name, IAliasedSet set, OrderType type) : base(name, set)
        {
            Type = type;
        }

        public override string ToString()
        {
            if (Set == null || Set.Alias == null || Set.Alias == "")
            {
                return $"{Name} {OrderTypeToString()}";
            }
            return $"{Set.Alias}.{Name} {OrderTypeToString()}";
        }
    }

    public enum OrderType
    {
        ASC,
        DESC
    }
}
