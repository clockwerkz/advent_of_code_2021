using System;
using System.Collections.Generic;
using System.IO;

namespace Day09
{
    class Program
    {
        static void Main(string[] args)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            Console.WriteLine("---DAY 9: PART 1---");
            string currentFile = projectDirectory + "\\Day9Input.txt";
            string[] lines = File.ReadAllLines(currentFile);
            List<int[]> data = new List<int[]>();
            foreach(string line in lines)
            {
           
                int[] row = new int[line.Length];
                int i = 0;
                foreach(char c in line)
                {
                    row[i++] = c - '0';
                }
                data.Add(row);
            }
            int riskLevel = 0;
            for (int i=0; i < data.Count; i++)
            {
                for (int j=0; j < data[i].Length; j++)
                {
                    bool lowestPoint = true;
                    if (j > 0)
                    {
                        if (data[i][j] >= data[i][j - 1])
                        {
                            lowestPoint = false;
                        }
                    }
                    if (j <= data[i].Length - 2)
                    {
                        if (data[i][j] >= data[i][j + 1])
                        {
                            lowestPoint = false;
                        }
                    }
                    if (i > 0)
                    {
                        if (data[i][j] >= data[i-1][j])
                        {
                            lowestPoint = false;
                        }
                    }
                    if (i <= data.Count - 2)
                    {
                        if (data[i][j] >= data[i+1][j])
                        {
                            lowestPoint = false;
                        }
                    }
                    if (lowestPoint)
                    {
                        riskLevel += 1 + data[i][j];
                    }
                }
            }
            Console.WriteLine("Risk Level: " + riskLevel);
        }
    }
}
