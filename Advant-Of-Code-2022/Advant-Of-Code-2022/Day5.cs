using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advant_Of_Code_2022
{
    internal class Day5
    {
        static readonly
            Regex ACTION_REGEX = new Regex(@"move ([0-9]+) from ([0-9]+) to ([0-9]+)",
          RegexOptions.Compiled);
        public static void Part1()
        {
            StreamReader reader = File.OpenText("Inputs/Day5.txt");
            string line = reader.ReadLine();
            int amountOfCrates = (line.Length + 1) / 4;
            List<Stack<char>> crateStacks = new();
            for (int i = 0; i < amountOfCrates; i++)
            {
                crateStacks.Add(new());
            }
            {
                List<Stack<char>> reversedCrateStacks = new();
                for (int i = 0; i < amountOfCrates; i++)
                {
                    reversedCrateStacks.Add(new());
                }
                do
                {
                    if (line.Length == 0) // This is to separate the crates from the actions
                    {
                        break;
                    }
                    for (int i = 0; i < amountOfCrates; i++)
                    {
                        bool isValue = char.Parse(line.Substring(i + i * 3, 1)) == '[';
                        if (isValue)
                        {
                            reversedCrateStacks[i].Push(char.Parse(line.Substring(1 + i + i * 3, 1)));
                        }
                    }
                }
                while ((line = reader.ReadLine()) != null);
                for (int i = 0; i < amountOfCrates; i++)
                {
                    while (reversedCrateStacks[i].Count > 0)
                    {
                        crateStacks[i].Push(reversedCrateStacks[i].Pop());
                    }
                }
            }
            while ((line = reader.ReadLine()) != null)
            {
                Match action = ACTION_REGEX.Match(line);
                if (action.Success)
                {
                    GroupCollection actionGroup = action.Groups;
                    int amountToMove = int.Parse(actionGroup[1].Value);
                    int fromIndex = int.Parse(actionGroup[2].Value) - 1;
                    int toIndex = int.Parse(actionGroup[3].Value) - 1;
                    for (int i = 0; i < amountToMove; i++)
                    {
                        if (crateStacks[fromIndex].TryPop(out char result))
                        {
                            crateStacks[toIndex].Push(result);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            for (int i = 0; i < amountOfCrates; i++)
            {
                Console.Write(crateStacks[i].Peek());
            }
        }
        public static void Part2()
        {
            StreamReader reader = File.OpenText("Inputs/Day5.txt");
            string line = reader.ReadLine();
            int amountOfCrates = (line.Length + 1) / 4;
            List<List<char>> crateStacks = new();
            for (int i = 0; i < amountOfCrates; i++)
            {
                crateStacks.Add(new());
            }
            {
                List<Stack<char>> reversedCrateStacks = new();
                for (int i = 0; i < amountOfCrates; i++)
                {
                    reversedCrateStacks.Add(new());
                }
                do
                {
                    if (line.Length == 0) // This is to separate the crates from the actions
                    {
                        break;
                    }
                    for (int i = 0; i < amountOfCrates; i++)
                    {
                        bool isValue = char.Parse(line.Substring(i + i * 3, 1)) == '[';
                        if (isValue)
                        {
                            reversedCrateStacks[i].Push(char.Parse(line.Substring(1 + i + i * 3, 1)));
                        }
                    }
                }
                while ((line = reader.ReadLine()) != null);
                for (int i = 0; i < amountOfCrates; i++)
                {
                    while (reversedCrateStacks[i].Count > 0)
                    {
                        crateStacks[i].Add(reversedCrateStacks[i].Pop());
                    }
                }
            }
            while ((line = reader.ReadLine()) != null)
            {
                Match action = ACTION_REGEX.Match(line);
                if (action.Success)
                {
                    GroupCollection actionGroup = action.Groups;
                    int amountToMove = int.Parse(actionGroup[1].Value);
                    int fromIndex = int.Parse(actionGroup[2].Value) - 1;
                    int toIndex = int.Parse(actionGroup[3].Value) - 1;
                    int startCrateIndex = Math.Max(0, crateStacks[fromIndex].Count - amountToMove);
                    int endCrateCount = amountToMove;
                    List<char> range = crateStacks[fromIndex].GetRange(startCrateIndex, endCrateCount);
                    crateStacks[fromIndex].RemoveRange(startCrateIndex, endCrateCount);
                    crateStacks[toIndex].AddRange(range);
                }
            }
            for (int i = 0; i < amountOfCrates; i++)
            {
                Console.Write(crateStacks[i][crateStacks[i].Count - 1]);
            }
        }
    }
}
