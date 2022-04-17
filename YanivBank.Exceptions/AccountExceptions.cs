using System;
using System.Collections.Generic;


namespace YanivBank.Exceptions
{
    /// <summary>
    /// this class is for all account entity exceptions such as negative account number, no owner etc
    /// </summary>
     public class AccountException:ApplicationException
     {




        #region Constructors
        /// <summary>
        /// constructor of the accounte exception entity; recevives the message thrown
        /// </summary>
        /// <param name="message">exception message</param>
        public AccountException(string message):base(message)
        {

        }
        /// <summary>
        /// constrcuttor that intitializes the message and inner exception
        /// </summary>
        /// <param name="message">message</param>
        /// <param name="InnerException">inner exception</param>
        public AccountException(string message, Exception InnerException):base( message, InnerException)
        {

        }
        #endregion
    }


}
