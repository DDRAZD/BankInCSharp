using System;
using System.Collections.Generic;
using YanivBank.Exceptions;
using YanivBank.Entities;
using YanivBank.BusinessLogicLayer.BALContracts;
using YanivBank.DataAccessLayer.DALContracts;
using YanivBank.DataAccessLayer;


namespace YanivBank.BusinessLogicLayer
{
    /// <summary>
    /// this is the business logic layer for accounts
    /// </summary>
    public class AccountsBusinessLogicLayer : IAccountBusinessLogicLayer
    {

        #region Private Fields

        private IAccountDataAccessLayer _accountDataAccessLayer;

        #endregion

        #region Constructors
        /// <summary>
        /// constructor that initializes the BAL 
        /// </summary>
       public  AccountsBusinessLogicLayer()
        {
            _accountDataAccessLayer = new AccountsDataAccessLalyer();
        }
        #endregion

        #region Properties
        /// <summary>
        /// private property that represts the accounts BAL;
        /// </summary>
        private IAccountDataAccessLayer AccountDataAccessLayer
        { 
            get => _accountDataAccessLayer;
            set => _accountDataAccessLayer = value;
           
        }

        #endregion

        #region Methods
        /// <summary>
        /// pulls from "DB" all the accounts
        /// </summary>
        /// <returns>list of accounts in the DB</returns>
        public List<Accounts> GetACcounts()
        {
            try
            {
                //no direct access, going using DAL
                return AccountDataAccessLayer.GetACcounts();
            }
            catch(AccountException)
            {
                throw;
            }
            
            catch (Exception)
            {

                throw;
            }
            

        }


        /// <summary>
        /// pulls accounts that meet a certain condition
        /// </summary>
        /// <param name="predicate">condition to pull acccounts </param>
        /// <returns>list of accounts that meet a condition</returns>
        public   List<Accounts> GetACcountsWithCondition(Predicate<Accounts> predicate)
        {
            try
            {
                return AccountDataAccessLayer.GetACcountsWithCondition(predicate);
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

        /// <summary>
        /// closing account according to account number; can be user initiated, can be when you remove a customer
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns>true if worked</returns>
        public bool CloseAccount(long accountId)
        {
            try
            {
                return AccountDataAccessLayer.CloseAccount(accountId);
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

        /// <summary>
        /// opens an account with list of owners; creates the unique account ID
        /// </summary>
        /// <param name="customerList">list of customers to be owners</param>        
        /// <returns>true if was able to open the account</returns>
        public bool OpenAccount(List<Customer> customerList)
        {
            try
            {
                //now we have both the unique account ID, and the the customer to use
                long accountIDtoUse = AccountIDGenerator();
                return AccountDataAccessLayer.OpenAccount(customerList, accountIDtoUse);
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

        /// <summary>
        /// opens an account with list of owners; creates the unique account ID
        /// </summary>
        /// <param name="customerList">list of customers to be owners</param>      
        /// <returns>true if was able to open the account</returns>
       public  bool OpenAccount(Customer customer)
        {

            try
            {
                //now we have both the unique account ID, and the the customer to use
                long accountIDtoUse = AccountIDGenerator();
                return AccountDataAccessLayer.OpenAccount(customer, accountIDtoUse);
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

        /// <summary>
        /// adds another customer owner to the account
        /// </summary>
        /// <param name="customer">the owner to be added</param>

        public void AddOwner(Customer customer, long accountID)
        {
           

            try
            {
                AccountDataAccessLayer.AddOwner(customer, accountID);
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

        /// <summary>
        /// removes an owner; if the account has only one owner it will fail
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>returns true if removed, if could not remove (e.g. would have left account without owner) returns false</returns>
     public  bool RemoveOwner(Customer customer, long accountID)
        {
            try
            {
                return AccountDataAccessLayer.RemoveOwner(customer, accountID);
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


        /// <summary>
        /// generates account ID for the open accounts methods
        /// </summary>
        /// <returns>unique account ID</returns>
      public long AccountIDGenerator()
        {

            try
            {
                //need to generate an account number (unique)

                //gets all custoemrs
                List<Accounts> allAccounts = AccountDataAccessLayer.GetACcounts();

                long maxAccountCode = 0;
                long accountIDtoUse = YanivBank.Configuration.Settings.BasicAccountNumber;

                if(allAccounts != null)
                {
                    foreach (Accounts item in allAccounts)//have to do this like that and not with count as accounts might be removed and we never decrease the actual counter of the ID
                    {
                        if (item.AccountId > maxAccountCode)
                        {
                            maxAccountCode = item.AccountId;
                        }
                    }
                    if (allAccounts.Count >= 1)
                    {
                        accountIDtoUse = maxAccountCode + 1;
                    }
                    else
                    {
                        accountIDtoUse = YanivBank.Configuration.Settings.BasicAccountNumber + 1;
                    }
                                
                }
                return accountIDtoUse;

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
