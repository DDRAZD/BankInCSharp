using System;
using System.Collections.Generic;


namespace YanivBank.Exceptions
{
    /// <summary>
    /// this is an exception class; represents error raised in validation
    /// </summary>
    
    public class CustomerException:ApplicationException
    {
        /// <summary>
        /// constructor classes initializes exception messages
        /// </summary>
        /// <param name="message">excetion message</param>
        public CustomerException(string message):base(message)
        {

        }
        /// <summary>
        /// constructor that initlaizes the message and inner exception
        /// </summary>
        /// <param name="message">exception message</param>
        /// <param name="InnerException">inner exception</param>
        public CustomerException(string message, Exception InnerException):base(message, InnerException)
        {

        }
            

    }
}
