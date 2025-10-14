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

            Console.WriteLine("The available floors are: ");
            for (int i = 0; i <= floorNames.Length; i++)
            {
                Console.WriteLine($"{i + 1}  {floorNames[i]}");
            }
        }
    }
}
