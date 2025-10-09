using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ComputerGuesser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the 'Guess a Number' Game.");
            Console.WriteLine("You have to pick a number between 1 and 100, and I will try to guess it.");
            Console.WriteLine("For each guess, you should answer \"low\", \"high\" or \"correct\".");
            Console.WriteLine();
            Console.WriteLine("Press any key when you are ready to begin.");
            Console.ReadKey();
            Console.WriteLine();

            int min = 1;
            int max = 100;
            int guess;
            string response;

            while (true)
            {
                guess = (min + max) / 2;
                Console.WriteLine($"My guess is {guess}. Am I right?");
                response = Console.ReadLine()?.Trim().ToLower();

                while (response != "low" && response != "high" && response != "correct")
                {
                    Console.WriteLine("I'm sorry, I don't understand.  Please answer \"low\", \"high\" or \"correct\".");
                    Console.WriteLine($"My guess is {guess}. Am I right?");
                    response = Console.ReadLine()?.Trim().ToLower();
                }

                if (response == "correct")
                {
                    Console.WriteLine("\nHaha, I am good at this.");
                    break;
                }
                else if (response == "high")
                {
                    max = guess - 1;
                }
                else if (response == "low")
                {
                    min = guess + 1;
                }

                if (min > max)
                {
                    Console.WriteLine("\nYou rotter, you lied to me.");
                    break;
                }


            }
        }
    }
}
