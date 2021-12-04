using System;
using System.Collections.Generic;
using System.IO;

namespace Day04
{
    public class Board
    {
        private List<List<string>> _board = new List<List<string>>();
        public Board(List<string> board)
        {
            board.ForEach(line => _board.Add(new List<string>(line.Split(' '))));
        }

        public void PrintBoard()
        {
            Console.WriteLine("---------");
            foreach(var line in _board)
            {
                line.ForEach(entry => Console.Write( entry  + " ")); ;
                Console.WriteLine();
            }
        }

        public bool WinCondition()
        {
            foreach(var line in _board)
            {   
                bool col = true;
                foreach(var entry in line)
                {
                    if (entry != "X")
                    {
                        col = false;
                    }
                }
                if (col) return true;
            }

            return false;
        }

        public int CheckBoard(string number)
        {
            foreach(var line in _board)
            {
                for (int i=0; i < line.Count; i++)
                {
                    if (line[i] == number)
                    {
                        line[i] = "X";
                    }
                }
            }
            return -1;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string currentFile = projectDirectory + "\\Sample.txt";
            List<string> lines = new List<String>(File.ReadAllLines(currentFile));
            string instructions = lines[0];
            lines.RemoveAt(0);
            List<Board> allBoards = new List<Board>();
            List<string> input = new List<string>();
            foreach (string line in lines)
            {
                if (line == "")
                {   
                    if (input.Count > 0)
                    {
                        allBoards.Add(new Board(input));
                        input.Clear();
                        continue;
                    }
                } 
                input.Add(line);
            }
            allBoards.Add(new Board(input));
            string[] numberCallOuts = instructions.Split(",");
            Console.WriteLine(numberCallOuts.Length);
            for (int i=0; i < 5; i++)
            {
                allBoards.ForEach(board => board.CheckBoard(numberCallOuts[i]));
            }
            allBoards.ForEach(board => board.PrintBoard());
        }
    }
}
