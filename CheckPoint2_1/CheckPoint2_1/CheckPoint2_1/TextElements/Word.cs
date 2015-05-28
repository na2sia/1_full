using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckPoint2_1.TextElements
{
    public class Word:IWord,IComparable<Word>
    {
        public string Value { get; private set; }
        public bool IsConsonantBegining { get; private set; }
        public long Count { get; set; }

        private readonly SortedSet<int> _pages;

        public void AddPage(int page)
        {
            _pages.Add(page);
        }

        public override string ToString()
        {
            var str = new StringBuilder();
            str.Append(string.Format("{0,-30}", Value));
            str.Append(Count + ":");

            foreach (var page in _pages)
            {
                str.Append(" " + page);
            }

            return str.ToString();
        }
        private Word(string word, bool consonant)
        {
            Value = word;
            IsConsonantBegining = consonant;
            _pages = new SortedSet<int>();
        }

        public static readonly char[] Consonant =
        {
            'q', 'w', 'r', 't', 'p', 's', 'd', 'f', 'g','h', 'k','l','z','x','c','v','b','n','m',
            'ц', 'к', 'н', 'г', 'ш', 'щ', 'з', 'х', 'ф', 'в', 'п', 'р', 'л', 'д', 'ж', 'ч', 'с', 'м','т','б'
        };

        public static Word GetWordByStringValue(string value)
        {
            return new Word(value, Consonant.Contains(value.First()));
        }


        public int CompareTo(Word other)
        {
            return String.Compare(Value, other.Value, StringComparison.Ordinal);
        }
    }
}
