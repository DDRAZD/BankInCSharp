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
    }
}
