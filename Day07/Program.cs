using System;
using System.Collections.Generic;
using System.IO;

namespace Day07
{
    class Program
    {
        static void Main(string[] args)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            Console.WriteLine("---DAY 7: PART 1---");
            string currentFile = projectDirectory + "\\Day7Input.txt";
            int maxX = 0;
            int maxY = 0;
            string[] lines = File.ReadAllLines(currentFile);
            List<int> CrabLocations = new List<int>();
            foreach(var entry in lines[0].Split(","))
            {
                CrabLocations.Add(int.Parse(entry));
            }
            int[] sampleSet = new int[] { 16, 1, 2, 0, 4, 2, 7, 1, 2, 14 };
            int max = -1;
            int min = int.MaxValue;
            foreach(int val in CrabLocations)
            {
                max = Math.Max(val, max);
            }
            for (int col = 0; col <= max; col++)
            {
                int sum = 0;
                foreach(int val in CrabLocations)
                {
                    sum += Math.Abs(val - col);
                }
                min = Math.Min(min, sum);
                sum = 0;
            };
            //Console.WriteLine("Minimum Moves required from test data should be 37: " + min);
            Console.WriteLine("Minimum Moves required from Day 7 Input data: " + min);
        }
    }
}
