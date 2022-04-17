using System;
using System.Collections.Generic;
using YanivBank.BusinessLogicLayer.BLContracts;
using YanivBank.DataAccessLayer.DALContracts;
using YanivBank.DataAccessLayer;
using YanivBank.Entities;
using YanivBank.Exceptions;

namespace YanivBank.BusinessLogicLayer
{
    /// <summary>
    /// represents customer business logic
    /// </summary>
    public class CustomersBusinessLogicLayer:ICustomerBusinessLogicLayer
    {
        #region Private Fields
        private ICustomerDataAccessLayer _customerDataAccessLayer;
        #endregion

        #region Constructors 
        /// <summary>
        /// constructor that intializes a DAL for the BL
        /// </summary>
        public CustomersBusinessLogicLayer()
        {
            _customerDataAccessLayer = new  CustomerDataAccessLayer();
        }
        #endregion

        #region Properties
        /// <summary>
        /// private property that represents DAL; private so wont be touched externally
        /// </summary>
        private ICustomerDataAccessLayer CustomerDataAccessLayer
        {
            set => _customerDataAccessLayer = value;
            get => _customerDataAccessLayer;
        }
        #endregion

        #region Methods

        /// <summary>
        /// returns all existing customers
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetCustomers()
        {
            
            try
            {
                // we dont access Data directly, but via DAL
                return CustomerDataAccessLayer.GetCustomers();
            }
            catch (CustomerException)
            {
                throw;
            }
            
            catch (Exception)
            {

                throw;
            }
            
        }

        /// <summary>
        /// returns all customers that meet the given condition (predicate)
        /// </summary>
        /// <param name="predicate">;ambda expression that gives condition to check</param>
        /// <returns></returns>
        public List<Customer> GetCustomerByCondition(Predicate<Customer> predicate)
        {
            
            try
            {
                //invoke DAL
                return CustomerDataAccessLayer.GetCustomerByCondition(predicate);

            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// creates GUID for customer we want to add, and adds customer to list
        /// </summary>
        /// <param name="customer">the customer object to add</param>
        /// <returns></returns>
        public Guid AddCustomer(Customer customer)
        {
            try
            {

                //get all customers
                List<Customer> allCustomers = CustomerDataAccessLayer.GetCustomers();

                long maxCustCode = 0;

                foreach(Customer item in allCustomers)//have to do this like that and not with count as customers might be removed and we never decrease the actual counter of the ID
                {
                    if(item.CustomerCode>maxCustCode)
                    {
                        maxCustCode = item.CustomerCode;
                    }
                }
                //genereate customer number
                if(allCustomers.Count>=1)
                {
                    customer.CustomerCode = maxCustCode + 1;
                }
                else
                {
                    customer.CustomerCode = YanivBank.Configuration.Settings.BaseCustomerNo + 1;
                }
                
                //invoke DAL
               return CustomerDataAccessLayer.AddCustomer(customer);

            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// updates customer, returns true if successful
        /// </summary>
        /// <param name="customer">the customer DETAILS to update</param>
        /// <returns></returns>
        public bool UpdateCustomer(Customer customer)
        {
            

            try
            {
                //invoke DAL
                return CustomerDataAccessLayer.UpdateCustomer(customer);

            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// deletes customer, returns true if successful
        /// </summary>
        /// <param name="customerId">the customer ID to delete</param>
        /// <returns></returns>
        public bool DeleteCustomer(Guid customerId)

        {
            try
            {
                //invoke DAL
                return CustomerDataAccessLayer.DeleteCustomer(customerId);

            }
            catch (CustomerException)
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
