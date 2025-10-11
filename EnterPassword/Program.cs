using System.Data.Common;

namespace EnterPassword
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string SetPassword;
            string ConfirmPassword;
            string EnteredPassword;

            // ask user to set up their new password (twice)
            Console.Write("Please set your password: ");
            SetPassword = Console.ReadLine();

            Console.Write("Please confirm your password: ");
            ConfirmPassword = Console.ReadLine();


            while (SetPassword != ConfirmPassword)
            {
                Console.Write("Passwords do not match, please try again: ");
                SetPassword = Console.ReadLine();
                Console.Write("Repeat your password: ");
                ConfirmPassword = Console.ReadLine();
            }

            Console.WriteLine("Password created successfully!");
            Console.WriteLine();

            // log in
            Console.Write("Enter your password to log in: ");
            EnteredPassword = Console.ReadLine();

            if (SetPassword != EnteredPassword)
            {
                bool loginSuccess = false;

                for (int i = 0; i < 2; ++i)
                {
                    Console.Write("Password incorrect, please try again: ");
                    EnteredPassword = Console.ReadLine();

                    if (SetPassword == EnteredPassword)
                    {
                        loginSuccess = true;
                        break;
                    }
                }

                if (loginSuccess == true)
                {
                    Console.WriteLine("Log in successful!");
                }
                else
                {
                    Console.WriteLine("Maximum attempts reached, log in failed.");
                }
            }
            else
            {
                Console.WriteLine("Log in successful!");
            }
        }
    }
}
