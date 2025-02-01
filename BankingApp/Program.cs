using System;

class Program
{
    static void Main ()
    {
        Console.WriteLine("------------- BS Bank -------------\n");
        Console.WriteLine("Login Page\n");

        string userName = null;
        string password = null;
            
        Console.Write("Enter username: ");
        userName = Console.ReadLine();

        // Check if username is entered
        if (userName != "")
        {
            Console.Write("Enter password: ");
            password = Console.ReadLine();
        }

        // Check username and password
        if (userName == "admin" && password == "123@")
        {
            Console.Clear();
            Console.WriteLine("Logged in successfully! \n");

            // Variables to store menu choice
            int mainMenuChoice = -1;


            do
            {
                // Show main menu
                Console.WriteLine("======== Main Menu ========");
                Console.WriteLine("1. Customers");
                Console.WriteLine("2. Accounts");
                Console.WriteLine("3. Funds Transfer");
                Console.WriteLine("4. Funds Transfer Statement");
                Console.WriteLine("5. Account Statement");
                Console.WriteLine("0. Exit\n");

                // Accepting user choice
                Console.Write("Enter choice (0-5): ");
                mainMenuChoice = int.Parse(Console.ReadLine());


                // Swtich-case to check menu choice 
                switch (mainMenuChoice)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 0:
                        break;
                }
            } while (mainMenuChoice != 0);

        }   
        else
        {
            Console.WriteLine("Invalid username or password!");
        }

        Console.WriteLine("Thank you! Come back again.");


;    }
} 