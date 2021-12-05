using System;
using System.Collections.Generic;
using System.IO;

namespace Day04
{
    public class Board
    {
        private List<List<string>> _board = new List<List<string>>();
        private bool _hasWon = false;
        public Board(List<string> board)
        {
            foreach (string line in board)
            {
                string[] row = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                _board.Add(new List<string>(row));
            } 
        }

        public void PrintBoard()
        {
            Console.WriteLine("---------");
            foreach(var line in _board)
            {
                line.ForEach(entry => Console.Write(entry  + " ")); ;
                Console.WriteLine();
            }
        }

        public bool HasWon()
        {
            return _hasWon;
        }

        public bool WinCondition()
        {
            foreach(var line in _board)
            {   
                foreach(var entry in line)
                {
                    string currentLine = String.Join("", line.ToArray());
                    if (currentLine == "XXXXX")
                    {
                        return true;
                    }
                }
            }
            for (int i=0; i < _board[0].Count; i++)
            {
                bool row = true;
                for (int j=0; j < _board.Count; j++)
                {
                    if (_board[j][i] != "X")
                    {
                        row = false;
                    }
                }
                if (row) return true;
            }

            return false;
        }

        private int SumBoard()
        {
            int sum = 0;
            foreach (var row in _board)
            {
                foreach(var col in row)
                {
                    if (col != "X")
                    {
                        sum += Int32.Parse(col);
                    }
                }
            }
            return sum;
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
                        if (WinCondition())
                        {
                            _hasWon = true;
                            return Int32.Parse(number) * SumBoard();
                        }
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
            Console.WriteLine("---DAY 4: PART 2---");
            string currentFile = projectDirectory + "\\Day4Input.txt";
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
            Console.WriteLine("Number of bingo boards: " + allBoards.Count);
            string[] numberCallOuts = instructions.Split(",");
            int secretCode = -1;
            int currentCount = 1;
            for (int i=0; i < numberCallOuts.Length; i++)
            {
                foreach(var board in allBoards)
                {
                    if (board.HasWon()) continue;
                    int res = board.CheckBoard(numberCallOuts[i]);
                    if (res > 0)
                    {
                        Console.WriteLine("BINGO!! board #" + currentCount++ + " WINS!!");
                        secretCode = res;
                    }
                }
                if (secretCode > 0)
                {
                    Console.WriteLine("Code to enter: " + secretCode);
                    secretCode = -1;
                }
            }
        }
    }
}
