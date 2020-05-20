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
            for (char c = (char)0; c < 255; c++)
            {
                if (!(char.IsLetter(c) || c == '\''))
                    delimiterCharsList.Add(c);
            }

            char[] delimiterChars = delimiterCharsList.ToArray();
            var topWords = new List<string>();

            if (inputString.Any(x => char.IsLetter(x)))
            {
                topWords = inputString
                    .Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries)
                    .GroupBy(gr => gr.ToLower())
                    .Select(x => new { Key = x.Key, Count = x.Count() })
                    .OrderByDescending(x => x.Count).Take(3)
                    .Select(group => group.Key).ToList();
            }
            return topWords;
        }
    }
}
