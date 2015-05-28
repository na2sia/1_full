using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CheckPoint2_1.TextElements;

namespace CheckPoint2_1.TextElements
{
    public class Sentence:ICollection<ISentenceItem>
    {
        private readonly ICollection<ISentenceItem> _sentenceItemsCollection;

        public Sentence(ICollection<ISentenceItem> sentenceItemsCollection)
        {
            _sentenceItemsCollection = sentenceItemsCollection;
            IsReadOnly = _sentenceItemsCollection.IsReadOnly;
            Count = _sentenceItemsCollection.Count;
            IsInterrogativeSentence = CheckIsInterrogativeSentence();
            IsExclamatorySentence = CheckIsExclamatorySentence();
        }

        public bool IsExclamatorySentence { get; private set; }
        public bool IsInterrogativeSentence { get; private set; }

        public IEnumerator<ISentenceItem> GetEnumerator()
        {
            return _sentenceItemsCollection.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void Add(ISentenceItem item)
        {
            _sentenceItemsCollection.Add(item);
            Count = _sentenceItemsCollection.Count;
        }
        public void Clear()
        {
            _sentenceItemsCollection.Clear();
            Count = 0;
        }
        public bool Contains(ISentenceItem item)
        {
            return _sentenceItemsCollection.Contains(item);
        }
        public void CopyTo(ISentenceItem[] array, int arrayIndex)
        {
            _sentenceItemsCollection.CopyTo(array, arrayIndex);
        }
        public bool Remove(ISentenceItem item)
        {
            return _sentenceItemsCollection.Remove(item);
        }
        public int Count { get; private set; }
        public bool IsReadOnly { get; private set; }
        public override string ToString()
        {
            return _sentenceItemsCollection.Aggregate("", (current, iSentenceItem) => current + iSentenceItem.Value);
        }

        private bool CheckIsInterrogativeSentence()
        {
            if (this.Last() is Punctuation)
            {
                return (this.Last() == Punctuation.GetPunctuationByStringValue("?") ||
                        this.Last() == Punctuation.GetPunctuationByStringValue("?!"));
            }
            throw new FormatException("Sentence hasn't punctuation in the end");
        }

        private bool CheckIsExclamatorySentence()
        {
            if (this.Last() is Punctuation)
            {
                return (this.Last() == Punctuation.GetPunctuationByStringValue("!") ||
                        this.Last() == Punctuation.GetPunctuationByStringValue("?!"));
            }
            throw new FormatException("Sentence hasn't punctuation in the end");
        }
    }
}
