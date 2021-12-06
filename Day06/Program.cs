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
            //string[] parseData = lines[0].Split(",");
            //foreach (var initialFish in parseData)
            //{
            //    school.Add(Int32.Parse(initialFish));
            //}
            while (days <= 256)
            {
                int fishToSpawn = 0;
                for (int i=0; i < school.Count; i++)
                {
                    if (school[i] == 0)
                    {
                        school[i] = 6;
                        fishToSpawn++;
                    } else {
                        school[i]--;
                    }
                }
                for (int i=0; i < fishToSpawn; i++)
                {
                    school.Add(8);
                }
                //Console.WriteLine("After Day "+days+":");
                //printSchool(school);
                days++;

            }
            Console.Write("After " + (days - 1) + " days the anglerfish count is: " + school.Count);
        }

        static void printSchool(List<int> school)
        {
            school.ForEach(fish => Console.Write(fish + " "));
            Console.WriteLine();
        }
    }

}
