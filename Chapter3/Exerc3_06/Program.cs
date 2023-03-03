using System;
using System.Linq;

namespace Chapter3.Exerc3_06
{
    public static class WordUtilities
    {
        public static string ReverseWords(string sentence)
        {
            Func<string, string> swapWords = phrase => {
                var words = phrase
                .Split(' ')
                .Reverse();
                return string.Join(' ', words);
            };
            return swapWords(sentence);
        }
    }

    public static class Program
    {
        public static void Main()
        {
            while(true){
                Console.Write("Enter a sentence: ");
                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    break;
                }
                var result = WordUtilities.ReverseWords(input);
                Console.WriteLine($"Reversed: {result}");
            }
        }
    }
}