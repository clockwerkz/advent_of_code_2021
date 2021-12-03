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

            string[] lines = File.ReadAllLines(projectDirectory + "\\Sample.txt");

            Console.WriteLine("Test data should return 198");
            Console.WriteLine("Test Data: " + DayOnePowerConsumption(lines));
        }

        static int DayOnePowerConsumption(string[] lines)
        {
            int[] Zeroes = new int[lines[0].Length];
            int[] Ones = new int[lines[0].Length];
            for (int i=0; i < Zeroes.Length; i++)
            {
                Zeroes[i] = 0;
                Ones[i] = 0;
            }
            foreach(string line in lines)
            {
                int i = 0;
                foreach(char bit in line)
                {
                    if (bit == '0')
                    {
                        Zeroes[i]++;
                    } else
                    {
                        Ones[i]++;
                    }
                    i++;
                }
            }
            Console.WriteLine(Zeroes);
            return 0;
        }
    }

}
