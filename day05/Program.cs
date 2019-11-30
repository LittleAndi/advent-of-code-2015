using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace day05
{
    class Program
    {
        static void Main(string[] args)
        {
            var nonStrings = File.ReadAllLines("input.txt")
                .Where(l => !string.IsNullOrWhiteSpace(l))
                .Select(l => new NaughtyOrNice { Input = l })
                .ToList();

            Part1(nonStrings);
            Part2(nonStrings);

        }

        static void Part1(List<NaughtyOrNice> nonStrings)
        {
            var niceCount = nonStrings.Where(n => n.IsNice).Count();
            System.Console.WriteLine($"Part 1: Found {niceCount} nice strings.");
        }

        static void Part2(List<NaughtyOrNice> nonStrings)
        {
            var niceCount = nonStrings.Where(n => n.IsNiceToo).Count();
            System.Console.WriteLine($"Part 2: Found {niceCount} nice strings.");
        }
    }

    public class NaughtyOrNice
    {
        public string Input { get; set; }
        public bool IsNice => ContainsAtLeastThreeVowels && ContainsRepeatingLetters && !ContainsInvalidStrings;
        public bool IsNiceToo => ContainsRepeatingLettersWithSpace && ContainsRepeatingCharacterPair;

        public bool ContainsAtLeastThreeVowels
        {
            get
            {
                var vowels = "aeiou";
                var vowelCount = 0;
                foreach (var item in Input)
                {
                    if (vowels.Contains(item)) vowelCount++;
                }

                return vowelCount >= 3;
            }
        }
        public bool ContainsRepeatingLetters
        {
            get
            {
                for (int i = 1; i < Input.Length; i++)
                {
                    if (Input[i] == Input[i - 1]) return true;
                }
                return false;
            }
        }
        public bool ContainsRepeatingLettersWithSpace
        {
            get
            {
                for (int i = 2; i < Input.Length; i++)
                {
                    if (Input[i] == Input[i - 2]) return true;
                }
                return false;
            }
        }
        public bool ContainsInvalidStrings
        {
            get
            {
                bool containsInvalidChars = false;
                if (Input.Contains("ab")) containsInvalidChars = true;
                if (Input.Contains("cd")) containsInvalidChars = true;
                if (Input.Contains("pq")) containsInvalidChars = true;
                if (Input.Contains("xy")) containsInvalidChars = true;
                return containsInvalidChars;
            }
        }

        public bool ContainsRepeatingCharacterPair
        {
            get
            {
                for (int i = 0; i < Input.Length - 2; i++)
                {
                    var test = Input.Substring(i, 2);
                    if (Input.Replace(test, "..").Count(c => c.Equals('.')) >= 4) return true;
                }
                return false;
            }
        }
    }
}
