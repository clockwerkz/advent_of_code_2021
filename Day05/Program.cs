using System;
using System.Collections.Generic;
using System.IO;

namespace Day05
{
    struct Coords
    {
        public int X;
        public int Y;
        public Coords(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    struct Line
    {
        public Coords Start;
        public Coords End;
        public Line(Coords start, Coords end)
        {
            Start = start;
            End = end;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            Console.WriteLine("---DAY 5: PART 1---");
            string currentFile = projectDirectory + "\\Sample.txt";
            int maxX = 0;
            int maxY = 0;
            string[] lines = File.ReadAllLines(currentFile);
            List<Line> allLines = new List<Line>();
            foreach(string line in lines)
            {
                string[] cmds = line.Split(" -> ");
                Coords point1 = new Coords(Int32.Parse(cmds[0].Split(",")[0]), Int32.Parse(cmds[0].Split(",")[1]));
                Coords point2 = new Coords(Int32.Parse(cmds[1].Split(",")[0]), Int32.Parse(cmds[1].Split(",")[1]));
                maxX = Math.Max(maxX, Math.Max(point1.X, point2.X));
                maxY = Math.Max(maxY, Math.Max(point1.Y, point2.Y));
                if (!IsDiagonal(point1, point2))
                {
                    allLines.Add(new Line(point1, point2));
                }
            }
            Console.WriteLine(allLines.Count);
            Console.WriteLine("Board size: " + maxX + ", " + maxY);
        }

        static bool IsDiagonal(Coords p1, Coords p2)
        {
            return p1.X == p2.X || p1.Y == p2.Y;
        }
    }
}
