using System;
using System.Collections.Generic;


namespace Bank.Entities.Contracts
{
    /// <summary>
    /// interface that includes the elements necessary for a transfer
    /// </summary>
    public interface ITransfer
    {
        #region Properties

        DateTime TransferDateTime { get; set; }
        long AccountIDFrom { get; set; }    
        long AccountIDTo { get; set; }

        decimal AmountTransfered { get; set; }


        #endregion 


    }
}
