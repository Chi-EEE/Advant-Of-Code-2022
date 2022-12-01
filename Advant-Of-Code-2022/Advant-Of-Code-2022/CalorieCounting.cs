using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Advant_Of_Code_2022
{
    internal class CalorieCounting
    {
        private static List<int> GetCalorieList()
        {
            StreamReader reader = File.OpenText("Inputs/Day1.txt");
            string line;
            int total = 0;
            List<int> calorieList = new();
            while ((line = reader.ReadLine()) != null)
            {
                if (line == "")
                {
                    calorieList.Add(total);
                    total = 0;
                }
                else
                {
                    total += int.Parse(line);
                }
            }
            return calorieList;
        }

        public static void Part1()
        {
            List<int> calorieList = GetCalorieList();
            Console.WriteLine(calorieList.Max());
        }

        public static void Part2()
        {
            List<int> calorieList = GetCalorieList();
            const int topSize = 3;
            int[] top = new int[topSize];
            for (int i = 0; i < calorieList.Count; i++)
            {
                for (int topIndex = 0; topIndex < topSize; topIndex++)
                {
                    if (calorieList[i] > top[topIndex])
                    {
                        for (int innerTopIndex = topIndex + 1; innerTopIndex < topSize; innerTopIndex++)
                        {
                            top[innerTopIndex] = top[innerTopIndex - 1];
                        }
                        top[topIndex] = calorieList[i];
                        break;
                    }
                }
            }
            int total = 0;
            for (int i = 0; i< top.Length; i++)
            {
                total += top[i];
            }
            Console.WriteLine(total);
        }
    }
}
