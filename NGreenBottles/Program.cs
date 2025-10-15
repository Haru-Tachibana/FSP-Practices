using System;

public class GreenBottles
{
    static string bottlesText(int count)
    {
        return count == 1 || count == 0 ? "bottle" : "bottles";
    }
    public static void Main()
    {
        Console.WriteLine();
        Console.Write("How many green bottles you want to hang on the wall? ");
        string input = Console.ReadLine() ?? string.Empty;

        // check input
        if (!int.TryParse(input, out int bottles))
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            return;
        }

        for (int i = bottles; i > 0; i--)
        {
            Console.WriteLine(i + " green " + bottlesText(i) + " sitting on the wall,");
            Console.WriteLine(i + " green " + bottlesText(i) + " sitting on the wall,");
            Console.WriteLine("and if one green bottle should accidentally fall,");

            if (i - 1 == 0)
            {
                Console.WriteLine("there will be no green bottle sitting on the wall");
            }
            else
            {
                Console.WriteLine("there will be " + (i - 1) + " green " + bottlesText(i - 1) + " sitting on the wall");
            }  
        }

    }
}