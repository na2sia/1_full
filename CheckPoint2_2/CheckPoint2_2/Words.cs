using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckPoint2_2
{
    public class Words
    {
        public string Word{get;set;}
        public int CountWord{get;set;}
        public HashSet<int> Lines = new HashSet<int>();
    }
}
