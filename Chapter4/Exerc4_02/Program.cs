﻿using System;
using System.Collections.Generic;

namespace Chapter4.Exercises
{
    static class Exerc4_02
    {
        public static IEnumerable<KeyValuePair<string, int>> Process(string phrase)
        {
            var wordCounts = new Dictionary<string, int>();

            var words = phrase.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in words)
            {
                var key = word;
                if (char.IsPunctuation(key[key.Length - 1]))
                {
                    key = key.Remove(key.Length - 1);
                }

                if (wordCounts.TryGetValue(key, out var count))
                {
                    wordCounts[key] = count + 1;
                }
                else
                {
                    wordCounts.Add(key, 1);
                }
            }

            return wordCounts;
        }
    }

    class Program
    {
        public static void Main()
        {
            string input;
            do
            {
                Console.Write("Enter a phrase:");
                input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input))
                {
                    var countsByWord = WordCounter.Process(input);
                    var i = 0;
                    foreach (var (key, value) in countsByWord)
                    {
                        Console.Write($"{key.PadLeft(20)}={value}\t");
                        i++;
                        if (i % 3 == 0)
                        {
                            Console.WriteLine();
                        }
                    }
                }
        }
    }
}