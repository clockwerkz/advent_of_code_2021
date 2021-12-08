using System;
using System.IO;

namespace Day08
{
    class Program
    {
        static void Main(string[] args)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string currentFile = projectDirectory + "\\Day8Input.txt";
            string[] lines = File.ReadAllLines(currentFile);
            Console.WriteLine("---DAY 8: PART 1---");
            Console.Write("Day 8 Part 1 Input Answer: ");
            CalculatePartOne(lines);
        }

        static void CalculatePartOne(string[] lines)
        {
            if (lines.Length == 0) return;
            int digitCount = 0;
            //1 = 2 segments,4  = 4 segments,7 = 3 segments,8 = 7 segments
            foreach (string line in lines)
            {
                string panelLine = line.Split(" | ")[1];
                string[] display = panelLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                foreach (string digit in display)
                {
                    if (digit.Length == 7  || digit.Length == 2 || digit.Length == 3 || digit.Length == 4)
                    {
                        digitCount++;
                    }
                }
            }
            Console.WriteLine(digitCount);
        }
    }
}
