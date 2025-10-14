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

            // practice that indexing displays from 1
            string[] months = new string[]
            {
                "January", "February", "March", "April", "May", "June",
                "July", "August", "September", "October", "November", "December"
            };

            Console.WriteLine("The months are: ");
            for (int i = 0; i < months.Length; ++i)
            {
                Console.WriteLine($"{i + 1} - {months[i]}");
            }
            Console.WriteLine();

            int pickedMonth;
            while (true)
            {
                Console.Write("Choose a month: ");
                string? inputMonth = Console.ReadLine();
                if (int.TryParse(inputMonth, out pickedMonth) && pickedMonth >= 1 && pickedMonth <= 12)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input, please enter an integer between 1 and 12.");
                }
            }
            Console.WriteLine($"You have chosen {months[pickedMonth - 1]}.");
            Console.WriteLine(); 
        }
    }
}
