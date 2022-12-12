using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advant_Of_Code_2022
{
    internal class Day5
    {
        public static void Part1()
        {
            StreamReader reader = File.OpenText("Inputs/Day5.txt");
            string line;
            List<Stack<char>> crateStacks = new();
            for (int i = 0; i < 9; i++)
            {
                crateStacks.Add(new());
            }
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Length == 0) // This is to separate the crates from the actions
                {
                    break;
                }
                for (int i = 0; i < 9; i++)
                {
                    bool isValue = char.Parse(line.Substring(i + i * 3, 1)) == '[';
                    if (isValue)
                    {
                        crateStacks[i].Push(char.Parse(line.Substring(1 + i + i * 3, 1)));
                    }
                }
            }
        }
        public static void Part2()
        { }
    }
}
