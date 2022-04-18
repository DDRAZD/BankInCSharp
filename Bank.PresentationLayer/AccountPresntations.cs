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

            Console.WriteLine("Account number added: "+AccountBusinessLogicLayer.OpenAccount(currentCustomer));


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
        /// <summary>
        /// updates an existing account; beyond transfering money, only things to update in an accoout is owners
        /// </summary>
        internal static void UpdateAccount()
        {
            //instansiates the business logic for accounts
            IAccountBusinessLogicLayer AccountBusinessLogicLayer = new AccountsBusinessLogicLayer();
            int customerSelection = 0;

            do {
                Console.WriteLine("Please select 1 to add an owner or 2 to remove an owner: ");
                customerSelection = int.Parse(Console.ReadLine());
            } while (customerSelection != 1 && customerSelection != 2);


            //instansiates the customer BAL

            ICustomerBusinessLogicLayer CustomerBusinessLogicLayer = new CustomersBusinessLogicLayer();
            long accountID, customerCode;
            Console.WriteLine("please enter your customer code");
            customerCode = long.Parse(Console.ReadLine());
            Console.WriteLine("please enter account code to update");
            accountID = long.Parse(Console.ReadLine());

            List<Customer> customerList;
            customerList = CustomerBusinessLogicLayer.GetCustomerByCondition(item => item.CustomerCode == customerCode);
            //it assumes customer exists
            if (customerSelection ==1) { AccountBusinessLogicLayer.AddOwner(customerList[0], accountID); }
            else { AccountBusinessLogicLayer.RemoveOwner(customerList[0], accountID); }

        }

        internal static void ViewAccount()
        {
            //instansiates the business logic for accounts
            IAccountBusinessLogicLayer AccountBusinessLogicLayer = new AccountsBusinessLogicLayer();
            ICustomerBusinessLogicLayer CustomerBusinessLogicLayer = new CustomersBusinessLogicLayer();
            long accountID, customerCode;

            Console.WriteLine("please enter your customer code");
            customerCode = long.Parse(Console.ReadLine());

           List<Accounts> accounts= AccountBusinessLogicLayer.GetACcountsWithCondition(item=> item.AccountOwnerList[0].CustomerCode==customerCode);

            foreach (Accounts account in accounts) { Console.WriteLine(account.AccountId + ", "); }

        }



    }
}
