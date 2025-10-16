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
            //int[] scheduledHours = { 08, 09, 11, 13, 15, 18, 21, 23 };
            //int[] scheduledMinutes = { 05, 45, 23, 01, 27, 05, 48, 55 };
            //int[] lateMinutes = { 8, 0, 37, 6, 0, 0, 20, 9 };

            int[,] time = { {08,05,8},
                {09,45,0},
                {11,23,37},
                {13,01,6},
                {15,27,0},
                {18,05,0},
                {21,48,20},
                {23,55,9}
            };

            Console.WriteLine("Destination   Scheduled    Status     Expected");

            for (int i = 0; i < stationCodes.Length; ++i)
            {
                int hours = time[i, 0];
                int mins = time[i, 1];
                int late = time[i, 2];
                
                Console.Write("    ");
                Console.Write(stationCodes[i]);
                Console.Write("         ");
                writeTime(hours, mins);

                Console.Write("      ");
                if (late != 0)
                {
                    Console.Write("Delayed");
                }
                else
                {
                    Console.Write("On Time");
                }

                Console.Write("      ");
                if (late != 0)
                {
                    writeTime(hours, mins + late);
                }
                else
                {
                    Console.Write("");
                }

                Console.WriteLine();
            }
        }
    }
}
