using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day02
{
    class Program
    {
        static void Main(string[] args)
        {
            var presents = File.ReadAllLines("input.txt")
                .Where(l => !string.IsNullOrWhiteSpace(l))
                .Select(l => new Present 
                    {
                        Length = int.Parse(l.Split('x')[0]),
                        Width = int.Parse(l.Split('x')[1]),
                        Height = int.Parse(l.Split('x')[2])
                    })
                .ToList();

            Part1(presents);
        }

        static void Part1(List<Present> presents)
        {
            var totalPaper = presents.Select(p => p.WrappingPaper + p.Slack).Sum();
            System.Console.WriteLine($"{totalPaper} sq ft is needed.");
        }
    }

    public class Present
    {
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int WrappingPaper => 2 * Length * Width + 2 * Width * Height + 2 * Height * Length;
        public int Slack
        {
            get {
                var sides = new HashSet<int>();
                sides.Add(Length * Width);
                sides.Add(Width * Height);
                sides.Add(Height * Length);
                return sides.OrderBy(s => s).First();
            }
        }
    }
}
