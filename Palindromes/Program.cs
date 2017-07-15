using System;
using System.Linq;

namespace Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 0)
            {
                Console.WriteLine("Usage: Palindromes.exe string");
                return;
            }

            var palindromes = new PalindromeFinder(args[0]).Unique(3);

            foreach (var palindrome in palindromes.Where(t => t.Item2 > 0))
            {
                var substring = args[0].Substring(palindrome.Item1, palindrome.Item2);
                Console.WriteLine($"Text: {substring}, Index: {palindrome.Item1}, Length: {palindrome.Item2}");
            }
        }
    }
}