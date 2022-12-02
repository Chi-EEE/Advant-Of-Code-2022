using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advant_Of_Code_2022
{
    internal class RockPaperScissors
    {
        private static int mod(int left, int right)
        {
            return (left + right) % right;
        }
        public static void Part1()
        {
            StreamReader reader = File.OpenText("Inputs/Day2.txt");
            string line;
            int score = 0;
            /*
             * R = A = X = 1
             * P = B = Y = 2
             * S = C = Z = 3
             * Win = 6
             * Draw = 3
             * Lose = 0
             */
            while ((line = reader.ReadLine()) != null)
            {
                string[] choices = line.Split(' ');
                int opponentChoice = choices[0].ToCharArray()[0] - 'A', playerChoice = choices[1].ToCharArray()[0] - 'X';
                switch (playerChoice)
                {
                    case 0:
                        score += 1;
                        break;
                    case 1:
                        score += 2;
                        break;
                    case 2:
                        score += 3;
                        break;
                }
                if (mod(playerChoice + 1, 3) == opponentChoice)
                {
                    score += 0;
                }
                else if (playerChoice == opponentChoice)
                {
                    score += 3;
                }
                else if (mod(playerChoice - 1, 3) == opponentChoice)
                {
                    score += 6;
                }
            }
            Console.WriteLine(score);
        }
        public static void Part2()
        {
            StreamReader reader = File.OpenText("Inputs/Day2.txt");
            string line;
            int score = 0;
            /*
             * R = A = X = 1
             * P = B = Y = 2
             * S = C = Z = 3
             * Win = 6
             * Draw = 3
             * Lose = 0
             */
            while ((line = reader.ReadLine()) != null)
            {
                string[] choices = line.Split(' ');
                int opponentChoice = choices[0].ToCharArray()[0] - 'A', playerOutcome = choices[1].ToCharArray()[0] - 'X';
                switch (playerOutcome)
                {
                    case 0:
                        score += 0 + mod(opponentChoice - 1, 3) + 1;
                        break;
                    case 1:
                        score += 3 + opponentChoice + 1;
                        break;
                    case 2:
                        score += 6 + mod(opponentChoice + 1, 3) + 1;
                        break;
                }
            }
            Console.WriteLine(score);
        }
    }
}
