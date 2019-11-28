﻿using System;
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
            deliveredPresents.Add((Position)currentPosition.Clone(), 1);
            foreach (var direction in directions)
            {
                currentPosition.Move(direction);

                if (deliveredPresents.ContainsKey(currentPosition))
                {
                    deliveredPresents[currentPosition]++;
                }
                else
                {
                    deliveredPresents.Add((Position)currentPosition.Clone(), 1);
                }
            }

            System.Console.WriteLine($"{deliveredPresents.Where(p => p.Value >= 1).Count()}");
        }
    }

    public class Position : IEquatable<Position>, ICloneable
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

        public bool Equals(Position other)
        {
            if (other is null) return false;

            return other.X == this.X && other.Y == this.Y;
        }

        public override bool Equals(object obj) => Equals(obj as Position);
        public override int GetHashCode() => (X, Y).GetHashCode();
        public override string ToString() => $"({X},{Y})";

        public object Clone()
        {
            var p = new Position
            {
                X = this.X,
                Y = this.Y
            };

            return p;
        }

    }
}
