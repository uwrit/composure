using System;

namespace Composure
{
    public interface IColumn : ISelectable, IAggregatable, IOrderable
    {
        string Name { get; set; }
        IAliasedSet Set { get; set; }
    }

    public partial class Column : IColumn
    {
        public string Name { get; set; }
        public IAliasedSet Set { get; set; }

        public Column(IColumn column)
        {
            Name = column.Name;
            Set = column.Set;
        }

        public Column(string name)
        {
            Name = name;
        }

        public Column(string name, IAliasedSet set)
        {
            Name = name;
            Set = set;
        }

        public void AssignParentSet(IAliasedSet parent)
        {
            Set = Set ?? parent;
        }

        public override string ToString()
        {
            if (Set == null || Set.Alias == null || Set.Alias == "")
            {
                return Name;
            }
            return $"{Set.Alias}.{Name}";
        }
    }
}
