using System;
using System.Collections.Generic;
using Bank.Entities;

namespace Bank.DataAccessLayer.DALContracts
{
    /// <summary>
    /// this interface represents customer data access layer CRUD operations
    /// </summary>
     public interface ICustomerDataAccessLayer
    {
        /// <summary>
        /// returns all existing customers
        /// </summary>
        /// <returns></returns>
        List<Customer> GetCustomers();

        /// <summary>
        /// returns all customers that meet the given condition (predicate)
        /// </summary>
        /// <param name="predicate">;ambda expression that gives condition to check</param>
        /// <returns></returns>
        List<Customer>GetCustomerByCondition(Predicate<Customer> predicate);

        /// <summary>
        /// creates GUID for customer we want to add, and adds customer to list
        /// </summary>
        /// <param name="customer">the customer object to add</param>
        /// <returns></returns>
        Guid AddCustomer (Customer customer);   

        /// <summary>
        /// updates customer, returns true if successful
        /// </summary>
        /// <param name="customer">the customer DETAILS to update</param>
        /// <returns></returns>
        bool UpdateCustomer(Customer customer);
        /// <summary>
        /// deletes customer, returns true if successful
        /// </summary>
        /// <param name="customerId">the customer ID to delete</param>
        /// <returns></returns>
        bool DeleteCustomer(Guid customerId);
    }
}
