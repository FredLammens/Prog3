using System.Collections.Generic;

namespace OefCollecties
{
    class VlootComparer : IComparer<Vloot>
    {
        public int Compare(Vloot x, Vloot y)
        {
            return x.naam.CompareTo(y.naam);
        }
    }
}
