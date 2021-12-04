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
            _board.ForEach(line => line.ForEach(entry => Console.Write(entry + " ")));
        }

        public bool CheckBoard(string number)
        {

            return true;
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
            Board newBoard;
            List<string> input = new List<string>();
            foreach (string line in lines)
            {

                if (line == "")
                {   
                    if (input.Count > 0)
                    {
                        newBoard = new Board(input);
                        Console.WriteLine("New Board:");
                        newBoard.PrintBoard();
                        input.Clear();
                    }
                } else
                {
                    input.Add(line);
                }
            }
        }
    }
}
