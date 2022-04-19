using System;
using System.Collections.Generic;
using Bank.Entities.Contracts;
using Bank.Exceptions;

namespace Bank.Entities
{
    public class Transfers : ITransfer, ICloneable
    {
        #region Private Fields

        DateTime _dateOfTransfer;
        long _accountIDFrom;
        long _accountIDTo;
        decimal _amount;
        #endregion


        #region Properties
        public DateTime TransferDateTime { get => _dateOfTransfer; set => _dateOfTransfer = value; }
        public long AccountIDFrom { get => _accountIDFrom; set => _accountIDFrom = value; }
        public long AccountIDTo { get => _accountIDTo; set => _accountIDTo = value; }
        public decimal AmountTransfered { get => _amount; set => _amount = value; }




        #endregion

        #region Methods

        public object Clone()
        {
            Transfers transfer = new Transfers();

            transfer.AccountIDFrom = this.AccountIDFrom;
            transfer.AccountIDTo = this.AccountIDTo;
            transfer.AmountTransfered = this.AmountTransfered;
            transfer.TransferDateTime = this.TransferDateTime;

            return transfer;
        }

        #endregion

    }
}
