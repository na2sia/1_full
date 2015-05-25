using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckPoint2_1.TextElements
{
   public class Text
    {
        public IList<Sentence> Value = new List<Sentence>();

        public Text(){}

        public override string ToString()
        {
            return Value.Aggregate("", (current, element) => current + element.ToString());
        }
        public IList<Sentence> Parse(string text)
        {
            var tempText = new List<Sentence>();
            foreach (var element in SplitBySentences(SplitByWords(SplitBySymbols(text))))
            {
                Value.Add(element);
            }
            return tempText;
        }

        private IList<Sentence> SplitBySentences(IList<Word> text)
        {
            var tempSentenceList = new List<Sentence>();
            var tempSentence = new Sentence();
            foreach (var element in text)
            {
                if (!element.DoesEndSentence)
                {
                    tempSentence.Value.Add(element);
                }
                else
                {
                    tempSentence.Value.Add(element);
                    tempSentenceList.Add(tempSentence);
                    tempSentence = new Sentence();
                }
            }
            return tempSentenceList;
        }

        private  IList<Word> SplitByWords(IList<Symbol> text)
        {
            var tempWordList = new List<Word>();
            var tempWord = new Word();
            foreach (var element in text)
            {
                if (!(Char.IsWhiteSpace(element.Value)))
                {
                    tempWord.Value.Add(element);
                }
                else
                {
                    tempWordList.Add(tempWord);
                    tempWord = new Word();
                }
            }
            return tempWordList;
        }

        private IList<Symbol> SplitBySymbols(string text)
        {
            return text.Select(element => new Symbol(element)).ToList();
        }

        public  List<Sentence> SortSentences()
        {
            IEnumerable<Sentence> query = from sentence in Value
                                          orderby sentence.Value.Count()
                                          select sentence;
            return query.ToList();
        }
        public IEnumerable<Word> GetWords()
        {
            Symbol Interrogative = new Symbol('?');
            foreach (var word in Value.SelectMany(sentence=>sentence.Value.Where(word=>word.Value.Contains(Interrogative))))
            {
                yield return word;
            }
        }

        public IList<Sentence> DeleteWords(int lenghtOfWords)
        {
            IList<Sentence> tempText = new List<Sentence>();
            tempText = Value;
            foreach (var word in tempText.SelectMany(sentence => sentence
                .Value.Where(word => word.BeginsWithConsonant && word.Value.Count() == lenghtOfWords)))
            {
                word.Value.Clear();
            }
            return tempText;
        }

        public IList<Sentence> ReplaceWords(int lenghtWords, string substitute)
        {
            var wordSubstiture = new Word() { Value = SplitBySymbols(substitute) };
            IList<Sentence> tempText = new List<Sentence>();
            tempText = Value;
            foreach (var word in tempText
                .SelectMany(sentence => sentence
                .Value.Where(word => word.Value.Count() == lenghtWords)))
            {
                word.Value = wordSubstiture.Value;
            }
            return tempText;
        }
       // public IEnumerable<Word> GetWords(int lenghtOfWords)
        //{            foreach (var word in Value.SelectMany(sentence => sentence.IfInterrogativeSentence).Where(word=>word.))
                //.Where(word => word.Value.Count == lenghtOfWords)))
            //{                yield return word;            }        }
    }
}
