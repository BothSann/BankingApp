using System;

namespace BSBank.Entities.Contracts
{
    public interface IAccount
    {
        #region Properties
        Guid AccountID { get; set; }
        long AccountNumber { get; set; }
        decimal Balance { get; set; }
        Guid CustomerID { get; set; }
        #endregion
    }
}
