namespace GuessANumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random generator = new Random();
            int randomNumber = generator.Next(1, 101); // Correct range

            int guess;
            string input;

            int attempts = 0;
            bool success = false;

            Console.WriteLine("Welcome to the 'Guess a Number' Game!");
            Console.WriteLine();
            Console.WriteLine("You have to guess an integer between 1 and 100.");
            Console.WriteLine("You have 5 attempts, good luck.");

            while (attempts < 5)
            {
                Console.Write($"This is attempt {attempts + 1}, What is your guess? ");
                input = Console.ReadLine();

                if (!int.TryParse(input, out guess))
                {
                    Console.WriteLine("Invalid guess, please enter an integer.");
                    continue;
                }

                if (guess < 1 || guess > 100)
                {
                    Console.WriteLine("Invalid input, please make sure your guess is between 1 and 100.");
                    continue;
                }

                attempts++;

                if (guess == randomNumber)
                {
                    Console.WriteLine($"You win at attempt {attempts}! The number is {randomNumber}.");
                    success = true;
                    break;
                }
                else if (guess < randomNumber)
                {
                    Console.WriteLine("Too small.");
                }
                else
                {
                    Console.WriteLine("Too big.");
                }

                Console.WriteLine($"You have {5 - attempts} attempt(s) left.");
            }

            if (!success)
            {
                Console.WriteLine($"You lost, the correct number is {randomNumber}.");
            }
        }
    }
}