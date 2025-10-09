using System;

public class Cinema
{
    public static void Main()
    {
        int[] filmNum = { 1, 2, 3 };
        string enteredNum;

        Console.WriteLine("Hi, welcome to NTU Cinema!");
        Console.WriteLine();

        Console.Write("Please enter your age:");
        string ageStr = Console.ReadLine();
        int age = int.Parse(ageStr);
        Console.WriteLine();

        Console.WriteLine("Currently showing:\n1. The Imitation Game (12)\n2. Ada (13)\n3. Steve Jobs (15)");
        Console.WriteLine();

        Console.Write("Please enter the film number you would like to see: ");
        int filmChoice = int.Parse(enteredNum = Console.ReadLine());
        bool inTheList = filmNum.Contains(filmChoice);

        while (inTheList == false)
        {
            Console.Write("Entered number is not listed, please try again: ");
            filmChoice = int.Parse(enteredNum = Console.ReadLine());
            inTheList = filmNum.Contains(filmChoice);
        }
        Console.WriteLine($"Selection recorded, you are going to watch movie {filmChoice}.");
        Console.WriteLine("Enjoy your movie!\nPress any key to exit.");
        Console.ReadKey();
    }
}