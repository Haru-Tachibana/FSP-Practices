using System;

namespace GuessAWord
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // word bank
            string[] wordList = { "elephant", "giraffe", "dolphin", "penguin", "monkey", "gorilla",
            "hippopotamus", "butterfly", "rabbit", "hamster", "parrot", "budgie", "octopus", "cheetah", "pufferfish"};

            Random random = new Random();
            string hiddenWord = wordList[random.Next(wordList.Length)];

            bool[] guessed = new bool[hiddenWord.Length];
            int maxAttempts = 10;
            int remainingGuesses = maxAttempts;

            Console.WriteLine();
            Console.WriteLine("Welcome to the 'GUESS AN ANIMAL' game!");
            Console.WriteLine();

            // Main loop
            while (remainingGuesses > 0)
            {
                // display the word
                for (int i = 0; i < hiddenWord.Length; ++i)
                {
                    if (guessed[i])
                    {
                        Console.Write(hiddenWord[i]);
                    }
                    else
                    {
                        Console.Write("_");
                    }
                }
                Console.WriteLine();

                // get user input
                Console.Write("Guess a letter: ");
                string input = Console.ReadLine();

                // validate input
                if (string.IsNullOrEmpty(input) || input.Length != 1 || !char.IsLetter(input[0]))
                {
                    Console.WriteLine("Invalid input. Please enter a single letter.");
                    continue;
                }

                char userGuess = char.ToLower(input[0]);

                // check if the letter was already guessed
                bool alreadyGuessed = false;
                for (int i = 0; i < hiddenWord.Length; ++i)
                {
                    if (hiddenWord[i] == userGuess && guessed[i])
                    {
                        alreadyGuessed = true;
                        break;
                    }
                }

                if (alreadyGuessed)
                {
                    Console.WriteLine($"You already guessed the letter '{userGuess}'. Try again.");
                    continue;
                }

                // check user guess
                bool correctGuess = false;
                for (int j = 0; j < hiddenWord.Length; ++j)
                {
                    if (hiddenWord[j] == userGuess && !guessed[j])
                    {
                        guessed[j] = true;
                        correctGuess = true;
                    }
                }

                if (!correctGuess)
                {
                    remainingGuesses--;
                    Console.WriteLine($"Incorrect guess, you have {remainingGuesses} guesses left.");
                }
                else
                {
                    Console.WriteLine("Correct!");
                }

                // check if all letters are guessed
                bool allGuessed = true;
                for (int k = 0; k < guessed.Length; ++k)
                {
                    if (!guessed[k])
                    {
                        allGuessed = false;
                        break;
                    }
                }

                if (allGuessed)
                {
                    Console.WriteLine($"Congratulations! You guessed the word \"{hiddenWord}\" in {maxAttempts - remainingGuesses} attempts.");
                    return;
                }
            }

            // Game over message
            Console.WriteLine($"You lost! The word was \"{hiddenWord}\".");
        }
    }
}