using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace day03
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

        static void Part1(string directions)
        {
            Dictionary<Position, int> deliveredPresents = new Dictionary<Position, int>();

            var currentPosition = new Position { X = 0, Y = 0 };
            deliveredPresents.Add(currentPosition, 1);
            foreach (var direction in directions)
            {

                var pos = new Position { };
            }
        }
    }

    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public void Move(char direction)
        {
            switch (direction)
            {
                case '>':
                    X++;
                    break;
                case 'v':
                    Y++;
                    break;
                case '<':
                    X--;
                    break;
                case '^':
                    Y--;
                    break;
            }
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            var p = (Position)obj;
            return p.X == X && p.Y == Y;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            // TODO: write your implementation of GetHashCode() here
            throw new System.NotImplementedException();
            return base.GetHashCode();
        }
    }
}
