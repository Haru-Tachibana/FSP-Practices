using System;

namespace GuessAWord
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // word bank

            // 
            string[] easyWordList = {"cat", "dog", "hen", "cow", "bat", "rat", "bass"};
            string[] mediumWordList = {"monkey", "horse", "donkey", "rabbit", "hamster", "parrot", "octopus", "giraffe", "dolphin", "penguin", "gorilla"};
            string[] hardWordList = {"elephant", "hippopotamus", "butterfly", "budgie", "sturgeon", "cheetah", "pufferfish", "chameleon", "rhinoceros"};

            string[] selectedWordBank = null;
            int maxAttempts = 0;
            string difficulty = null;

            // select difficulty
            while (selectedWordBank == null)
            {
                Console.WriteLine();
                Console.WriteLine("Please select a difficulty: Easy / Medium / Hard.");
                Console.Write("Type your choice here: ");
                difficulty = Console.ReadLine()?.ToLower();

                switch (difficulty)
                {
                    case "easy":
                        selectedWordBank = easyWordList;
                        maxAttempts = 5;
                        break;
                    case "medium":
                        selectedWordBank = mediumWordList;
                        maxAttempts = 10;
                        break;
                    case "hard":
                        selectedWordBank = hardWordList;
                        maxAttempts = 15;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select Easy, Medium, or Hard.");
                        break;
                }
            }

            // select a random word from any word list
            Random random = new Random();
            string hiddenWord = selectedWordBank[random.Next(selectedWordBank.Length)];

            bool[] guessed = new bool[hiddenWord.Length];
            
            int remainingGuesses = maxAttempts;

            Console.WriteLine();
            Console.WriteLine("Welcome to the 'GUESS AN ANIMAL' game!");
            Console.WriteLine($"You've chosen the {difficulty} difficulty, good luck!");
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
                    Console.WriteLine($"Congratulations! You guessed the word \"{hiddenWord}\"!!");
                    return;
                }
            }

            // Game over message
            Console.WriteLine($"You lost! The word was \"{hiddenWord}\".");
        }
    }
}