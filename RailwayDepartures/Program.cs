namespace RailwayDepartures
{
    internal class Program
    {
        static void writeTime(int hours, int mins)
        {
            while (mins >= 60)
            {
                mins -= 60;
                hours++;
            }

            if (hours >= 24)
            {
                hours -= 24;
            }
            Console.Write(string.Format("{0:00}:{1:00}", hours, mins));
        }
        static void Main()
        {
            string[] stationCodes = { "LON", "NOT", "BHM", "MAN", "CDF", "EDB", "GLC", "LDS" };
            int[] scheduledHours = { 08, 09, 11, 13, 15, 18, 21, 23 };
            int[] scheduledMinutes = { 05, 45, 23, 01, 27, 05, 48, 55 };
            int[] lateMinutes = { 8, 0, 37, 6, 0, 0, 20, 9 };

            Console.WriteLine("Destination   Scheduled   Expected");

            for (int i = 0; i < stationCodes.Length; ++i)
            {
                int hours = scheduledHours[i];
                int mins = scheduledMinutes[i];
                int late = lateMinutes[i];
                
                Console.Write("    ");
                Console.Write(stationCodes[i]);
                Console.Write("         ");
                writeTime(hours, mins);
                Console.Write("      ");
                writeTime(hours, mins + late);
                Console.WriteLine();
            }
        }
    }
}
