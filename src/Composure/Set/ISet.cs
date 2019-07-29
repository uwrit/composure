using System;
using System.Collections.Generic;

namespace Composure
{
    public interface ISqlFragment
    {
        string ToString();
    }

    public interface ISqlStatement
    {

    }

    public interface IBaseSet : ISqlFragment
    {
        string ToSubQueryString();
    }

    public interface IAliasedSet : IBaseSet
    {
        string Alias { get; set; }

        IColumn GetColumn(string colName);
    }

    public interface ISet : IAliasedSet, ISqlStatement, IExpression
    {
        IEnumerable<ISelectable> Select { get; set; }
        IEnumerable<IEvaluatable> Where { get; set; }
        IEnumerable<IAggregatable> GroupBy { get; set; }
        IEnumerable<IEvaluatableAggregate> Having { get; set; }
    }

    public interface ISetComponent : ISqlFragment
    {
        void AssignParentSet(IAliasedSet set);
    }

    public interface IExpression : ISqlFragment { }

    public interface ISelectable : ISetComponent { }

    public interface IEvaluatable : ISetComponent { }

    public interface IAggregatable : ISetComponent { }

    public interface IEvaluatableAggregate : ISetComponent { }

    public interface IOrderable : ISetComponent { }

    public interface IJoinable : ISqlFragment { }
}
