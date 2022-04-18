using System;
using System.Collections.Generic;
using YanivBank.Exceptions;
using YanivBank.Entities;
using YanivBank.BusinessLogicLayer.BALContracts;
using YanivBank.BusinessLogicLayer;
using YanivBank.BusinessLogicLayer.BLContracts;

namespace YanivBank.PresentationLayer
{/// <summary>
/// static class that allows to call the presentation layer for accounts
/// </summary>
     internal static class AccountPresntations
    {
            

        

        

        /// <summary>
        /// interacts with the user to add an account
        /// </summary>
        internal  static void AddAccount()
        {
            Console.WriteLine("Please provide your customer code: ");
            long customerCode = long.Parse(Console.ReadLine());
           
            ICustomerBusinessLogicLayer CustomerBusinessLogicLayer = new CustomersBusinessLogicLayer();  
            IAccountBusinessLogicLayer AccountBusinessLogicLayer = new AccountsBusinessLogicLayer();

            List<Customer> currentCustomer = CustomerBusinessLogicLayer.GetCustomerByCondition(item=>item.CustomerCode == customerCode);

            AccountBusinessLogicLayer.OpenAccount(currentCustomer);


        }
        /// <summary>
        /// interacts with the customer to delete an account
        /// </summary>
        internal  static void DeleteAccount()
        {
            
            

            Console.WriteLine("please provide account to delete");
            long accountCode = long.Parse(Console.ReadLine());
            //ICustomerBusinessLogicLayer CustomerBusinessLogicLayer = new CustomersBusinessLogicLayer();
            IAccountBusinessLogicLayer AccountBusinessLogicLayer = new AccountsBusinessLogicLayer();
            AccountBusinessLogicLayer.CloseAccount(accountCode);

        }
        
        
    }
}
