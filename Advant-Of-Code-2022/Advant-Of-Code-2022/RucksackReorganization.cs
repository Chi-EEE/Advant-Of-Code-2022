using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advant_Of_Code_2022
{
    internal class RucksackReorganization
    {
        private static int GetScore(char item)
        {
            if (Char.IsLower(item))
            {
                return item - 'a' + 1;
            }
            return item - 'A' + 27;
        }
        public static void Part1()
        {
            StreamReader reader = File.OpenText("Inputs/Day3.txt");
            string line;
            int score = 0;
            Dictionary<char, bool> commonItem = new();
            while ((line = reader.ReadLine()) != null)
            {
                for (int i = 0; i < line.Length / 2; i++)
                {
                    commonItem[line[i]] = true;
                }
                for (int i = line.Length / 2; i < line.Length; i++)
                {
                    if (commonItem.ContainsKey(line[i]) && commonItem[line[i]])
                    {
                        score += GetScore(line[i]);
                        break;
                    }
                }
                commonItem.Clear();
            }
            Console.WriteLine(score);
        }
        public static void Part2()
        {
            StreamReader reader = File.OpenText("Inputs/Day3.txt");
            string line;
            int group = 0;
            int score = 0;
            Dictionary<char, int> commonBadge = new();
            while ((line = reader.ReadLine()) != null)
            {
                if (group == 3)
                {
                    group = 0;
                    commonBadge.Clear();
                }
                for (int i = 0; i < line.Length; i++)
                {
                    char item = line[i];
                    if (commonBadge.TryGetValue(item, out int count))
                    {
                        if (count == group - 1)
                        {
                            count = group;
                            commonBadge[item] = count;
                            if (count == 2)
                            {
                                score += GetScore(item);
                                break;
                            }
                        }
                    }
                    else if (group == 0)
                    {
                        commonBadge[item] = 0;
                    }
                }
                group++;
            }
            Console.WriteLine(score);
        }
    }
}
