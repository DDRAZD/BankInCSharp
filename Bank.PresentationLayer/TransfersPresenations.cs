using System;
using System.Collections.Generic;
using System.Linq;
using Bank.BusinessLogicLayer.BALContracts;
using Bank.BusinessLogicLayer;
using Bank.Entities;


namespace Bank.PresentationLayer
{
    /// <summary>
    /// this class implements the presenation for transfers
    /// </summary>
    internal static class TransfersPresenations
    {
        /// <summary>
        /// transfers amounts between acccounts
        /// </summary>
        internal static void FundTransfer()
        {
            Console.WriteLine("Please enter the account ID from which you want to transfer funds out of: ");
            long accountIDFrom = long.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the account ID from which you want to transfer funds into: ");
            long accountIDTo = long.Parse(Console.ReadLine());
            Console.WriteLine("please enter the amount you wish to transfer (positive nummbers only): ");
            decimal amount = decimal.Parse(Console.ReadLine());

            //creating the business logic layer
            ITransfersBusinessLogicLayer TransferBusinessLogicLayer = new TransferBusinessLogicLayer();

            TransferBusinessLogicLayer.TransferFunds(accountIDFrom, accountIDTo, amount);
            
        }

        internal static void PrintAllTransfers()
        {

            

            //creating the business logic layer
            ITransfersBusinessLogicLayer TransferBusinessLogicLayer = new TransferBusinessLogicLayer();

           List<Transfers> transfersToPrint= TransferBusinessLogicLayer.GetTransfer();

            foreach (Transfers transfers in transfersToPrint)
            {
                Console.WriteLine(transfers.AccountIDFrom + " " + transfers.AccountIDTo+" "+transfers.TransferDateTime+" "+transfers.AmountTransfered);
            }
        }

        internal static void PrintAllAccountTransfers()
        {
            Console.WriteLine("Please type the account ID you wish to print transfers of: ");
            long accountID = long.Parse(Console.ReadLine());

            //creating the business logic layer
            ITransfersBusinessLogicLayer TransferBusinessLogicLayer = new TransferBusinessLogicLayer();

            List<Transfers> transfersToPrint = TransferBusinessLogicLayer.GetTransferByAccount(accountID);
            foreach (Transfers transfers in transfersToPrint)
            {
                Console.WriteLine(transfers.AccountIDFrom + " " + transfers.AccountIDTo + " " + transfers.TransferDateTime + " " + transfers.AmountTransfered);
            }

        }

    }
}
