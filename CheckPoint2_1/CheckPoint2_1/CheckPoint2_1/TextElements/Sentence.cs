using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CheckPoint2_1.TextElements;

namespace CheckPoint2_1.TextElements
{
    public class Sentence
    {
        public IList<Word> Value = new List<Word>();

        public Sentence(){}
       
        public override string ToString()
        {
          return Value.Aggregate("", (current, element) => current + element.ToString() + " ");
        }
    }
}
