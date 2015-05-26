using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckPoint2_1.TextElements
{
    public class Word
    {
        public IList<Symbol> Value = new List<Symbol>();

        public Word() { }

        public bool IsConsonant
        {
            get { return "qwrtpsdfghklzxcvbnm".Contains(Char.ToString(this.Value[0].Value).ToLower()); }
        }

        public bool EndSentence
        {
            get { return Value[0].IsEndSentence; }
        }
        
        public override string ToString()
        {
          return Value.Aggregate("", (current, element) => current + element.ToString());
        }
    }
}
