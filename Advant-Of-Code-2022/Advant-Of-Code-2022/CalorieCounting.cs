using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advant_Of_Code_2022
{
    internal class CalorieCounting
    {
        public static void run()
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
                } else
                {
                    total += int.Parse(line);
                }
            }
            Console.WriteLine(calorieList.Max());
        }
    }
}
