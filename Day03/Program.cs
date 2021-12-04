using System;
using System.Collections.Generic;
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
            Console.WriteLine("Test Data: " + DayThreePowerConsumption(lines));

            currentFile = projectDirectory + "\\Input.txt";
            lines = File.ReadAllLines(currentFile);
            Console.WriteLine("Day 3 - Part 1 Answer: " + DayThreePowerConsumption(lines));
            Console.WriteLine("--------\nDay 3 - Part 2");
            currentFile = projectDirectory + "\\Sample.txt";
            lines = File.ReadAllLines(currentFile);
            Console.WriteLine("Life Support rating on sample data should be 230: " + DayThreeLifeSupportRating(lines));
            currentFile = projectDirectory + "\\Input.txt";
            lines = File.ReadAllLines(currentFile);
            // first attempt guess: 1024672 is too low
            Console.WriteLine("Life Support rating on test data: " + DayThreeLifeSupportRating(lines));
        }

        static int[] CountZeroes(string[] lines)
        {
            int[] Zeroes = new int[lines[0].Length];

            for (int i = 0; i < Zeroes.Length; i++)
            {
                Zeroes[i] = 0;
            }
            foreach (string line in lines)
            {
                int i = 0;
                foreach (char bit in line)
                {
                    if (bit == '0')
                    {
                        Zeroes[i]++;
                    }
                    i++;
                }
            }
            return Zeroes;
        }

        static int[] CountZeroesList(List<string> lines)
        {
            if (lines.Count == 0) {
                return new int[0];
            }
            int[] Zeroes = new int[lines[0].Length];

            for (int i = 0; i < Zeroes.Length; i++)
            {
                Zeroes[i] = 0;
            }
            foreach (string line in lines)
            {
                int i = 0;
                foreach (char bit in line)
                {
                    if (bit == '0')
                    {
                        Zeroes[i]++;
                    }
                    i++;
                }
            }
            return Zeroes;
        }



        static int DayThreeLifeSupportRating(string[] lines)
        {
            int[] zeroes = CountZeroes(lines);
            int ptr = 0;
            int oxygenGeneratorRating=0;
            int CO2ScrubberRaing = 0;
            var possibleChoices = new List<string>(lines);
            while (ptr < lines[0].Length)
            {
                char mostCommon = zeroes[ptr] > (possibleChoices.Count / 2)  ? '0' : '1';
                foreach (string choice in possibleChoices)
                possibleChoices = possibleChoices.FindAll(l => l[ptr] == mostCommon);
                zeroes = CountZeroesList(possibleChoices);
                ptr += 1;
                if (possibleChoices.Count == 1)
                {
                    oxygenGeneratorRating = Convert.ToInt32(possibleChoices[0], 2);
                    break;
                }
            }
            //reset lines back to original set of data to calculate CO2 Scrubber Rating
            possibleChoices = new List<string>(lines);
            zeroes = CountZeroes(lines);
            ptr = 0;
            while (ptr < lines[0].Length)
            {
                char leastCommon = zeroes[ptr] <= (possibleChoices.Count / 2) ? '0' : '1';
                List<string> temp = possibleChoices.FindAll(l => l[ptr] == leastCommon);
                if (temp.Count > 0)
                {
                    possibleChoices = temp;
                }
                zeroes = CountZeroesList(possibleChoices);
                if (possibleChoices.Count == 1)
                {
                    Console.WriteLine("last option: " + possibleChoices[0]);
                    CO2ScrubberRaing = Convert.ToInt32(possibleChoices[0], 2);
                    break;
                }
                ptr += 1;
            }
            Console.WriteLine("o2 rating: " + oxygenGeneratorRating + ", CO2 rating: " + CO2ScrubberRaing);
            return oxygenGeneratorRating * CO2ScrubberRaing;
        }

        static int DayThreePowerConsumption(string[] lines)
        {
            int[] Zeroes = CountZeroes(lines);
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
