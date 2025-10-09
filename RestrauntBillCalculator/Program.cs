namespace RestaurantBillCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starter price?");
            decimal starter = Decimal.Parse(Console.ReadLine());

            Console.WriteLine("Main Course price?");
            decimal main_course = Decimal.Parse(Console.ReadLine());

            Console.WriteLine("Dessert price?");
            decimal dessert = Decimal.Parse(Console.ReadLine());

            Console.WriteLine("Drinks price?");
            decimal drinks = Decimal.Parse(Console.ReadLine());

            Console.WriteLine("How many people?");
            int ppl = int.Parse(Console.ReadLine());

            decimal total = starter + main_course + dessert + drinks;
            decimal totalWithTip10 = total * 1.1m;
            decimal totalWithTip20 = total * 1.2m;
            decimal perPerson10 = totalWithTip10 / ppl;
            decimal perPerson20 = totalWithTip20 / ppl;

            Console.WriteLine($"\nTotal bill (with 10% tip): £{totalWithTip10:F2}");
            Console.WriteLine($"\nTotal bill (with 20% tip): £{totalWithTip20:F2}");
            Console.WriteLine($"Each person owes: £{perPerson10:F2}");
            Console.WriteLine($"Each person owes: £{perPerson20:F2}");
        }
    }
}