using System;
using System.Collections.Generic;
using YanivBank.Entities;
using YanivBank.Exceptions;
using YanivBank.BusinessLogicLayer;
using YanivBank.BusinessLogicLayer.BLContracts;

namespace YanivBank.PresentationLayer
{
    /// <summary>
    /// static class that represents the customer presentation; no need to instanciate it as static
    /// </summary>
    static class CustomerPresntations
    {

        internal static void AddCustomer()
        {

            try
            {
                Customer customer = new Customer();

                //read all details from user
                Console.WriteLine("\n*******ADD Customer*******");
                Console.WriteLine("Customer Name: ");
                customer.CustomerName = Console.ReadLine();
                Console.WriteLine("Customer Address: ");
                customer.Address = Console.ReadLine();

                Console.WriteLine("Customer City: ");
                customer.City = Console.ReadLine();

                Console.WriteLine("Customer Landmark: ");
                customer.Landmark = Console.ReadLine();

                Console.WriteLine("Customer Country: ");
                customer.Country = Console.ReadLine();

                Console.WriteLine("Customer Mobile: ");
                customer.Mobile = Console.ReadLine();
                //calling the business logic layer (creating it)
                ICustomerBusinessLogicLayer customerBusinessLogicLayer = new CustomersBusinessLogicLayer();

               Guid newGUid= customerBusinessLogicLayer.AddCustomer(customer);
              List<Customer> matchingCustomer = customerBusinessLogicLayer.GetCustomerByCondition(item=>item.CustomerID == newGUid);
                if (matchingCustomer.Count > 0)
                {
                    Console.WriteLine("New Customer Code " +matchingCustomer[0].CustomerCode);
                }
                else
                {
                    Console.WriteLine("Customer not added");
                }

                Console.WriteLine(newGUid);
                Console.WriteLine("Customer added.\n");

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
            
           
           
        }
        /// <summary>
        /// used to view customers pulling via BL into DAL
        /// </summary>
        internal static void  ViewCustomers()
        {

            try
            {
                ICustomerBusinessLogicLayer customersBusinessLogicLayer = new CustomersBusinessLogicLayer();

               List<Customer> custoemrsList = customersBusinessLogicLayer.GetCustomers();
                foreach (Customer customer in custoemrsList)
                {
                    Console.WriteLine("Customer Code " +customer.CustomerCode);

                    Console.WriteLine("Customer name " + customer.CustomerName);

                    Console.WriteLine("Customer address " + customer.Address);

                    Console.WriteLine("Customer landmark " + customer.Landmark);

                    Console.WriteLine("Customer city " + customer.City);

                    Console.WriteLine("Customer Country " + customer.Country);

                    Console.WriteLine("Customer mobile " + customer.Mobile);

                    Console.WriteLine();
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }
        /// <summary>
        /// edits customer received by user; useses the customer code (4 digits) to call the business logic that calls the DAL
        /// </summary>
        internal static void EditCustomer()
        {
            try
            {
                ICustomerBusinessLogicLayer customersBusinessLogicLayer = new CustomersBusinessLogicLayer();

                Console.WriteLine("Please provide Customer code for the customer you wish to update: ");
                long customerCode = long.Parse(Console.ReadLine());
                Customer customerUpdate = new Customer();
                customerUpdate.CustomerCode = customerCode;
                Console.WriteLine("Customer Name: ");
                customerUpdate.CustomerName = Console.ReadLine();
                Console.WriteLine("Customer Address: ");
                customerUpdate.Address = Console.ReadLine();

                Console.WriteLine("Customer City: ");
                customerUpdate.City = Console.ReadLine();

                Console.WriteLine("Customer Landmark: ");
                customerUpdate.Landmark = Console.ReadLine();

                Console.WriteLine("Customer Country: ");
                customerUpdate.Country = Console.ReadLine();

                Console.WriteLine("Customer Mobile: ");
                customerUpdate.Mobile = Console.ReadLine();
                bool result = customersBusinessLogicLayer.UpdateCustomer(customerUpdate);

                Console.WriteLine(result);
                Console.ReadKey();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }

        }
        /// <summary>
        /// deletes a customer based on customer code received from user
        /// </summary>
        internal static void DeleteCustomer()
        {
            try
            {
                Console.WriteLine("Please enter the customer code for the customer you wish to delete: ");
                long customerCode = long.Parse(Console.ReadLine());

                //instaniate the business logic so you have something to work with
                ICustomerBusinessLogicLayer customersBusinessLogicLayer = new CustomersBusinessLogicLayer();

                List<Customer> customerToDelete = customersBusinessLogicLayer.GetCustomerByCondition(item => item.CustomerCode == customerCode);

                foreach (Customer customerToDeleteItem in customerToDelete)
                {
                    customersBusinessLogicLayer.DeleteCustomer(customerToDeleteItem.CustomerID);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }

        }
    }
}
