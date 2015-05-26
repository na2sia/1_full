using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CheckPoint2_1.TextElements;
using System.Globalization;

namespace CheckPoint2_1.TextElements
{
    public class Symbol
    {
        public char Value { get; private set; }

        public Symbol(char value)
        {
            Value = value;
        }

        public bool IsPunctuationMark
        {
            get { return ((Value < 'a' || Value > 'z') && (Value < 'A' || Value > 'Z') && Value != '\''); }
        }

        public bool IsEndSentence
        {
            get { return Value == '.' || Value == '!' || Value == '?'; }
        }
        
        public override string ToString()
        { 
          return this.Value.ToString(CultureInfo.InvariantCulture); 
        }
    }
}
