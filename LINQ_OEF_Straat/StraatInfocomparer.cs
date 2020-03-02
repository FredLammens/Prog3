using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ_OEF_Straat
{
    class StraatInfocomparer : IEqualityComparer<StraatInfo>
    {
        public bool Equals(StraatInfo x, StraatInfo y)
        {
            if (string.Equals(x.straat, y.straat, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        public int GetHashCode( StraatInfo obj)
        {
            return obj.straat.GetHashCode();
        }
    }
}
