using System;
using System.IO;

namespace Day03
{
    class Program
    {
        static void Main(string[] args)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string currentFile = projectDirectory + "\\Sample.txt";
            string[] lines = File.ReadAllLines(currentFile);

            Console.WriteLine("Test data should return 198");
            Console.WriteLine("Test Data: " + DayOnePowerConsumption(lines));

            currentFile = projectDirectory + "\\Input.txt";
            lines = File.ReadAllLines(currentFile);
            Console.WriteLine("Day 3 - Part 1 Answer: " + DayOnePowerConsumption(lines));
        }

        static int DayOnePowerConsumption(string[] lines)
        {
            int[] Zeroes = new int[lines[0].Length];
   
            for (int i=0; i < Zeroes.Length; i++)
            {
                Zeroes[i] = 0;
            }
            foreach(string line in lines)
            {
                int i = 0;
                foreach(char bit in line)
                {
                    if (bit == '0')
                    {
                        Zeroes[i]++;
                    }
                    i++;
                }
            }
            string  gamma = "";
            string epsilon = "";
            for (int i=0; i < Zeroes.Length; i++)
            {
                if (Zeroes[i] > (lines.Length / 2))
                {
                    gamma += "0";
                    epsilon += "1";
                } else
                {
                    gamma += "1";
                    epsilon += "0";
                }
            }
            return Convert.ToInt32(gamma, 2) * Convert.ToInt32(epsilon, 2);
        }
    }

}
