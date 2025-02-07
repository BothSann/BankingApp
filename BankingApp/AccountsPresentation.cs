using System;
using System.Collections.Generic;
using System.Linq;
using BSBank.BusinessLogicLayer;
using BSBank.BusinessLogicLayer.BALContracts;
using BSBank.Entities;



namespace BankingApp
{
    static class AccountsPresentation
    {
        internal static void ViewAccounts()
        {
            try
            {
                IAccountsBusinessLogicLayer accountsBusinessLayer = new AccountsBusinessLogicLayer();
                ICustomersBusinessLogicLayer customersBusinessLayer = new CustomersBusinessLogicLayer();

                List<Account> allAccounts = accountsBusinessLayer.GetAccounts();
                if (allAccounts.Count <= 0)
                {
                    Console.WriteLine("No accounts found.");
                    return;
                }
                Console.WriteLine("\n======== VIEW ACCOUNTS ========");
                foreach (var account in allAccounts)
                {
                    Console.WriteLine("Account Number: " + account.AccountNumber);
                    Customer customer = customersBusinessLayer.GetCustomersByCondition(item => item.CustomerID == account.CustomerID).FirstOrDefault();
                    if (customer != null)
                    {
                        Console.WriteLine("Customer Code: " + customer.CustomerCode);
                        Console.WriteLine("Customer Name: " + customer.CustomerName);
                    }
                    Console.WriteLine("Balance: " + account.Balance);
                    Console.WriteLine("==================================");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }
        internal static void AddAccount()
        {
			try
			{
                // Create an object of Account
                Account account = new Account();

                // Create BL object
                IAccountsBusinessLogicLayer accountsBusinessLayer = new AccountsBusinessLogicLayer();
                ICustomersBusinessLogicLayer customersBusinessLayer = new CustomersBusinessLogicLayer();

                if (customersBusinessLayer.GetCustomers().Count <= 0)
                {
                    Console.WriteLine("No customers found. Please add a customer first.");
                    return;
                }
                Console.WriteLine("\n======== ADD ACCOUNT ========");
                CustomersPresentation.ViewCustomers();

                Console.Write("Enter Customer Code for which you want to create an account: ");
                long customerCode;
                while (!long.TryParse(Console.ReadLine(), out customerCode))
                {
                    Console.WriteLine("Please enter a valid customer code.");
                }
                var existingCustomer = customersBusinessLayer.GetCustomersByCondition(item => item.CustomerCode == customerCode).FirstOrDefault();
                if (existingCustomer.Equals(null))
                {
                    Console.WriteLine("Customer not found.");
                    return;
                }

                account.CustomerID = existingCustomer.CustomerID;
                Guid newGuid = accountsBusinessLayer.AddAccount(account);

                List<Account> matchingAccounts = accountsBusinessLayer.GetAccountsByCondition(item => item.AccountID.Equals(newGuid));
                if (matchingAccounts.Count >= 1)
                {
                    Console.WriteLine("\n\nAccount added successfully");
                    Console.WriteLine("New Account Number: " + matchingAccounts[0].AccountNumber);
                }
                else
                {
                    Console.WriteLine("Account not added");
                }
            }
            catch (Exception ex)
			{
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
			}
        }
        internal static void DeleteAccount()
        {
            try
            {
                IAccountsBusinessLogicLayer accountsBusinessLayer = new AccountsBusinessLogicLayer();
                if (accountsBusinessLayer.GetAccounts().Count <= 0)
                {
                    Console.WriteLine("No accounts found.");
                    return;
                }

                Console.WriteLine("\n========= DELETE ACCOUNT =========");
                ViewAccounts();

                Console.Write("Enter Account Number to delete: ");
                long accountNumberToDelete;
                while (!long.TryParse(Console.ReadLine(), out accountNumberToDelete))
                {
                    Console.WriteLine("Please enter a valid account number.");
                }
                var existingAccount = accountsBusinessLayer.GetAccountsByCondition(item => item.AccountNumber == accountNumberToDelete).FirstOrDefault();
                if(existingAccount.Equals(null))
                {
                    Console.WriteLine("Account not found.");
                    return;
                }
                bool isDeleted = accountsBusinessLayer.DeleteAccount(existingAccount.AccountID);
                if (isDeleted)
                {
                    Console.WriteLine("Account deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Account not deleted.");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }
        internal static void UpdateAccount() 
        {
            try
            {
                IAccountsBusinessLogicLayer accountsBusinessLayer = new AccountsBusinessLogicLayer();
                ICustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomersBusinessLogicLayer();

                if (accountsBusinessLayer.GetAccounts().Count <= 0)
                {
                    Console.WriteLine("No accounts found.");
                    return;
                }
                Console.WriteLine("\n======== UPDATE ACCOUNT ========");
                ViewAccounts();

                Console.Write("Enter Account Number to update: ");
                long accountNumberToUpdate;
                while (!long.TryParse(Console.ReadLine(), out accountNumberToUpdate))
                {
                    Console.WriteLine("Please enter a valid account number.");
                }
                var existingAccount = accountsBusinessLayer.GetAccountsByCondition(item => item.AccountNumber == accountNumberToUpdate).FirstOrDefault();
                if (existingAccount.Equals(null))
                {
                    Console.WriteLine("Account not found.");
                    return;
                }
                Console.WriteLine("==================================");
                CustomersPresentation.ViewCustomers();

                Console.Write("Enter Customer Code for which you want to update the account: ");
                long customerCodeToUpdate;
                while (!long.TryParse(Console.ReadLine(), out customerCodeToUpdate))
                {
                    Console.WriteLine("Please enter a valid customer code.");
                }
                var existingCustomer = customersBusinessLogicLayer.GetCustomersByCondition(item => item.CustomerCode == customerCodeToUpdate).FirstOrDefault();
                if (existingCustomer.Equals(null))
                {
                    Console.WriteLine("Customer not found.");
                    return;
                }
                existingAccount.CustomerID = existingCustomer.CustomerID;
                Console.Write("Balance: ");
                existingAccount.Balance = long.Parse(Console.ReadLine());

                bool isUpdated = accountsBusinessLayer.UpdateAccount(existingAccount);
                if (isUpdated)
                {
                    Console.WriteLine("Account updated successfully.");
                }
                else
                {
                    Console.WriteLine("Account not updated.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }
        internal static void SearchAccount() 
        {
            try
            {
                IAccountsBusinessLogicLayer accountsBusinessLogicLayer = new AccountsBusinessLogicLayer();
                ICustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomersBusinessLogicLayer();

                if (accountsBusinessLogicLayer.GetAccounts().Count <= 0)
                {
                    Console.WriteLine("No accounts found.");
                    return;
                }

                Console.WriteLine("\n======== SEARCH ACCOUNT ========");
                ViewAccounts();

                Console.Write("Enter Account Number to search: ");
                long accountNumberToSearch;
                while (!long.TryParse(Console.ReadLine(), out accountNumberToSearch))
                {
                    Console.WriteLine("Please enter a valid account number.");
                }

                var existingAccount = accountsBusinessLogicLayer.GetAccountsByCondition(item => item.AccountNumber == accountNumberToSearch).FirstOrDefault();
                if (existingAccount.Equals(null))
                {
                    Console.WriteLine("Account not found.");
                    return;
                }

                Console.WriteLine("Account Number: " + existingAccount.AccountNumber);

                Customer customer = customersBusinessLogicLayer.GetCustomersByCondition(item => item.CustomerID == existingAccount.CustomerID).FirstOrDefault();
                if (customer != null)
                {
                    Console.WriteLine("Customer Code: " + customer.CustomerCode);
                    Console.WriteLine("Customer Name: " + customer.CustomerName);
                }
                Console.WriteLine("Balance: " + existingAccount.Balance);
                Console.WriteLine("==================================");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }

    }
}
