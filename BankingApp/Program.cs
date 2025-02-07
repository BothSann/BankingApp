using BankingApp;
using System;

class Program
{
    static void Main ()
    {
        Output.GetWelcomeMessage();
        string userName = null;
        string password = null;
            
        Console.Write("Enter username: ");
        userName = Console.ReadLine();

        // Check if username is entered
        if (!string.IsNullOrEmpty(userName))
        {
            Console.Write("Enter password: ");
            password = Console.ReadLine();
        }

        // Check username and password
        if (userName.Equals("admin") && password.Equals("123@"))
        {
            Console.Clear();
            Console.WriteLine("Logged in successfully!\n"); 

            // Variables to store menu choice
            int mainMenuChoice = -1;
            do
            {
                // Show main menu
                Output.ShowMainMenu();
                // Accepting user choice
                mainMenuChoice = Input.GetUserChoice();


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
            Output.ShowCustomerMenu();
            // Accepting customers menu choice
            customersMenuChoice = Input.GetUserChoice();

            // Switch-case to check menu choice
            switch (customersMenuChoice)
            {
                case 1:
                    CustomersPresentation.AddCustomer();
                    break;
                case 2:
                    CustomersPresentation.DeleteCustomer();
                    break;
                case 3:
                    CustomersPresentation.UpdateCustomer();
                    break;
                case 4:
                    CustomersPresentation.SearchCustomer();
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
            Output.ShowAccountMenu();
            // Accept accounts menu choice 
            accountsMenuChoice = Input.GetUserChoice();

        } while (accountsMenuChoice != 0);
    } 
} 