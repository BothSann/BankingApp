using System;


namespace BankingApp
{
    public static class Input
    {
        public static int GetUserChoice()
        {
            int mainMenuChoice;
            Console.Write("Enter choice (0-5): ");
            mainMenuChoice = int.Parse(Console.ReadLine());
            Console.WriteLine("");

            return mainMenuChoice;
        }
    }
}
