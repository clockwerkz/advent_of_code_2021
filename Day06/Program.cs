using System;
using System.Collections.Generic;
using System.IO;

namespace Day06
{
    class Program
    {
        static void Main(string[] args)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            Console.WriteLine("---DAY 5: PART 1---");
            string currentFile = projectDirectory + "\\Day6Input.txt";
            string[] lines = File.ReadAllLines(currentFile);
            int days = 1;
            List<int> school = new List<int> { 3, 4, 3, 1, 2};
            school.Clear();
            string[] parseData = lines[0].Split(",");
            foreach (var initialFish in parseData)
            {
                school.Add(Int32.Parse(initialFish));
            }
            
            long[] fishCount = new long[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            foreach (int fish in school)
            {
                fishCount[fish]++;
            }
            while (days <= 256)
            {
                long zeroCount = fishCount[0];
                for (int i=0; i < fishCount.Length-1; i++)
                {
                    fishCount[i] = fishCount[i + 1];
                }
                //Console.WriteLine("After Day "+days+":");
                //printSchool(school);
                days++;
                fishCount[6] += zeroCount;
                fishCount[8] = zeroCount;
            }
            printSchool(fishCount);
            Console.Write("After " + (days - 1) + " days the anglerfish count is: " + totalFishCount(fishCount));
        }

        static void printSchool(long[] fishCount)
        {
            for (int i=0; i < fishCount.Length; i++)
            {
                Console.WriteLine("total fish in position " + i + ": " + fishCount[i]);
            }
        }

        static long totalFishCount(long[] fishCount)
        {
            long sum = 0;
            for (int i=0; i < fishCount.Length; i++)
            {
                sum += fishCount[i];
            }
            return sum;
        }
    }

}
