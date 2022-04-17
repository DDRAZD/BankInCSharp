using System;
using System.Collections.Generic;
using YanivBank.Entities;
using YanivBank.Exceptions;
using YanivBank.DataAccessLayer.DALContracts;

namespace YanivBank.DataAccessLayer
{
    /// <summary>
    /// repressts DAL for banks custoemrs (just like a database)
    /// </summary>
    public class CustomerDataAccessLayer : ICustomerDataAccessLayer
    {

        #region Fields
        private static List<Customer> _customers;

        #endregion

        #region Constructors
         static CustomerDataAccessLayer()
        {
            _customers = new List<Customer>();   
        }
        #endregion


        #region Properties

        private static List<Customer> Customers 
        { 
            set => _customers = value;
            get => _customers;
        }

        #endregion

        #region Methods

        /// <summary>
        /// returns a close of existing customer list
        /// </summary>
        /// <returns>customer list clone</returns>
        public List<Customer> GetCustomers()
        {
            try
            {
                List<Customer> customersList = new List<Customer>();

                Customers.ForEach(item => customersList.Add(item.Clone() as Customer));
                return customersList;

            }
            catch(CustomerException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;   
            }
            


        }
        /// <summary>
        /// returns a list of customer that meet a conditiion (a predicate)
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>customer list</returns>
        public List<Customer> GetCustomerByCondition(Predicate<Customer> predicate)
        {
           try
            {
                List<Customer> customersList = new List<Customer>();

                //filter the collection
                

                 List<Customer> filteredCustomers = Customers.FindAll(predicate);

                filteredCustomers.ForEach(item => customersList.Add(item.Clone() as Customer));

                                             

                return customersList;

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
        /// adds customer to the list of custoemrs
        /// </summary>
        /// <param name="customer">custoemrs object to add</param>
        /// <returns>new customers ID</returns>
        public Guid AddCustomer(Customer customer)
        {
            try
            {
                Guid guid = Guid.NewGuid();
                customer.CustomerID = guid;
                Customers.Add(customer);
                return guid;
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
        /// updates exsiting customer BASED ON EXISITING CUSTOMER UNIQUE ID
        /// </summary>
        /// <param name="customer">update details</param>
        /// <returns>erturns true if update was successful</returns>
        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                //find existing customer by CustomerID
                Customer existingCustomer = Customers.Find(item => item.CustomerCode == customer.CustomerCode);

                //update all details of customer
                if (existingCustomer != null)
                {
                    existingCustomer.CustomerID = customer.CustomerID;
                    existingCustomer.CustomerName = customer.CustomerName;
                    existingCustomer.Address = customer.Address;
                    existingCustomer.Landmark = customer.Landmark;
                    existingCustomer.City = customer.City;
                    existingCustomer.Country = customer.Country;
                    existingCustomer.Mobile = customer.Mobile;

                    return true; //indicates the customer is updated
                }
                else
                {
                    return false; //indicates no object is updated
                }
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
        /// deletes a customer fromt the list
        /// </summary>
        /// <param name="customerId">the id of the customer to remove</param>
        /// <returns>returns true if deletion was successful</returns>
        public bool DeleteCustomer(Guid customerId)
        {
            try
            {

                if (Customers.RemoveAll(item => item.CustomerID == customerId) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

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
