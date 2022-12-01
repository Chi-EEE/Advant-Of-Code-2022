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
            IEnumerable<int> topThreeCalories =
                calorieList.OrderByDescending(calorie => calorie).Take(3);
            Console.WriteLine(topThreeCalories.Sum());
        }
    }
}
