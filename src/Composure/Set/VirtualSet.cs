using System;
using System.Collections.Generic;

namespace Composure
{
    public class VirtualSet : Set
    {
        public VirtualSet()
        {

        }

        public VirtualSet(IBaseSet innerSet, string alias)
        {
            From = innerSet;
            Alias = alias;
        }

        public VirtualSet(IBaseSet innerSet, string alias, IEnumerable<IColumn> columns)
        {
            Select = columns;
            From = innerSet;
            Alias = alias;
        }
    }
}
