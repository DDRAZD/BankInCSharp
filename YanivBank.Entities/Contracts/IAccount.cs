using System;
using System.Collections.Generic;


namespace Bank.Entities.Contracts
{
    /// <summary>
    /// represents interface of an account
    /// </summary>
    public interface IAccount
    {
        #region Properties
         List<Customer> AccountOwnerList { get; set; }
         long AccountId { get; set; }   
         decimal AccountAmount { get; set; }

        #endregion


    }
}
