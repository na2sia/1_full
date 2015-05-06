using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckPoint1
{
    class ComparerByPrice : IComparer<ISweets>
    {
        public int Value { get; set; }
        public int Compare(ISweets x,ISweets y)
        {
            if (x != null && y != null)
            {
                if (x.Price > y.Price)
                    return 1;
                if (x.Price < y.Price)
                    return -1;
                else return 0;
            }
            else return -1;
    }
        }

}
