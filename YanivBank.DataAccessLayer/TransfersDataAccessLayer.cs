using System;
using System.Collections.Generic;
using Bank.Entities;
using Bank.Exceptions;
using Bank.DataAccessLayer.DALContracts;
using Bank.Configuration;

namespace Bank.DataAccessLayer
{
    /// <summary>
    /// class that represents the simple data access layer of transactions
    /// </summary>
    public class TransfersDataAccessLayer : ITransferDataAccessLayer
    {

        #region Private Fields

        private static List<Transfers> _transfers;//this is the transfer database; it will be duplicated within accounts as well



        #endregion

        #region Public Properties
        public List<Transfers> Transfers { get => _transfers; set => _transfers = value; }
        #endregion


        #region Constructors

         static TransfersDataAccessLayer()
        {
            _transfers = new List<Transfers>();//generating the transfer database
        }


        #endregion 


        #region Methods
        /// <summary>
        /// method to move funds from one accountt to another - no issue if an account goes to negative balance
        /// </summary>
        // <param name="ToAccount">moves account number only</param>
        /// <param name="Amount">amount to transfer</param>
        /// <param name="Amount">amount to transfer</param>
        /// <returns>true if worked</returns>
        public void TransferFunds(long FromAccount, long ToAccount, decimal Amount)
        {
            if (Amount < 0)
                throw new ArgumentException("transfer amount cannot be negative");

            if (FromAccount < Bank.Configuration.Settings.BasicAccountNumber || 
                ToAccount < Bank.Configuration.Settings.BasicAccountNumber)//account number invalid
                throw new ArgumentException("One or both accounts numners for transfer is invalid - cannot complete transfer");

            //access the accounts themslves, using the account number
            Transfers transfer = new Transfers() { AccountIDFrom = FromAccount, AccountIDTo = ToAccount, AmountTransfered = Amount, TransferDateTime = DateTime.UtcNow };

            Transfers.Add(transfer);//adds to the actual transaction database

            //updating the accounts; have to create an Account DAL instance 

            IAccountDataAccessLayer AccountDataAccessLayer = new AccountsDataAccessLalyer();

            //  List<Accounts> FromAccountLIst = new List<Accounts>();

            List<Accounts> FromAccountLIst = AccountDataAccessLayer.GetACcountsWithCondition(item => item.AccountId == FromAccount);

            // List<Accounts> ToACcountList = new List<Accounts>();

            List<Accounts> ToACcountList = AccountDataAccessLayer.GetACcountsWithCondition(item => item.AccountId == ToAccount);

            //update balances
            FromAccountLIst[0].AccountAmount = FromAccountLIst[0].AccountAmount - Amount;
            ToACcountList[0].AccountAmount = ToACcountList[0].AccountAmount + Amount;

            //add transaction record to both accounts:
            FromAccountLIst[0].Transfers.Add(transfer);
            ToACcountList[0].Transfers.Add(transfer);


        }
        /// <summary>
        /// pulls from the database all transfers
        /// </summary>
        /// <returns>all transfers in the DB</returns>
        public List<Transfers> GetTransfer()
        {

            try
            {
                List<Transfers> transfers = new List<Transfers>();

                Transfers.ForEach(item => transfers.Add(item.Clone() as Transfers));

                return transfers;
            }
            catch (Exception)
            {

                throw;
            }
            


        }
        /// <summary>
        /// returns all transfers by a certain contdiion 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>list of transfers that meet the condition</returns>
        public List<Transfers> GetTransferByCondition(Predicate<Transfers> predicate)
        {

            try
            {
                List<Transfers> transfersToReturn = new List<Transfers>();
                List<Transfers> filteredTransfers = new List<Transfers>();

                filteredTransfers = Transfers.FindAll(predicate);

                filteredTransfers.ForEach(item => transfersToReturn.Add(item.Clone() as Transfers));
                return transfersToReturn;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        /// <summary>
        /// returns all the transactions of a specific account
        /// </summary>
        /// <param name="AccountId"></param>
        /// <returns>all transactions of a specific account</returns>
        public List<Transfers> GetTransferByAccount(long AccountId)
        {
            try
            {
                //creating the DAL layer of accounts to access it
                IAccountDataAccessLayer AccountDataAccessLayer = new AccountsDataAccessLalyer();

                List<Accounts> listOfACcounts = new List<Accounts>();

                listOfACcounts = AccountDataAccessLayer.GetACcountsWithCondition(item => item.AccountId == AccountId);

                return listOfACcounts[0].Transfers;

            }
            catch (Exception)
            {

                throw;
            }
            

        }
        #endregion Methods

    }

}
