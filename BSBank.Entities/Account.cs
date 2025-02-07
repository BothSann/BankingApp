using BSBank.Entities.Contracts;
using System;


namespace BSBank.Entities
{
    public class Account : IAccount, ICloneable
    {
        #region Private Field
        private Guid _accountID;
        private Guid _customerID;
        private long _accountNumber;
        private decimal _balance;
        #endregion

        #region Properties
        public Guid AccountID
        {
            get => _accountID;
            set => _accountID = value;
        }
        public Guid CustomerID
        {
            get => _customerID;
            set => _customerID = value;
        }

        public long AccountNumber
        {
            get => _accountNumber;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Account number cannot be negative");
                }
                _accountNumber = value;
            }
        }

        public decimal Balance
        {
            get => _balance;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Balance cannot be negative");
                }
                _balance = value;
            }
        }
        #endregion

        #region Constructors
        public Account()
        {
            AccountID = Guid.Empty;
            CustomerID = Guid.Empty;
            AccountNumber = 0L;
            Balance = 0.0M;
        }

        public Account(Guid accountID, Guid customerID, long accountNumber, decimal balance)
        {
            AccountID = accountID;
            CustomerID = customerID;
            AccountNumber = accountNumber;
            Balance = balance;
        }
        #endregion

        #region Methods
        public object Clone()
        {
            return new Account()
            {
                AccountID = this.AccountID,
                CustomerID = this.CustomerID,
                AccountNumber = this.AccountNumber,
                Balance = this.Balance
            };
        }
        #endregion
    }
}
