using System;
using System.Collections.Generic;

namespace Library.Service
{
    public class StringComparerAscendingService : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return String.Compare(x, y);
        }
    }
}