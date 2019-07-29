using System;

namespace Composure
{
    public partial class RawSet : IBaseSet
    {
        readonly string nameOrSubstring;

        public RawSet(string fullyQualifiedNameOrSubstring)
        {
            nameOrSubstring = fullyQualifiedNameOrSubstring;
        }

        public override string ToString()
        {
            return nameOrSubstring;
        }

        public string ToSubQueryString()
        {
            return nameOrSubstring;
        }
    }
}
