using System.Runtime.CompilerServices;

namespace Advant_Of_Code_2022
{
    internal class Program
    {
        private static readonly Dictionary<string, Delegate[]> DayToFunction =
            new()
            {
                { "Day1", new Delegate[]
                    {
                        CalorieCounting.Part1,
                        CalorieCounting.Part2
                    }
                },
                { "Day2", new Delegate[]
                    {
                        RockPaperScissors.Part1,
                        RockPaperScissors.Part2
                    }
                },
                { "Day3", new Delegate[]
                    {
                        RucksackReorganization.Part1,
                        RucksackReorganization.Part2
                    }
                },
                { "Day4", new Delegate[]
                    {
                        Day4.Part1,
                        Day4.Part2
                    }
                },
                { "Day5", new Delegate[]
                    {
                        Day5.Part1,
                        Day5.Part2
                    }
                },
                { "Day6", new Delegate[]
                    {
                        Day6.Part1,
                        Day6.Part2
                    }
                }
            };
        static void WaitForKey()
        {
            Console.Write("\nPlease enter a key...");
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Which day do you want to access?");
                Console.WriteLine("There are " + DayToFunction.Count + " days in this Calendar.");
                string? dayString = Console.ReadLine();
                if (dayString == null)
                {
                    Console.Clear();
                    continue;
                }
                try
                {
                    int day = int.Parse(dayString) - 1;
                    var result = DayToFunction.ElementAt(day);
                    while (true)
                    {
                        Console.WriteLine("=====================================\nYou are selecting " + result.Key + ".");
                        Console.WriteLine("There are " + result.Value.Length + " parts for this day.");
                        Console.Write("Select between the parts >");
                        string? partString = Console.ReadLine();
                        try
                        {
                            if (partString == null)
                            {
                                Console.Clear();
                                continue;
                            }
                            int part = int.Parse(partString) - 1;
                            result.Value[part].DynamicInvoke();
                            WaitForKey();
                            Console.Clear();
                            break;
                        }
                        catch (Exception _)
                        {
                            Console.WriteLine("Unable to get the part " + partString);
                            WaitForKey();
                            Console.Clear();
                        }
                    }
                }
                catch (Exception _)
                {
                    Console.WriteLine("Unable to get the day " + dayString);
                    WaitForKey();
                    Console.Clear();
                }
            }
        }
    }
}