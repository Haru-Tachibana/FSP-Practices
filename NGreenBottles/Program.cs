using System;

public class GreenBottles
{
    public static void Main()
    {
        Console.Write("How many green bottles you want to hang on the wall? ");
        int bottles = int.Parse(Console.ReadLine());

        for (int i = bottles; i > 0; i--)
        {
            Console.WriteLine($"{i} green bottles sitting on the wall,");
            Console.WriteLine($"{i} green bottles sitting on the wall,");
            Console.WriteLine("and if one green bottle should accidentally fall,");
            Console.WriteLine($"there will be {i - 1} green bottles sitting on the wall.");       
        }

    }
}