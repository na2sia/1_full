using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CheckPoint2_1.TextElements;

namespace CheckPoint2_1
{
    public class Reader
    {
        public static string Read(string pathToFile)
        {
            if (!File.Exists(pathToFile))
            {
                Console.WriteLine("Incorrect path");
                return null;
            }
            var text = File.ReadAllText(pathToFile, Encoding.UTF8);
            return StringFormat(text);
        }

        public static string StringFormat(string text)
        {
            text = text.Replace("\t", " ");
            text = text.Replace("\n", " ");
            text = text.Replace("\r", " ");
            while (text.Contains("  "))
            {
                text = text.Remove(text.IndexOf("  ", System.StringComparison.Ordinal), 1);
            }
            return text;
        }
    }
}
