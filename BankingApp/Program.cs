using BankingApp;
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
            Console.WriteLine("Logged in successfully!\n"); 

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
                Console.WriteLine("");


                // Swtich-case to check menu choice 
                switch (mainMenuChoice)
                {
                    case 1:
                        CustomersMenu();
                        break;
                    case 2:
                        AccountsMenu();
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


        // Exiting app
        Console.WriteLine("\nThank you! Come back again.");
;   }

    // Methods

    static void CustomersMenu()
    {
        Console.Clear();
        Console.WriteLine("You're in Customers Menu\n");
        // Variables to store customers menu choice
        int customersMenuChoice = -1;

        // Do-while loop
        do
        {
            // Show customer menu
            Console.WriteLine("\n======== Customers Menu ========");
            Console.WriteLine("1. Add Customer");
            Console.WriteLine("2. Delete Customer");
            Console.WriteLine("3. Update Customer");
            Console.WriteLine("4. Search Customer");
            Console.WriteLine("5. View Customers");
            Console.WriteLine("0. Back to Main Menu\n");

            // Accepting customers menu choice
            Console.Write("Enter choice (0-5): ");
            customersMenuChoice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");

            // Switch-case to check menu choice
            switch (customersMenuChoice)
            {
                case 1:
                    CustomersPresentation.AddCustomer();
                    break;
                case 2:
                    Console.WriteLine("Delete Customer");
                    break;
                case 3:
                    Console.WriteLine("Update Customer");
                    break;
                case 4:
                    Console.WriteLine("Search Customer");
                    break;
                case 5:
                    CustomersPresentation.ViewCustomers();
                    break;
                case 0:
                    break;
            }
        }
        while (customersMenuChoice != 0);

    }

    static void AccountsMenu()
    {   
        Console.Clear();
        Console.WriteLine("You're in Accounts Menu\n");
        // Variable to store accounts menu choice
        int accountsMenuChoice = -1;

        do
        {
            // Show accounts menu
            Console.WriteLine("======== Accounts Menu ========");
            Console.WriteLine("1. Add Account");
            Console.WriteLine("2. Delete Account");
            Console.WriteLine("3. Update Account");
            Console.WriteLine("4. View Accounts");
            Console.WriteLine("0. Back to Main Menu\n");

            // Accept accounts menu choice 
            Console.Write("Enter choice (0-4): ");
            accountsMenuChoice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");

        } while (accountsMenuChoice != 0);
    } 
} 