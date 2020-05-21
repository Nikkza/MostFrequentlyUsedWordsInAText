using System;
using System.Collections.Generic;
using System.Linq;

namespace MostFrequentlyUsedWordsInAText
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();
                var results = Top3(input);
                Console.WriteLine(results.Count > 0 ? string.Join(",", results) : "NO LETTERS");

            }
        }

        public static List<string> Top3(string inputString)
        {
            List<char> delimiterCharsList = new List<char>();
            var topWordsSingleQuotes = new List<string>();
            var topWords = new List<string>();
            char[] singleQuote = { '\'' };
            for (char c = (char)0; c < 255; c++)
            {
                if (!(char.IsLetter(c) || c == '\''))
                    delimiterCharsList.Add(c);
            }

            char[] delimiterChars = delimiterCharsList.ToArray();
          
            if (inputString.Any(x => char.IsLetter(x)))
            {
                topWords = GetCountedList(inputString, delimiterChars);

                var findSingleQuote = topWords.Any(x => x.Substring(0, 1) == '\''.ToString() || x.Substring(x.Length - 1) == '\''.ToString());

                if (findSingleQuote)
                {
                    string word = string.Empty;
                    foreach (var item in topWords)
                        word += item;

                    topWordsSingleQuotes = GetCountedList(word, singleQuote);
                }
            }

            return topWordsSingleQuotes.Count() != 0 ? topWordsSingleQuotes : topWords;
        }

        static List<string> GetCountedList(string input, char[] c)
        {
            var list = input
                    .Split(c, StringSplitOptions.RemoveEmptyEntries)
                    .GroupBy(gr => gr.ToLower())
                    .Select(x => new { Key = x.Key, Count = x.Count() })
                    .OrderByDescending(x => x.Count).Take(3)
                    .Select(group => group.Key).ToList();

            return list;
        }
    }
}
