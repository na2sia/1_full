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

        public bool BeginsWithConsonant
        {
            get { return "qwrtpsdfghklzxcvbnm".Contains(Char.ToString(this.Value[0].Value).ToLower()); }
        }

        public bool DoesEndSentence
        {
            get { return Value[Value.Count - 1].IsEndOfSentence(); }
        }
        public bool InterrogativeSentence
        {
            get { return Value[Value.Count - 1].IsInterrogative();}
        }

        public override string ToString()
        {
            return Value.Aggregate("", (current, element) => current + element.ToString());
        }
    }
}
