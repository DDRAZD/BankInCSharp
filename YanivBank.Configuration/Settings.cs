using System;


namespace YanivBank.Configuration
{
    /// <summary>
    /// project level configruation seetings
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// custmers number starts from 1001; incremented by 1
        /// </summary>
        public static long BaseCustomerNo { get; set; } = 1000;

        /// <summary>
        /// account number starts at 2000 and incremeneted by 1; never drops; hence always unique
        /// </summary>
        public static long BasicAccountNumber { get; set; } = 2000;
    }
}
