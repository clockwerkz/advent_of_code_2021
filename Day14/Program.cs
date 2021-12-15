using System;
using System.IO;

namespace Day14
{
    class Program
    {
        static void Main(string[] args)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string currentFile = projectDirectory + "\\Sample.txt";
            //string[] lines = File.ReadAllLines(currentFile);
            Console.WriteLine("---DAY 14: PART 1---");
            string test = "NNCB";
            string[] rules = new string[] { "NN->B", "CB->N", "CN->B" };
            string output = test;
            int itr = 1;
            foreach(string ruleset in rules)
            {
                Console.WriteLine("Ruleset iteration" + itr++ + ": " + ruleset);
                string[] ruleBreakdown = ruleset.Split("->", StringSplitOptions.RemoveEmptyEntries);
                string rule = ruleBreakdown[0];
                string val = ruleBreakdown[1];
                int ptr = 0;
                int i = 0;
                foreach(char ltr in test)
                {
                    if (rule[ptr] == ltr)
                    {
                        if (ptr == 1)
                        {
                            output = output.Substring(0, i) + val + output.Substring(i); 
                            ptr = 0;
                        } else
                        {
                            ptr++;
                        }
                    } else
                    {
                        ptr = 0;
                    }
                }
            }
            Console.WriteLine("Original: " + test);
            Console.WriteLine("Output: " + output);
        }
    }
}
