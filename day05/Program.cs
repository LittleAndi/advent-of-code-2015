using System;
using System.IO;
using System.Linq;

namespace day05
{
    class Program
    {
        static void Main(string[] args)
        {
            var presents = File.ReadAllLines("input.txt")
                .Where(l => !string.IsNullOrWhiteSpace(l))
                .ToList();
        }
    }

    public class NaughtyOrNice
    {
        public string Input { get; set; }
        public bool IsNice => ContainsRepeatingLetters && !ContainsInvalidStrings;

        public bool ContainsAtLeastThreeVowels => false;
        public bool ContainsRepeatingLetters
        {
            get
            {
                for (int i = 1; i < Input.Length; i++)
                {
                    if (Input[i] == Input[i-1]) return true;
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
    }
}
