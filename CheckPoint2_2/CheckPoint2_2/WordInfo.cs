using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckPoint2_2
{
    public class WordInfo
       
    {
        public string Value{get;set;}
        public int CountWord{get;set;}
        private readonly SortedSet<int> Lines;

        public void AddLines(int line)
        {
            Lines.Add(line);
        }

        public WordInfo() { }
        public WordInfo(string value)
        {
            this.Value = value;
            Lines=new SortedSet<int>();
        }

        public override string ToString()
        {
            var str = new StringBuilder();
            str.Append(string.Format("{0,-30}", Value));
            str.Append(CountWord + ":");

            foreach (var line in Lines)
            {
                str.Append(" " + line);
            }

            return str.ToString();
        }

    }
}
