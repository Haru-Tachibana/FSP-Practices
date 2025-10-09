using System;

namespace IncomeTaxCalculator
{
    class Program
    {
        // tax year 25/26 constants
        const decimal PERSONAL_ALLOWANCE = 12570m;
        const decimal PERSONAL_ALLOWANCE_THRESHOLD = 100000m;
        const decimal PERSONAL_ALLOWANCE_REDUCTION_RATE = 0.5m;
        const decimal PERSONAL_ALLOWANCE_ELIMINATION_THRESHOLD = 125140m;
        const decimal BASIC_RATE_UPPER_LIMIT = 37700m;

        // tax rates
        const decimal BASIC_RATE = 0.20m;
        const decimal HIGHER_RATE = 0.40m;
        const decimal ADDITIONAL_RATE = 0.45m;


        static void Main(string[] args)
        {
            Console.WriteLine("=======================================================");
            Console.WriteLine("  UK Income Tax Calculator - Tax Year 2025/2026");
            Console.WriteLine("=======================================================\n");

            // Get user input
            decimal grossIncome = GetGrossIncome();

            // Calculate personal allowance
            decimal personalAllowance = CalculatePersonalAllowance(grossIncome);

            // Calculate taxable income
            decimal taxableIncome = CalculateTaxableIncome(grossIncome, personalAllowance);

            // Calculate income tax
            decimal incomeTax = CalculateIncomeTax(taxableIncome);

            // Calculate net income
            decimal netIncome = grossIncome - incomeTax;

            // Display results
            DisplayResults(grossIncome, personalAllowance, taxableIncome, incomeTax, netIncome);

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }


        // get user input for gross income
        static decimal GetGrossIncome()
        {
            decimal grossIncome;
            bool validInput;

            do
            {
                Console.Write("Enter your annual gross income (£): ");
                string input = Console.ReadLine();

                validInput = decimal.TryParse(input, out grossIncome) && grossIncome >= 0;
                if (!validInput)
                {
                    Console.WriteLine("Invalid input. Please enter a valid non-negative number.");
                }
            }
            while (!validInput);

            return grossIncome;
        }


        // use grossIncome to calculate personal allowance
        static decimal CalculatePersonalAllowance(decimal grossIncome)
        {
            if (grossIncome <= PERSONAL_ALLOWANCE_THRESHOLD)
            {
                return PERSONAL_ALLOWANCE;
            }
            else if (grossIncome >= PERSONAL_ALLOWANCE_ELIMINATION_THRESHOLD)
            {
                return 0m;
            }
            else
            {
                decimal reduction = (grossIncome - PERSONAL_ALLOWANCE_THRESHOLD) * PERSONAL_ALLOWANCE_REDUCTION_RATE;
                decimal adjustedAllowance = PERSONAL_ALLOWANCE - reduction;

                return Math.Max(0m, adjustedAllowance);
            }
        }


        // calculates taxable income
        private static decimal CalculateTaxableIncome(decimal grossIncome, decimal personalAllowance)
        {
            decimal taxableIncome = grossIncome - personalAllowance;
            return Math.Max(0m, taxableIncome);
        }


        // calculates total income tax based on taxable income and tax bands
        static decimal CalculateIncomeTax(decimal taxableIncome)
        {
            decimal tax = 0m;

            if (taxableIncome <= 0)
            {
                return 0m;
            }

            // basic rate
            if (taxableIncome > 0)
            {
                decimal basicRateAmount = Math.Min(taxableIncome, BASIC_RATE_UPPER_LIMIT);
                tax += basicRateAmount * BASIC_RATE;
            }
            // higher rate
            if (taxableIncome > BASIC_RATE_UPPER_LIMIT)
            {
                decimal higherRateAmount = Math.Min(taxableIncome - BASIC_RATE_UPPER_LIMIT,
                PERSONAL_ALLOWANCE_ELIMINATION_THRESHOLD - BASIC_RATE_UPPER_LIMIT);
                tax += higherRateAmount * HIGHER_RATE;
            }
            // additional rate
            if (taxableIncome > PERSONAL_ALLOWANCE_ELIMINATION_THRESHOLD)
            {
                decimal additionalRateAmount = taxableIncome - PERSONAL_ALLOWANCE_ELIMINATION_THRESHOLD;
                tax += additionalRateAmount * ADDITIONAL_RATE;
            }
            return tax;
        }
        // Displays calculation results in a formatted manner
        private static void DisplayResults(decimal grossIncome, decimal personalAllowance,
                                          decimal taxableIncome, decimal incomeTax, decimal netIncome)
        {
            Console.WriteLine("\n=======================================================");
            Console.WriteLine("CALCULATION RESULTS");
            Console.WriteLine("=======================================================");
            Console.WriteLine($"Gross Income:        £{grossIncome:N2}");
            Console.WriteLine($"Personal Allowance:  £{personalAllowance:N2}");
            Console.WriteLine($"Taxable Income:      £{taxableIncome:N2}");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine($"Income Tax:          £{incomeTax:N2}");
            Console.WriteLine($"Net Income:          £{netIncome:N2}");
            Console.WriteLine("=======================================================");

            // Display effective tax rate
            if (grossIncome > 0)
            {
                decimal effectiveRate = (incomeTax / grossIncome) * 100;
                Console.WriteLine($"Effective Tax Rate:  {effectiveRate:F2}%");
            }

            // Display tax band breakdown
            DisplayTaxBandBreakdown(taxableIncome);
        }

        // Displays breakdown of which tax bands apply to the income
        private static void DisplayTaxBandBreakdown(decimal taxableIncome)
        {
            Console.WriteLine("\n-------------------------------------------------------");
            Console.WriteLine("TAX BAND BREAKDOWN");
            Console.WriteLine("-------------------------------------------------------");

            if (taxableIncome <= 0)
            {
                Console.WriteLine("No tax payable (income below personal allowance)");
                return;
            }

            // Basic rate
            if (taxableIncome > 0)
            {
                decimal basicAmount = Math.Min(taxableIncome, BASIC_RATE_UPPER_LIMIT);
                Console.WriteLine($"Basic Rate (20%):       £{basicAmount:N2}");
            }

            // Higher rate
            if (taxableIncome > BASIC_RATE_UPPER_LIMIT)
            {
                decimal higherAmount = Math.Min(
                    taxableIncome - BASIC_RATE_UPPER_LIMIT,
                    PERSONAL_ALLOWANCE_ELIMINATION_THRESHOLD - BASIC_RATE_UPPER_LIMIT
                );
                Console.WriteLine($"Higher Rate (40%):      £{higherAmount:N2}");
            }

            // Additional rate
            if (taxableIncome > PERSONAL_ALLOWANCE_ELIMINATION_THRESHOLD)
            {
                decimal additionalAmount = taxableIncome - PERSONAL_ALLOWANCE_ELIMINATION_THRESHOLD;
                Console.WriteLine($"Additional Rate (45%):  £{additionalAmount:N2}");
            }

            Console.WriteLine("=======================================================");
        }
    }
}