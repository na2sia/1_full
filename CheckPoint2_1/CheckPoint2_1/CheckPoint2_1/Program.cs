using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CheckPoint2_1.TextElements;

namespace CheckPoint2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Reading text from the file
            var rawString = Reader.Read("text.txt");
           
            //Parsing text
            Text newText = new Text();
            newText.Parse(rawString);
            Console.WriteLine(newText);

            Console.ReadLine();

            //Printing words from a question
            foreach (var i in newText.GetWords(6))
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();

            //Sorting sentences
            foreach (var i in newText.SortSentences())
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();

            //Deliting Words
            foreach (var i in newText.DeleteWords(4))
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();

            //Replacing words
            foreach (var i in newText.ReplaceWords(7, "DANGER"))
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();

        }
    }
}
