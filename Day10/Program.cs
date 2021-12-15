using System;
using System.Collections.Generic;
using System.IO;

namespace Day10
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, char> pairCheck = new Dictionary<char, char> {
                { '}','{'},
                { ')', '('},
                { '>', '<'},
                { ']', '['}
            };

            Dictionary<char, int> pairScore = new Dictionary<char, int> {
                { '}', 1197},
                { ')', 3},
                { '>', 25137},
                { ']', 57}
            };
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            Console.WriteLine("---DAY 10: PART 1---");
            string currentFile = projectDirectory + "\\Day10Input.txt";
            string[] lines = File.ReadAllLines(currentFile);
            int corruptedCount = 0;
            int score = 0;
            Stack<char> current = new Stack<char>();
            foreach(string line in lines)
            {
                bool isValid = true;
                foreach (char c in line)
                {
                    if (isValid && pairCheck.ContainsKey(c))
                    {
                        if (current.Count ==0 || (current.Peek() != pairCheck[c]))
                        {
                            isValid = false;
                            corruptedCount++;
                            score += pairScore[c];
                        } else
                        {
                            if (current.Count > 0) current.Pop();
                        }
                    } else
                    {
                        current.Push(c);
                    }
                }
            }
            //Console.WriteLine("Count should be 5: " + corruptedCount  + " and score should be 26397: " + score);
            Console.WriteLine("Day 10 Part 1 Score: " + score);

        }
    }
}
