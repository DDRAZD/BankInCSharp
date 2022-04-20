using System;
using System.Collections.Generic;
using Bank.Entities.Contracts;
using Bank.Exceptions;


namespace Bank.Entities
{/// <summary>
/// accounts class
/// </summary>
     public class Accounts:IAccount, ICloneable 
    {
        #region Fields
        private List<Customer> _accountOwnerList;
        private long _accountId;
        private decimal _amount;
        private List<Transfers> _transfers;
        #endregion


        #region Public Properties

        public List<Customer> AccountOwnerList 
        { get { return _accountOwnerList; } 
            
            set 
            {
                if (value != null)//every account must have at least one owner
                    _accountOwnerList = value;
                else
                    throw new AccountException("every account must have at least one owner - got null as owner");
            }
        }
        public long AccountId 
        {
            get { return _accountId; } 
            
            set 
            {
                if (value >= 0)
                    _accountId = value;
                else
                    throw new AccountException("account ID cannot be negative");
            }
        }    

        public decimal AccountAmount
        { get { return _amount; }
            set 
            { 
               
                _amount = value; 
            } 
        }

        public List<Transfers> Transfers
        {
            get { return _transfers; }
            set { _transfers = value; }
        }


        #endregion

        #region Constructors

        /// <summary>
        /// every account must have at least one owner; the assumption is that an account is opened only while in an active session with a customer, thus having a constructor for an account that demands to receive one or more customer owners
        /// </summary>
        /// <param name="Owner">a single owner of an account</param>
        public Accounts(Customer Owner)
        {
            _accountOwnerList = new List<Customer>();//creates the owner list upon constrcutor launch
            _transfers = new List<Transfers>();//creates the transfer list upon constructor launch
            if (Owner != null)
            {
                _accountOwnerList.Add(Owner);

            }
            else
            {
                throw new AccountException("account owner cannot be null");
            }

        }
        /// <summary>
        /// every account must have at least one owner; the assumption is that an account is opened only while in an active session with a customer, thus having a constructor for an account that demands to receive one or more customer owners
        /// </summary>
        /// <param name="Owners">list of one or more owners</param>
        public Accounts(List<Customer> Owners)
        {
            _accountOwnerList = new List<Customer>();//creates the owner list upon constrcutor launch
            _transfers = new List<Transfers>();//creates the transfer list upon constructor launch

            if (Owners != null)
            {
                foreach(Customer Owner in Owners)
                    _accountOwnerList.Add((Customer)Owner);
            }
            else
            {
                throw new AccountException("account owner cannot be null");
            }


        }


        #endregion

        #region Methods

        /// <summary>
        /// method used to clone one account object to antoher; called by an account object
        /// </summary>
        /// <returns>returns an account object</returns>
        public object Clone()
        {
            Accounts account = new Accounts(this.AccountOwnerList);//every account has to have an owner; passing the calling account object owner list

            account.AccountId = this.AccountId;
            account.AccountAmount = this.AccountAmount;
            account.AccountOwnerList = this.AccountOwnerList;
            return account;
        }


        #endregion
    }
}
