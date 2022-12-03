using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advant_Of_Code_2022
{
    internal class RucksackReorganization
    {
        public static void Main()
        {
            StreamReader reader = File.OpenText("Inputs/Day3.txt");
            string line;
            int score = 0;
            while ((line = reader.ReadLine()) != null)
            {
                Dictionary<char, int> commonItem = new();
                for (int i = 0; i < line.Length / 2; i++)
                {
                    char item = line[i];
                    if (commonItem.TryGetValue(item, out int count))
                    {
                        commonItem[item] = count + 1;
                    }
                    else
                    {
                        commonItem[item] = 1;
                    }
                }
                for (int i = line.Length / 2; i < line.Length; i++)
                {
                    char item = line[i];
                    if (commonItem.TryGetValue(item, out int count))
                    {
                        if (Char.IsLower(item))
                        {
                            score += item - 'a' + 1;
                        }
                        else
                        {
                            score += item - 'A' + 27;
                        }
                        break;
                    }
                }
            }
            Console.WriteLine(score);
        }
    }
}
