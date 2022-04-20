using System;
using System.Collections.Generic;


namespace Bank.Exceptions
{/// <summary>
/// class that provides transfers / transaction level exceptions 
/// </summary>
    public class TransferExceptions:ApplicationException
    {

        #region Constructors
        /// <summary>
        /// constructor of the accounte exception entity; recevives the message thrown
        /// </summary>
        /// <param name="message">exception message</param>
        public TransferExceptions(string message) : base(message)
        {

        }
        /// <summary>
        /// constrcuttor that intitializes the message and inner exception
        /// </summary>
        /// <param name="message">message</param>
        /// <param name="InnerException">inner exception</param>
        public TransferExceptions(string message, Exception InnerException) : base(message, InnerException)
        {

        }


        #endregion

    }
}
