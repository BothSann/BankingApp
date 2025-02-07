using System;
using System.Collections.Generic;
using BSBank.Entities;
using BSBank.Exceptions;
using BSBank.DataAccessLayer.DALContracts;

namespace BSBank.DataAccessLayer
{
    public class AccountsDataAccessLayer : IAccountsDataAccessLayer
    {
        #region Private Fields
        private static List<Account> _accounts;
        #endregion

        #region Constructors
        static AccountsDataAccessLayer()
        {
            _accounts = new List<Account>()
            {
                new Account() { AccountID = Guid.Parse("E3B7F3CB-1315-431B-8E60-4FE6D79084C8"), AccountNumber = 10001, Balance = 1000, CustomerID = Guid.Parse("8C12BEA9-8FB0-4744-8422-1996533805E8") },
                new Account() { AccountID = Guid.Parse("68319657-1FCF-49CC-9193-C4442F55AD28"), AccountNumber = 10002, Balance = 500, CustomerID = Guid.Parse("8C12BEA9-8FB0-4744-8422-1996533805E8") },
            };
        }
        #endregion

        #region Properties
        private static List<Account> Accounts
        {
            get => _accounts;
            set => _accounts = value;
        }
        #endregion

        #region Methods
        public List<Account> GetAccounts()
        {
            try
            {
                // Create a new list of accounts
                List<Account> accountsList = new List<Account>();

                // Copy all accounts from source collection into newAccounts collection
                Accounts.ForEach(item => accountsList.Add(item.Clone() as Account));
                return accountsList;
            }
            catch (AccountException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Account> GetAccountsByCondition (Predicate<Account> condition)
        {
            try
            {
                // Create a new list of accounts
                List<Account> accountsList = new List<Account>();

                // Fileter accounts based on condition
                List<Account> filteredAccounts = Accounts.FindAll(condition);

                // Copy all accounts from source collection into newAccounts collection
                filteredAccounts.ForEach(item => accountsList.Add(item.Clone() as Account));
                return accountsList;
            }
            catch (AccountException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Guid AddAccount(Account account)
        {
            try
            {
                // Generate a new account ID
                account.AccountID = Guid.NewGuid();

                // Add account
                Accounts.Add(account);
                return account.AccountID;
            }
            catch (AccountException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool UpdateAccount(Account account)
        {
            try
            {
                // Find account
                Account existingAccount = Accounts.Find(item => item.AccountID == account.AccountID);
                // Update account
                if (existingAccount != null)
                {
                    existingAccount.AccountID = account.AccountID;
                    existingAccount.AccountNumber = account.AccountNumber;
                    existingAccount.Balance = account.Balance;
                    existingAccount.CustomerID = account.CustomerID;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (AccountException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool DeleteAccount(Guid accountID)
        {
            try
            {
                if (Accounts.RemoveAll(item => item.AccountID == accountID) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (AccountException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
