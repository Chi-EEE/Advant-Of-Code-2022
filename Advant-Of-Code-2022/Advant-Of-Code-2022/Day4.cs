using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advant_Of_Code_2022
{
    internal class Day4
    {
        public static void Part1()
        {
            StreamReader reader = File.OpenText("Inputs/Day4.txt");
            string line;
            int score = 0;
            while ((line = reader.ReadLine()) != null)
            {
                string[] elves = line.Split(',');
                string e1 = elves[0], e2 = elves[1];
                string[] ns1 = e1.Split('-');
                string[] ns2 = e2.Split('-');
                int re11 = int.Parse(ns1[0]), re12 = int.Parse(ns1[1]);
                int re21 = int.Parse(ns2[0]), re22 = int.Parse(ns2[1]);
                if (re21 >= re11 && re22 <= re12 || re11 >= re21 && re12 <= re22)
                {
                    score++;
                }
            }
            Console.WriteLine(score);
        }
        public static void Part2()
        {
            StreamReader reader = File.OpenText("Inputs/Day4.txt");
            string line;
            while ((line = reader.ReadLine()) != null)
            {

            }
        }
    }
}
