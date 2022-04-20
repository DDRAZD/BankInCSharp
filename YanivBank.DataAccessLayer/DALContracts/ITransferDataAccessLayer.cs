using System;
using System.Collections.Generic;
using Bank.Exceptions;
using Bank.Entities;


namespace Bank.DataAccessLayer.DALContracts
{
     public interface ITransferDataAccessLayer
    {
        /// <summary>
        /// method to move funds from one accountt to another - no issue if an account goes to negative balance
        /// </summary>
        /// <param name="FromAccount">moves account number only</param>
        /// <param name="ToAccount">moves account number only</param>
        /// <param name="Amount">amount to transfer</param>
        /// <returns>true if worked</returns>
        void TransferFunds(long FromAccount, long ToAccount, decimal Amount);

        /// <summary>
        /// pulls from the database all transfers
        /// </summary>
        /// <returns>all transfers in the DB</returns>
        List<Transfers> GetTransfer();

        /// <summary>
        /// returns all transfers by a certain contdiion 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>list of transfers that meet the condition</returns>
        List<Transfers> GetTransferByCondition(Predicate<Transfers> predicate);

        /// <summary>
        /// returns all the transactions of a specific account
        /// </summary>
        /// <param name="AccountId"></param>
        /// <returns>all transactions of a specific account</returns>
        List<Transfers> GetTransferByAccount(long AccountId);


    }
}
