using System;
using System.Collections.Generic;

namespace Wishart.Hasher
{
    internal class StringComparer : IEqualityComparer<string>
    {
        public bool Equals( string x, string y ) {
            return x.Equals( y, StringComparison.OrdinalIgnoreCase );
        }

        public int GetHashCode( string obj ) {
            return obj.GetHashCode();
        }
    }
}