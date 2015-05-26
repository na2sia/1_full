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
            foreach (var element in SplitSentences(SplitWords(SplitSymbols(text))))
            {
                Value.Add(element);
            }
            return tempText;
        }

        private IList<Sentence> SplitSentences(IList<Word> text)
        {
            var tempListSentence = new List<Sentence>();
            var tempSentence = new Sentence();
            foreach (var element in text)
            {
                if (!element.EndSentence)
                {
                    tempSentence.Value.Add(element);
                }
                else
                {
                    tempSentence.Value.Add(element);
                    tempListSentence.Add(tempSentence);
                    tempSentence = new Sentence();
                }
            }
            return tempListSentence;
        }

        private  IList<Word> SplitWords(IList<Symbol> text)
        {
            var tempListWord = new List<Word>();
            var tempWord = new Word();
            
            foreach (var element in text)
            {
                if (!(Char.IsWhiteSpace(element.Value)))
                {
                    if (!element.IsPunctuationMark)
                    {
                        tempWord.Value.Add(element);
                    }
                    
                    if (element.IsPunctuationMark)
                    {
                        tempListWord.Add(tempWord);
                        tempWord = new Word();
                        tempWord.Value.Add(element);
                    }
                }
                else
                {
                    tempListWord.Add(tempWord);
                    tempWord = new Word();
                }
            }
            return tempListWord;
        }

        private IList<Symbol> SplitSymbols(string text)
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

        public List<Word> GetWords(int lenghtWords)
        {
            List<Word> tempWord = new List<Word>();
            foreach (var sentence in Value.Select(sentence => sentence.Value))
            {                
                foreach (var word in sentence.Select(word => word.Value))
                {
                    foreach (var symbol in word.Select(symbol => symbol.Value))
                    {
                        if (symbol == '?')
                        {
                            tempWord = (sentence.Select(sent => sent).Where(sent => sent.Value.Count() == lenghtWords)).ToList();
                        }
                    }

                }
            }
            return tempWord;
        }
        
        public List<Sentence> DeleteWords(int lenghtOfWords)
        {
            List<Sentence> tempText = new List<Sentence>();
            tempText = Value.ToList();
            foreach (var word in tempText.SelectMany(sentence => sentence
                .Value.Where(word => word.IsConsonant && word.Value.Count() == lenghtOfWords)))
            {
                word.Value.Clear();
            }
            return tempText;
        }

        public List<Sentence> ReplaceWords(int lenghtWords, string substr)
        {
            var wordSubstr = new Word() { Value = SplitSymbols(substr) };
            List<Sentence> tempText = new List<Sentence>();
            tempText = Value.ToList();
            foreach (var word in tempText
                .SelectMany(sentence => sentence
                .Value.Where(word => word.Value.Count() == lenghtWords)))
            {
                word.Value = wordSubstr.Value;
            }
            return tempText;
        }
        
       
     }
}
