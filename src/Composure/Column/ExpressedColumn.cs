using System;

namespace Composure
{
    public class ExpressedColumn : ISelectable
    {
        public string Name { get; set; }
        public IExpression Expression { get; set; }

        public ExpressedColumn() { }

        public ExpressedColumn(IExpression expression, string name)
        {
            Name = name;
            Expression = expression;
        }

        public void AssignParentSet(IAliasedSet parent) { }

        public override string ToString()
        {
            return $"{Expression} {Sql.AS} {Name}";
        }
    }
}
