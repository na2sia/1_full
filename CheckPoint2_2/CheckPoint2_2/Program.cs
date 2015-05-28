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
            SortedDictionary<char, SortedDictionary<string, WordInfo>> concordance = new SortedDictionary<char, SortedDictionary<string, WordInfo>>();
            while ((readFile = inputFile.ReadLine()) != null)
            {
                var text = readFile.ToLower().Split(separator, StringSplitOptions.RemoveEmptyEntries);
                foreach (string i in text)
                { 
                   if (!concordance.ContainsKey(i[0]))
                   concordance[i[0]] = new SortedDictionary<string, WordInfo>();

                if (!concordance[i[0]].ContainsKey(i))
                {
                    concordance[i[0]][i] = new WordInfo(i);
                    concordance[i[0]][i].CountWord = 0;
                }

                concordance[i[0]][i].AddLines(CountLine);
                concordance[i[0]][i].CountWord++;
            }

                CountLine++;
            }

                using (var outputFile = new StreamWriter("dict.txt"))
                foreach (var letter in concordance.Keys)
                {
                    outputFile.WriteLine("===============  " + char.ToUpper(letter) + "  ===============");
                    foreach (var wordInfo in concordance[letter].Values)
                    {
                        outputFile.WriteLine(wordInfo.ToString());
                    }
                }

        }
    }
}
