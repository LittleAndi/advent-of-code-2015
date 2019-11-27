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

            int floor = 0;
            foreach (var c in lines[0])
            {
                if (c == '(') floor++;
                if (c == ')') floor--;
            }

            System.Console.WriteLine($"Stopped at floor {floor}");
        }
    }
}
