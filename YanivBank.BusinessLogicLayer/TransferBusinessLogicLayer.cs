using System;
using System.Collections.Generic;
using System.Linq;
using Bank.BusinessLogicLayer.BLContracts;
using Bank.DataAccessLayer.DALContracts;
using Bank.BusinessLogicLayer.BALContracts;
using Bank.DataAccessLayer;
using Bank.Entities;
using Bank.Exceptions;


namespace Bank.BusinessLogicLayer
{
    public class TransferBusinessLogicLayer: ITransfersBusinessLogicLayer
    {

        #region Private Fields
        private ITransferDataAccessLayer _transferDataAccessLayer;

        
        #endregion

        #region Constructors 
        /// <summary>
        /// constructor that intializes a DAL for the BL
        /// </summary>
        public TransferBusinessLogicLayer()
        {
            TransferDataAccessLayer = new TransfersDataAccessLayer();
        }
        #endregion

        #region Properties
        /// <summary>
        /// private property that represents DAL; private so wont be touched externally
        /// </summary>
        private ITransferDataAccessLayer TransferDataAccessLayer
        { 
            get => _transferDataAccessLayer; 
            set => _transferDataAccessLayer = value; 
        }

        #endregion

        #region Methods

        /// <summary>
        /// method to move funds from one accountt to another - no issue if an account goes to negative balance
        /// </summary>
        /// <param name="FromAccount">moves account number only</param>
        /// <param name="ToAccount">moves account number only</param>
        /// <param name="Amount">amount to transfer</param>
        /// <returns>true if worked</returns>
       public void TransferFunds(long FromAccount, long ToAccount, decimal Amount)
        {
            try
            {
                TransferDataAccessLayer.TransferFunds(FromAccount, ToAccount, Amount);
            }
            catch (TransferExceptions)
            {

                throw;
            }


            catch (Exception)
            {

                throw;
            }
           
        }

        /// <summary>
        /// pulls from the database all transfers
        /// </summary>
        /// <returns>all transfers in the DB</returns>
        public List<Transfers> GetTransfer()
        {

            try
            {
                return TransferDataAccessLayer.GetTransfer();
            }
            catch (TransferExceptions)
            {

                throw;
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
                return TransferDataAccessLayer.GetTransferByCondition(predicate);
            }
            catch (TransferExceptions)
            {

                throw;
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
                return TransferDataAccessLayer.GetTransferByAccount(AccountId);
            }
            catch (TransferExceptions)
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
