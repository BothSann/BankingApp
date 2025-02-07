using System;
using System.Collections.Generic;
using BSBank.BusinessLogicLayer.BALContracts;
using BSBank.DataAccessLayer.DALContracts;
using BSBank.Entities;
using BSBank.Exceptions;
using BSBank.DataAccessLayer;
using BSBank.Configuration;

namespace BSBank.BusinessLogicLayer
{
    public class AccountsBusinessLogicLayer : IAccountsBusinessLogicLayer
    {
        #region Private Fields
        private IAccountsDataAccessLayer _accountsDataAccessLayer;
        #endregion

        #region Constructors
        public AccountsBusinessLogicLayer()
        {
            _accountsDataAccessLayer = new AccountsDataAccessLayer();
        }
        #endregion

        #region Properties
        private IAccountsDataAccessLayer AccountsDataAccessLayer
        {
            set => _accountsDataAccessLayer = value;
            get => _accountsDataAccessLayer;
        }
        #endregion

        #region Methods 
        public List<Account> GetAccounts()
        {
            try
            {
                // Invoke DAL
                return AccountsDataAccessLayer.GetAccounts();
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
        public List<Account> GetAccountsByCondition(Predicate<Account> condition)
        {
            try
            {
                // Invoke DAL
                return AccountsDataAccessLayer.GetAccountsByCondition(condition);
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
                List<Account> allAccounts = AccountsDataAccessLayer.GetAccounts();
                long maxAccountNumber = 0;
                foreach (var item in allAccounts)
                {
                    if (item.AccountNumber > maxAccountNumber)
                    {
                        maxAccountNumber = item.AccountNumber;
                    }
                }
                if (allAccounts.Count >= 1)
                {
                    account.AccountNumber = maxAccountNumber + 1;
                }
                else
                {
                    account.AccountNumber = Settings.BaseAccountNo + 1;
                }
                account.Balance = 0.0M;
                return AccountsDataAccessLayer.AddAccount(account);
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
                return AccountsDataAccessLayer.UpdateAccount(account);
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
                return AccountsDataAccessLayer.DeleteAccount(accountID);
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
