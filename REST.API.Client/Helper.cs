using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST.API.Client
{
    /// <summary>
    /// Helper class
    /// </summary>
    internal static class Helper
    {
        /// <summary>
        /// To check null or empty value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string CheckNull(this string value)
        {
            if(string.IsNullOrEmpty(value.Trim(' ')))
            {
                return null;
            }
            return value;
        }
        /// <summary>
        /// To check URL format is valid or not
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool IsURL(this string url)
        {
            bool result = false;
            if(url.Contains("http://") || url.Contains("https://"))
            {
                result = true;
            }
            return result;
        }
    }
}
