using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace CV04
{
    class StringStatistics
    {
        public string Data { get; set; }
        private readonly string[] _words;

        public StringStatistics(string data)
        {
            Data = data;
            _words = Data.Split(' ', '\n').Select(word =>
            {
                return new string(word.Where(character => !char.IsPunctuation(character)).ToArray());
            }).ToArray();
        }

        public int WordCount() => _words.Length;


        public int LineCount() => Data.Split('\n').Length;

        public int SentenceCount()
        {
            var sentences = Data.Split('!', '?', '.');
            sentences = sentences.Where(sentence => sentence != "").ToArray();
            sentences = sentences.Where(sentence =>
            {
                if ((sentence[0] == ' ' && char.IsLower(sentence[1])) ||
                    char.IsLower(sentence[0]))
                {
                    return false;
                }

                return true;
            }).ToArray();
            return sentences.Length;
        }

        public string[] LongestWords()
        {
            var orderedWords = _words.OrderByDescending(word => word.Length).ToArray();
            var maxLength = orderedWords[0].Length;
            return orderedWords.TakeWhile(word => word.Length == maxLength).ToArray();
        }

        public string[] ShortestWords()
        {
            var orderedWords = _words.OrderBy(word => word.Length).ToArray();
            var minLength = orderedWords[0].Length;
            return orderedWords.TakeWhile(word => word.Length == minLength).ToArray();
        }

        public string[] SortByAlphabet() => _words.OrderBy(word => word).ToArray();

        public string[] MostCommonWords()
        {
            var occurrences = new Dictionary<string, int>();
            foreach (var word in _words)
            {
                if (!occurrences.ContainsKey(word))
                {
                    occurrences.Add(word, 1);
                }
                else
                {
                    occurrences[word]++;
                }
            }

            var max = occurrences.Values.Max();

            return (from pair in occurrences where pair.Value == max select pair.Key).ToArray();
        }
    }
}