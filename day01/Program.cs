using System;
using System.IO;
using System.Linq;

namespace day01
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt")
                .Where(l => !string.IsNullOrWhiteSpace(l))
                .ToList();

            Part1(lines[0]);
        }

        static void Part1(string input)
        {
            int floor = 0;
            foreach (var c in input)
            {
                if (c == '(') floor++;
                if (c == ')') floor--;
            }

            System.Console.WriteLine($"Part 1: Stopped at floor {floor}");
        }
    }
}
