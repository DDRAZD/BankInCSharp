using Bank.PresentationLayer;
using System;

class Program
{

    static void Main()
    {
        //display title

        System.Console.WriteLine("--------Test Bank------");
        System.Console.WriteLine("Enter User Name And password");
        string userName = null;
        string password = null;

        

        System.Console.Write("Username: ");
        //read login
        userName = System.Console.ReadLine();

        if (userName != "")
        {         //read password from keyboard
            System.Console.Write("Password: ");
            password = System.Console.ReadLine();
        }

        //check user name and passwrod
        if (userName == "system" && password == "manager")
        {
            int mainMenuChoice = -10;
            do 
            { 
            System.Console.WriteLine("\nMain Menu");
            System.Console.WriteLine("1.Customers");
            System.Console.WriteLine("2.Accounts");
            System.Console.WriteLine("3.Funds Transfer");
            System.Console.WriteLine("4.Funds Transfer Statement");
            System.Console.WriteLine("5.Account Statement");
            System.Console.WriteLine("0.Exit");
            System.Console.WriteLine("Enter Choice: ");
            mainMenuChoice = int.Parse(System.Console.ReadLine());

                switch (mainMenuChoice)
                {
                    case 1: CustomersMenue();break; 
                    case 2: AccountsMenu();  break;
                    case 3: TransfersPresenations.FundTransfer(); break;
                    case 4: TransfersPresenations.PrintAllTransfers(); break;                        
                    case 5: TransfersPresenations.PrintAllAccountTransfers(); break;
                                        }
            
            } while (mainMenuChoice != 0);
        }
        else
        {
            System.Console.WriteLine("Invalid Login");
        }
        //about to exit
        System.Console.WriteLine("Thank you for your visit!");
        System.Console.ReadKey();

        
    }
    static void CustomersMenue()
    {
        int CustomerMenuChoice = -1;
        //do loop starts
        do
        {
            //print the customer menu
            System.Console.WriteLine("\nCustmers Menu");
            System.Console.WriteLine("1. Add Customer");
            System.Console.WriteLine("2. Delete Customer");
            System.Console.WriteLine("3. Update Customer");
            System.Console.WriteLine("5. View Customer");
            System.Console.WriteLine("0. Bank to Main menue");

            System.Console.Write("Enter Choice: ");
            CustomerMenuChoice = System.Convert.ToInt32(System.Console.ReadLine());


            //swtich case

            switch(CustomerMenuChoice)
            {
                case 1: CustomerPresntations.AddCustomer();break;
                case 2: CustomerPresntations.DeleteCustomer(); break;
                case 3: CustomerPresntations.EditCustomer(); break;
                case 5: CustomerPresntations.ViewCustomers();break;
            }
        } while(CustomerMenuChoice != 0);

    }
    static void AccountsMenu()
    {
        int AccountMenuChoice = -1;
        
        //do loop starts
        do
        {
            //print the accounts menu
            System.Console.WriteLine("\nAccounts Menu");
            System.Console.WriteLine("1. Add Account");
            System.Console.WriteLine("2. Delete Account");
            System.Console.WriteLine("3. Update Account");
            System.Console.WriteLine("4. View Account");
            System.Console.WriteLine("0. Bank to Main menue");

            System.Console.Write("Enter Choice: ");
            AccountMenuChoice = System.Convert.ToInt32(System.Console.ReadLine());


            switch (AccountMenuChoice)
            {
                case 1: AccountPresntations.AddAccount(); break;
                case 2: AccountPresntations.DeleteAccount(); break;
                case 3: AccountPresntations.UpdateAccount(); break;
                case 4: AccountPresntations.ViewAccount(); break;
               
            }

        } while (AccountMenuChoice != 0);

    }

    
}