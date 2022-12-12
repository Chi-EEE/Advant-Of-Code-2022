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
    internal class Day6
    {
        public static void Part1()
        {
            StreamReader reader = File.OpenText("Inputs/Day5.txt");
            Dictionary<char, bool> duplicateCharacters = new();
            int index = 0;
            char[] character = new char[1];
            while (reader.Read(character, index, 1) != null)
            {
                if (duplicateCharacters.ContainsKey(character[0])) duplicateCharacters.Remove(duplicateCharacters.Keys.First()); if (duplicateCharacters.Count == 4) { Console.Write(index); break;}
                duplicateCharacters.Add(character[0], true);
                index++;
            }
        }
        public static void Part2()
        {
        }
    }
}
