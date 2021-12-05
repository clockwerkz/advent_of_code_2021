using System;
using System.Collections.Generic;
using System.IO;

namespace Day05
{
    class Coords
    {
        public int X;
        public int Y;
        public Coords(int x, int y)
        {
            X = x;
            Y = y;
        }

        public string ToString()
        {
            return "(" + X + "," + Y + ")";
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
                Coords point1 = new Coords(Int32.Parse(cmds[0].Split(",")[1]), Int32.Parse(cmds[0].Split(",")[0]));
                Coords point2 = new Coords(Int32.Parse(cmds[1].Split(",")[1]), Int32.Parse(cmds[1].Split(",")[0]));
                maxX = Math.Max(maxX, Math.Max(point1.X, point2.X));
                maxY = Math.Max(maxY, Math.Max(point1.Y, point2.Y));
                allLines.Add(new Line(point1, point2));
       
            }
            Console.WriteLine("Largest X: " + maxX + " and largest Y: " + maxY);
            int[, ] board = new int[maxX + 1, maxY + 1];
            for (int i=0; i< board.GetLength(0); i++)
            {
                for (int j=0; j < board.GetLength(1); j++)
                {
                    board[i, j] = 0;
                }
            }
            Console.WriteLine("Total straight lines: " + allLines.Count);
            foreach (var line in allLines)
            {
                DrawLine(board, line);
            }
            PrintBoard(board);
            Console.WriteLine("Values that are 2 or greater: " + CountTwoOrMore(board));
        }

        static void PrintBoard(int [ , ] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void DrawLine(int [ , ] board, Line line)
        {
            if (IsDiagonal(line.Start, line.End))
            {
                int y;
                Console.WriteLine("Points: " + line.Start.ToString() + " and " + line.End.ToString());
                if (line.Start.X < line.End.X)
                {
                    y = line.End.Y;
                    for (int x = line.Start.X; x <= line.End.X; x++)
                    {
                        board[x, y--]++;
                    }
                    return;
                }
                /*
                y = line.Start.Y;
                for (int x = line.Start.X; x <= line.End.X; x++)
                {
                    board[x, y++]++;
                }*/
                return;
                
            }
            if (line.Start.X != line.End.X)
            {
                for (int i=Math.Min(line.Start.X, line.End.X); i <= Math.Max(line.Start.X, line.End.X); i++)
                {
                    board[i, line.Start.Y]++;
                }
                return;
            }
            for (int i = Math.Min(line.Start.Y, line.End.Y); i <= Math.Max(line.Start.Y, line.End.Y); i++)
            {
                board[line.Start.X, i]++;
            }
        }

        static int CountTwoOrMore(int [ , ] board)
        {
            int sum = 0;
            for (int i=0; i < board.GetLength(0); i++)
            {
                for(int j=0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] >= 2) sum++;
                    
                }
            }
            return sum;
        }

        static bool IsDiagonal(Coords p1, Coords p2)
        {
            return p1.X != p2.X && p1.Y != p2.Y;
        }
    }
}
