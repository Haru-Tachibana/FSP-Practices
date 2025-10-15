using System;
using System.Runtime.CompilerServices;
using System.Transactions;

//[Advanced Task] Bearing in mind the preceding advice regarding approaches to software development , develop a program that calculates NTU degree award classifications . Specifically, your program should first ask the user to enter their module results, and then inform the user of:
//whether they have passed the course;
//their weighted mean;
//their majority grade;
//and, if they have passed, the degree classification they will be awarded.
//For simplicity, I recommend asking the user to enter their grade point (an integer), rather than a grade name such as 'High Pass'.

public class NTUDegreeClassifier
{
    public static string GetClassification(double gradePoint)
    {
        if (gradePoint >= 12.5) return "Distinction";
        if (gradePoint >= 9.5) return "Commendation";
        if (gradePoint >= 6.5) return "Pass";
        return "Fail";
    }
    public static void Main()
    {
        {
            Console.WriteLine("\nHi, welcome to the NTU Postgraduate Degree Classifiler.");
            Console.WriteLine("\nThis program will ask all your modules' grade points (six 20-credit modules and 60-credit major project.)\nPlease make sure you know all your grade points. (the range is 0-16)");
            Console.WriteLine();

            // ask for all grade points
            int[] moduleGrades = new int[6];

            for (int i = 0; i < 6; i++)
            {
                bool validInput = false;
                while (!validInput)
                {
                    Console.Write($"Enter your {i + 1} module grade point (0-16): ");
                    string input = Console.ReadLine() ?? "";

                    // check if input is valid
                    if (int.TryParse(input, out int grade) && grade >= 0 && grade <= 16)
                    {
                        moduleGrades[i] = grade;
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid. Please enter a number between 0 and 16.");
                    }
                }
            }

            // main project
            int mainProjectPoint = 0;
            bool validMainProject = false;
            while (!validMainProject)
            {
                Console.Write("Now, enter your Main Project grade point (0-16): ");
                string mainProject = Console.ReadLine() ?? "";

                if (int.TryParse(mainProject, out mainProjectPoint) && mainProjectPoint >= 0 && mainProjectPoint <= 16)
                {
                    validMainProject = true;
                    Console.WriteLine("All grades recorded.");
                }
                else
                {
                    Console.WriteLine("Invalid. Please enter a number between 0 and 16.");
                }
            }

            // check if passed or not
            Console.WriteLine("\n--- Pass/Fail Check ---");
            bool hasPassed = true;
            // check each module
            Console.WriteLine("Checking all modules...");
            for (int i = 0; i < 6; i++)
            {
                if (moduleGrades[i] < 7)
                {
                    hasPassed = false;
                    Console.WriteLine($"You failed module {i + 1}.");
                }
            }
            // check main project
            if (mainProjectPoint < 7)
            {
                hasPassed = false;
                Console.WriteLine("You failed main project.");
            }
            if (hasPassed)
            {
                Console.WriteLine("All modules passed!");
            }
            if (!hasPassed)
            {
                Console.WriteLine("Unfortunately, you failed your course.");
                return;
            }
            Console.WriteLine("Congrats! You passed your course.");

            // Calculate weighted mean
            Console.WriteLine("\n--- Weighted Mean Calculation ---");
            double totalWeightedPoints = 0;
            double totalCredits = 180;

            // add all module points
            for (int i = 0; i < 6; i++)
            {
                totalWeightedPoints += moduleGrades[i] * 20;
            }
            totalWeightedPoints += mainProjectPoint * 60;
            double weightedMean = totalWeightedPoints / totalCredits;
            Console.WriteLine($"Your weighted mean: {weightedMean:F1}");

            string meanClassification = GetClassification(weightedMean);
            Console.WriteLine($"Classification from Weighted Mean: {meanClassification}");


            // calculate majority grade
            Console.WriteLine("\n--- Majority Grade Calculation ---");

            // initialise 3 classification credits
            double distinctionCredits = 0;
            double commendationCredits = 0;
            double passCredits = 0;

            for (int i = 0; i < 6; i++)
            {
                if (moduleGrades[i] >= 13)
                {
                    distinctionCredits += 20;
                }
                else if (moduleGrades[i] >= 10)
                {
                    commendationCredits += 20;
                }
                else if (moduleGrades[i] >= 7)
                {
                    passCredits += 20;
                }
            }
            if (mainProjectPoint >= 13)
            {
                distinctionCredits += 60;
            }
            else if (mainProjectPoint >= 10)
            {
                commendationCredits += 60;
            }
            else if (mainProjectPoint >= 7)
            {
                passCredits += 60;
            }

            // find majority grade (>50% of 180, > 90)
            string majorityGrade = "Pass";
            if (distinctionCredits > 90)
            {
                majorityGrade = "Distinction";
            }
            else if ((distinctionCredits + commendationCredits) > 90)
            {
                majorityGrade = "Commendation";
            }

            Console.WriteLine($"Credits at Distinction level: {distinctionCredits} out of 180");
            Console.WriteLine($"Credits at Commendation level: {commendationCredits} out of 180");
            Console.WriteLine($"Majority Grade: {majorityGrade}");


            // find final grade
            Console.WriteLine("\n--- Final Degree Classification ---");
            Console.WriteLine($"Classification from Weighted Mean: {meanClassification}");
            Console.WriteLine($"Classification from Majority Grade: {majorityGrade}");

            string finalClassification;
            if (meanClassification == "Distinction" || majorityGrade == "Distinction")
            {
                finalClassification = "Distinction";
            }
            else if (meanClassification == "Commendation" || majorityGrade == "Commendation")
            {
                finalClassification = "Commendation";
            }
            else
            {
                finalClassification = "Pass";
            }

            Console.WriteLine("\nNote the degree classification awarded is determined by taking the better of either.");
            Console.WriteLine($"\nYOUR FINAL DEGREE CLASSIFICATION IS: {finalClassification}!");
            Console.WriteLine();

        }
    }
}