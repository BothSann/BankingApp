using System;
using System.Collections.Generic;
using BSBank.Entities;

namespace BSBank.DataAccessLayer.DALContracts
{
    public interface IAccountsDataAccessLayer
    {
        List<Account> GetAccounts ();
        List<Account> GetAccountsByCondition(Predicate <Account> condition);
        Guid AddAccount(Account account);
        bool UpdateAccount(Account account);
        bool DeleteAccount(Guid accountID);
    }
}
