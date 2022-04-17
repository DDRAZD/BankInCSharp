using System;
using System.Collections.Generic;
using YanivBank.Entities.Contracts;
using YanivBank.Exceptions;


namespace YanivBank.Entities
{/// <summary>
/// accounts class
/// </summary>
     class Accounts
    {
        #region Fields
        private List<Customer> _accountOwnerList;
        private long _accountId;
        private decimal _amount;
        #endregion


        #region Public Properties

        public List<Customer> AccountOwnerList { get { return _accountOwnerList; } set { _accountOwnerList = value; } }
        public long AccountId 
        {
            get { return _accountId; } 
            
            set 
            { 
                if(value>=0)
                     _accountId =  value;
                else
                    throw 
            }
        }    

        public decimal Amount { get { return _amount; } set { _amount = value; } }  

        #endregion
    }
}
