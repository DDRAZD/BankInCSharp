using System;
using System.Collections.Generic;
using YanivBank.Exceptions;
using YanivBank.Entities;




namespace YanivBank.BusinessLogicLayer.BALContracts
{
    /// <summary>
    /// provides the interface for the businsss logic layer for accounts
    /// </summary>
     public interface IAccountBusinessLogicLayer
    {
        /// <summary>
        /// pulls from "DB" all the accounts
        /// </summary>
        /// <returns>list of accounts in the DB</returns>
        List<Accounts> GetACcounts();


        /// <summary>
        /// pulls accounts that meet a certain condition
        /// </summary>
        /// <param name="predicate">condition to pull acccounts </param>
        /// <returns>list of accounts that meet a condition</returns>
        List<Accounts> GetACcountsWithCondition(Predicate<Accounts> predicate);

        /// <summary>
        /// closing account according to account number; can be user initiated, can be when you remove a customer
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns>true if worked</returns>
        bool CloseAccount(long accountId);

        /// <summary>
        /// opens an account with list of owners; creates the unique account ID
        /// </summary>
        /// <param name="customerList">list of customers to be owners</param>        
        //// <returns>account number opened; -1 if did not work</returns>
        long OpenAccount(List<Customer> customerList);

        /// <summary>
        /// opens an account with list of owners; creates the unique account ID
        /// </summary>
        /// <param name="customerList">list of customers to be owners</param>      
        /// <returns>account number opened; -1 if did not work</returns>
        long OpenAccount(Customer customer);

        /// <summary>
        /// adds another customer owner to the account
        /// </summary>
        /// <param name="customer">the owner to be added</param>

        void AddOwner(Customer customer, long accountID);

        /// <summary>
        /// removes an owner; if the account has only one owner it will fail
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>returns true if removed, if could not remove (e.g. would have left account without owner) returns false</returns>
        bool RemoveOwner(Customer customer, long accountID);

        /// <summary>
        /// generates account ID for the open accounts methods
        /// </summary>
        /// <returns>unique account ID</returns>
        long AccountIDGenerator();

    }
}
