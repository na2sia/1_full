using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace CheckPoint2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] separator = new char[10] { ';',' ','.',',',':','(',')','?','!','"'};

            StreamReader inputFile = new StreamReader("test.txt", Encoding.Default);
            string readFile;
            int CountLine = 1;

            Dictionary<string, Words> MyDictionary = new Dictionary<string, Words>();
            
            while ((readFile = inputFile.ReadLine()) != null)
            {
                var text = readFile.ToLower().Split(separator, StringSplitOptions.RemoveEmptyEntries);
                foreach (string i in text)
                { 
                    Words word;
                    if (!MyDictionary.TryGetValue(i, out word))
                        word = MyDictionary[i] = new Words();
                    word.Lines.Add(CountLine);
                    word.CountWord++;
                }
                CountLine++;
            }

            using( var outputFile = new StreamWriter("dict.txt"))
            foreach (var k in MyDictionary.OrderBy(x=>x.Key))
            {
                outputFile.WriteLine("{0}{1}: {2}", k.Key.PadRight(20, '.'), k.Value.CountWord, string.Join(" ", k.Value.Lines.OrderBy(l => l)));
            }

        }
    }
}
