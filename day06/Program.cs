using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace day06
{
    class Program
    {
        static void Main(string[] args)
        {
            var lampActions = File.ReadAllLines("input.txt")
                .Where(l => !string.IsNullOrWhiteSpace(l))
                .Select(l => new LampAction
                {
                    CommandString = l
                })
                .ToList();

            Part1(lampActions);
        }

        static void Part1(List<LampAction> lampActions)
        {
            var grid = new bool[1000, 1000];
            foreach (var item in lampActions)
            {
                switch (item.Command)
                {
                    case Command.ON:
                        for (int y = item.Y1; y <= item.Y2; y++)
                        {
                            for (int x = item.X1; x <= item.X2; x++)
                            {
                                grid[x, y] = true;
                            }
                        }
                        break;
                    case Command.OFF:
                        for (int y = item.Y1; y <= item.Y2; y++)
                        {
                            for (int x = item.X1; x <= item.X2; x++)
                            {
                                grid[x, y] = false;
                            }
                        }
                        break;
                    case Command.TOGGLE:
                        for (int y = item.Y1; y <= item.Y2; y++)
                        {
                            for (int x = item.X1; x <= item.X2; x++)
                            {
                                grid[x, y] = !grid[x, y];
                            }
                        }
                        break;
                }

            }

            int lamps = 0;
            for (int y = 0; y <= grid.GetUpperBound(1); y++)
            {
                for (int x = 0; x <= grid.GetUpperBound(0); x++)
                {
                    if (grid[x, y]) lamps++;
                }
            }

            System.Console.WriteLine(lamps);
        }
    }

    public class LampAction
    {
        string pattern = "(turn on|turn off|toggle).([0-9]+,[0-9]+).through.([0-9]+,[0-9]+)";

        public string CommandString
        {
            set
            {
                var matches = Regex.Matches(value, pattern);

                switch (matches[0].Groups[1].Value)
                {
                    case "turn on":
                        Command = Command.ON;
                        break;
                    case "turn off":
                        Command = Command.OFF;
                        break;
                    case "toggle":
                        Command = Command.TOGGLE;
                        break;
                }

                X1 = int.Parse(matches[0].Groups[2].Value.Split(',')[0]);
                Y1 = int.Parse(matches[0].Groups[2].Value.Split(',')[1]);

                X2 = int.Parse(matches[0].Groups[3].Value.Split(',')[0]);
                Y2 = int.Parse(matches[0].Groups[3].Value.Split(',')[1]);
            }
        }

        public Command Command { get; private set; }
        public int X1 { get; private set; }
        public int Y1 { get; private set; }
        public int X2 { get; private set; }
        public int Y2 { get; private set; }
    }

    public enum Command
    {
        ON,
        OFF,
        TOGGLE
    }
}
