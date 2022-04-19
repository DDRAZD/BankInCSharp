using System;
using System.Collections.Generic;
using Bank.Exceptions;
using Bank.Entities;
using Bank.DataAccessLayer.DALContracts;

namespace Bank.DataAccessLayer
{
    /// <summary>
    /// this class is the DAL for accounts and will interact with the DB or a mock DB
    /// </summary>
     public class AccountsDataAccessLalyer:IAccountDataAccessLayer
    {
        #region Fields

        private static List<Accounts> _accounts; //this is the account DB; this has to be static so wont get overriden every time

        #endregion

        #region Constructor
        static AccountsDataAccessLalyer()
        {
            _accounts = new List<Accounts>();
        }         


        #endregion

        #region Properties

        private static List<Accounts> Accounts {
            get => _accounts;
            set => _accounts =value;
        }


        #endregion


        #region Methods

        /// <summary>
        /// add an owner to an existing account
        /// </summary>
        /// <param name="customer">customer to add</param>
        /// <param name="accountID">account to add owner to</param>
        
        public void AddOwner(Customer customer, long accountID)
        {

            try
            {
                if (Accounts == null) throw new AccountException("there are no existing accounts");

               List<Accounts> accountList= Accounts.FindAll(item=>item.AccountId == accountID);
                if (accountList != null)
                {
                    foreach (Accounts account in accountList)
                    {
                        account.AccountOwnerList.Add(customer);
                    }
                }

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
        /// closes an account and removes from list
        /// </summary>
        /// <param name="accountId">account to be removed</param>
        /// <returns></returns>
       
        public bool CloseAccount(long accountId)
        {
            

            try
            {
                if(Accounts==null) return false;
                if ((Accounts.RemoveAll(item => item.AccountId == accountId) > 0))
                    return true;
                else
                    return false;

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
        /// gets all the account list
        /// </summary>
        /// <returns>list of all accounts</returns>
        
        public List<Accounts> GetACcounts()
        {
            try
            {
                //we dont just return Accounts as that is private and we are separting the layers; we will create a copy (here the clone is actully used)

                List<Accounts> accountList = new List<Accounts>();
                //accountList = null;
                //we dont just add, we need to clone
                if(Accounts != null)
                {
                    Accounts.ForEach(item => accountList.Add(item.Clone() as Accounts));
                }
                        

                return accountList;
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
        /// gets a list of accounts based on a condition
        /// </summary>
        /// <param name="predicate">condition to find accounts</param>
        /// <returns>a list of accounts that met the condition </returns>
        public List<Accounts> GetACcountsWithCondition(Predicate<Accounts> predicate)
        {
            try
            {
                //we dont just return Accounts as that is private and we are separting the layers; we will create a copy (here the clone is actully used)

                List<Accounts> filteredAccounts = new List<Accounts>();
                List<Accounts> accountList = new List<Accounts>();
                //we dont just add, we need to clone

                filteredAccounts = Accounts.FindAll(predicate);
                filteredAccounts.ForEach(item => accountList.Add(item.Clone() as Accounts));

                return accountList;

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
        /// opens an account with list of owners; receives from BAL a unique ID to implement as account ID
        /// </summary>
        /// <param name="customerList">list of customers to be owners</param>
        /// <param name="UniqueID"> a unique ID to make as account ID</param>
        /// <returns>account number opened; -1 if did not work</returns>
        public long OpenAccount(List<Customer> customerList, long UniqueID)
        {

            try
            {
                //no need to check here fo null; exception already thrown from the constructor of the account
                Accounts account = new Accounts(customerList);//generated the account with owners

                //now need to give it an ID
                if (UniqueID > 0)
                {
                    account.AccountId = UniqueID;
                    Accounts.Add(account);
                    return UniqueID;
                }
                else
                {
                    throw new AccountException("account number cannot be empty nor negative");
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        /// <summary>
        /// opens an account with list of owners; receives from BAL a unique ID to implement as account ID
        /// </summary>
        /// <param name="customerList">list of customers to be owners</param>
        /// <param name="UniqueID"> a unique ID to make as account ID</param>
        /// <returns>account number opened; -1 if did not work</returns>
        public long OpenAccount(Customer customer, long UniqueID)
        {

            try
            {
                //no need to check here fo null; exception already thrown from the constructor of the account
                Accounts account = new Accounts(customer);//generated the account with owners

                //now need to give it an ID
                if (UniqueID > 0)
                {
                    account.AccountId = UniqueID;
                    return UniqueID;
                }
                else
                {
                    throw new AccountException("account number cannot be empty nor negative");
                }
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

        public bool RemoveOwner(Customer customer, long accountID)
        {

            try
            {
                Accounts account;

                account = Accounts.Find(item => item.AccountId == accountID);
                bool result = account.AccountOwnerList.Remove(customer);
                return result;

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
