using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSBank.Entities.Contracts
{
    public interface ITransaction
    {
        #region Properties
        Guid TransactionID { get; set; }
        decimal Amount { get; set; }
        Guid DestinationAccountID { get; set; }
        Guid SourceAccountID { get; set; }
        DateTime TransactionDateTime { get; set; }
        #endregion
    }
}   
