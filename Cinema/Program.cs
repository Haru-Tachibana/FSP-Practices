using System;

public class Cinema
{
    public static void Main()
    {
        Console.WriteLine("Hi, welcome to NTU Cinema!");
        Console.WriteLine();

        Console.WriteLine("Please enter your age:");
        string ageStr = Console.ReadLine();
        int age = int.Parse(ageStr);
        Console.WriteLine();

        Console.WriteLine("Currently showing:\n1. The Imitation Game (12)\n2. Ada (13)\n3. Steve Jobs (15)");
        Console.WriteLine();

        Console.WriteLine("Please enter the film you would like to see:");
        Console.ReadLine();
        Console.WriteLine();

        Console.WriteLine("Enjoy your movie!\nPress any key to exit.");
        Console.ReadKey();
    }
}