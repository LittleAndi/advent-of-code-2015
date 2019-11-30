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
        public bool IsNice => false;
    }
}
