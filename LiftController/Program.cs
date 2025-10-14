namespace LiftController
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] floorNames = new string[5];
            floorNames[0] = "Ground";
            floorNames[1] = "First";
            floorNames[2] = "Second";
            floorNames[3] = "Third";
            floorNames[4] = "Fourth";

            Console.WriteLine();
            Console.WriteLine("The available floors are: ");
            for (int i = 0; i < floorNames.Length; ++i)
            {
                Console.WriteLine($"{i}  {floorNames[i]}");
            }

            Console.WriteLine();
            int pickedFloor;
            while (true)
            {
                Console.Write("Choose a floor number: ");
                string? input = Console.ReadLine();

                if (int.TryParse(input, out pickedFloor) && pickedFloor >= 0 && pickedFloor <= 4)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input, please enter an integer between 0 and 4.");
                }
            }

            Console.WriteLine($"You have chosen the {floorNames[pickedFloor]} Floor.");
            Console.WriteLine();
        }
    }
}
