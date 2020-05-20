using System;
using System.Collections.Generic;
using System.Linq;

namespace MostFrequentlyUsedWordsInAText
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "In a village of La Mancha, the name of which I have no desire to call to," +
                  "mind, there lived not long since one of those gentlemen that keep a lance," +
                  "in the lance-rack, an old buckler, a lean hack, and a greyhound for," +
                  "coursing. An olla of rather more beef than mutton, a salad on most," +
                  "nights, scraps on Saturdays, lentils on Fridays, and a pigeon or so extra," +
                  "on Sundays, made away with three-quarters of his income.";

            var results = Top3(text);
            Console.WriteLine(string.Join(",", results));
            Console.ReadLine();
        }

        public static List<string> Top3(string inputString)
        {
            List<char> delimiterCharsList = new List<char>();
            for (char c = (char)0; c < 255; c++)
                if (!(char.IsLetter(c) || c == '\''))
                    delimiterCharsList.Add(c);

            char[] delimiterChars = delimiterCharsList.ToArray();
            var topWords = new List<string>();
            var containsLetter = inputString.Any(x => char.IsLetter(x));

            if (containsLetter)
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
