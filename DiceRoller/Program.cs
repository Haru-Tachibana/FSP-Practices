using System.Runtime.InteropServices.Marshalling;

namespace DiceRoller
{
    internal class Program
    {
        static Random generator = new Random();

        static int rollDie()
        {
            return generator.Next(1, 7);
        }
        static void Main(string[] args)
        {
            Console.Write("Please enter how many dice you want to roll: ");
            string? input = Console.ReadLine();
            int diceNum;
            int diceSum = 0;
            bool repeat = false;

            do
            {
                while (!int.TryParse(input, out diceNum) || diceNum <= 0)
                {
                    Console.WriteLine("Invalid input, please enter an integer greater than 0.");
                    Console.Write("Please enter how many dice you want to roll: ");
                    input = Console.ReadLine();
                }

                for (int i = 0; i < diceNum; ++i)
                {
                    diceSum = diceSum + rollDie();
                }

                Console.WriteLine($"{diceNum} dice rolled: {diceSum}");
                Console.WriteLine();
                Console.WriteLine("\nWould you like to roll again?\nEnter y/n.");
                string ans = Console.ReadLine().ToLower();

                if (ans == "y")
                {
                    repeat = true;
                }
                else
                {
                    repeat = false;
                    break;
                }    
            } while (repeat = true);
        }
    }
}
