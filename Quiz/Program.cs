using System;

class Program
{
    static void Main()
    {
        int score = 0;

        Console.WriteLine("1. What is the capital of France?");
        Console.WriteLine("A) Berlin\nB) Madrid\nC) Paris\nD) Rome");
        Console.Write("Your answer: ");
        string? answer1 = Console.ReadLine()?.ToUpper();

        if (answer1 == "C")
        {
            Console.WriteLine("Correct!\n");
            score++;
        }
        else
        {
            Console.WriteLine("Incorrect.\n");
        }

        Console.WriteLine("2. Which planet is known as the Red Planet?");
        Console.WriteLine("A) Earth\nB) Mars\nC) Jupiter\nD) Venus");
        Console.Write("Your answer: ");
        string? answer2 = Console.ReadLine()?.ToUpper();

        if (answer2 == "B")
        {
            Console.WriteLine("Correct!\n");
            score++;
        }
        else
        {
            Console.WriteLine("Incorrect.\n");
        }

        Console.WriteLine("3. Who wrote 'Romeo and Juliet'?");
        Console.WriteLine("A) Charles Dickens\nB) William Shakespeare\nC) Mark Twain\nD) Jane Austen");
        Console.Write("Your answer: ");
        string? answer3 = Console.ReadLine()?.ToUpper();

        if (answer3 == "B")
        {
            Console.WriteLine("Correct!\n");
            score++;
        }
        else
        {
            Console.WriteLine("Incorrect.\n");
        }

        Console.WriteLine($"You answered {score} out of 3 questions correctly.");
    }
}
