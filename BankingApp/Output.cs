using System;


namespace BankingApp
{
    public static class Output {

        public static void GetWelcomeMessage()
        {
            Console.WriteLine("=========== Welcome to BS Bank ===========");
            Console.WriteLine("=========== Login Page ===========\n");
        }

        public static void ShowMainMenu()
        {
            Console.WriteLine("======== Main Menu ========");
            Console.WriteLine("1. Customers");
            Console.WriteLine("2. Accounts");
            Console.WriteLine("3. Funds Transfer");
            Console.WriteLine("4. Funds Transfer Statement");
            Console.WriteLine("5. Account Statement");
            Console.WriteLine("0. Exit\n");
        }
        public static void ShowCustomerMenu() {
            Console.WriteLine("\n======== Customers Menu ========");
            Console.WriteLine("1. Add Customer");
            Console.WriteLine("2. Delete Customer");
            Console.WriteLine("3. Update Customer");
            Console.WriteLine("4. Search Customer");
            Console.WriteLine("5. View Customers");
            Console.WriteLine("0. Back to Main Menu\n");
        }

        public static void ShowAccountMenu() {
            Console.WriteLine("======== Accounts Menu ========");
            Console.WriteLine("1. Add Account");
            Console.WriteLine("2. Delete Account");
            Console.WriteLine("3. Update Account");
            Console.WriteLine("4. Search Account");
            Console.WriteLine("5. View Accounts");
            Console.WriteLine("0. Back to Main Menu\n");
        }
    }
}
