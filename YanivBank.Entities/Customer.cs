using System;
using Bank.Entities.Contracts;
using Bank.Exceptions;


namespace Bank.Entities
{

    /// <summary>
    /// represent customer of the bank
    /// </summary>
    public class Customer:ICustomer,ICloneable
    {
        #region Private Fields

        private Guid _customerID;
        private long _customerCode;
        private string _customerName;
        private string _address;
        private string _city;
        private string _landmark;
        private string _country;
        private string _mobile;
        #endregion

        #region Public Properties
        /// <summary>
        /// unique identification of the customer
        /// </summary>
        public Guid CustomerID { get => _customerID; set => _customerID = value; }
        /// <summary>
        /// auto generated code number of the customer
        /// </summary>
        public long CustomerCode 
        { 
            get => _customerCode;

            set {
                if (value > 0)
                {
                    _customerCode = value;
                }
                else
                {
                    throw new CustomerException("cutomer code cannot be negative");
                }
            }
        }
        /// <summary>
        /// name of customer
        /// </summary>
        public string CustomerName 
        { 
            get => _customerName;

            set
            {
                if (value.Length<=40 && string.IsNullOrWhiteSpace(value)==false)
                {
                    _customerName = value;
                }
                else
                {
                    throw new CustomerException("customer name cannot exceed 40 char and cannot be null");
                }
                
            }
        }
        /// <summary>
        /// address of customer
        /// </summary>
        public string Address { get => _address; set => _address = value; }

        /// <summary>
        /// customer cit
        /// </summary>
        public string City { get => _city; set => _city = value; }
        /// <summary>
        /// landmark of customer address
        /// </summary>
        public string Landmark { get => _landmark; set => _landmark = value; }
        /// <summary>
        /// country of customer address
        /// </summary>
        public string Country { get => _country; set => _country = value; }

        /// <summary>
        /// 10 digit customer mobile phone number
        /// </summary>
        public string Mobile
        {
            get => _mobile;
            set
            {
               if(value.Length==10)
                {
                    _mobile = value;
                }
               else
                {
                    throw new CustomerException("mobile number must be 10 digits");
                }
                
            }
        }
        #endregion

        #region Methods

        public object Clone()
        {
            Customer customer = new Customer()
            {
                CustomerID = this.CustomerID,
                CustomerCode = this.CustomerCode,
                Address = this.Address,
                City = this.City,
                Country = this.Country,
                Landmark = this.Landmark,
                Mobile = this.Mobile,
                CustomerName = this.CustomerName
            };
            return customer;
        }
        #endregion
    }
}
