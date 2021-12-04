using System;
using System.Collections.Generic;
using System.IO;

namespace Day04
{
    class Board
    {
        List<List<string>> board = new List<List<string>>();
        Board(List<string> _board)
        {
            _board.ForEach(line => board.Add(new List<string>(line.Split(' '))));
        }

        public void PrintBoard()
        {
            board.ForEach(line => line.ForEach(entry => Console.Write(entry + " ")));
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
            lines.ForEach(line => Console.WriteLine(line));
        }
    }
}
