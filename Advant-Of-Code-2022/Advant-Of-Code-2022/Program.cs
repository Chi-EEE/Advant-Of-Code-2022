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
            }
        };
        static void Main(string[] args)
        {
            Console.WriteLine("Which day do you want to access?");
            while (true)
            {
                string? dayString = Console.ReadLine();
                if (dayString == null)
                {
                    continue;
                }
                try
                {
                    int day = int.Parse(dayString);
                    var result = DayToFunction.ElementAt(day - 1);
                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("Are you sure you want to select " + result.Key + "?");
                            string? partString = Console.ReadLine();
                            int part = int.Parse(partString);
                            result.Value[part].DynamicInvoke();
                            break;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Unable to get the part " + dayString);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unable to get the day " + dayString);
                }
            }
        }
    }
}