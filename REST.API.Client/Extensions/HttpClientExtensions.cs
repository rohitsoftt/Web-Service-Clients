using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace REST.API.Client.Extensions
{
    /// <summary>
    /// HttpClientExtensions
    /// </summary>
    internal static class HttpClientExtensions
    {
        /// <summary>
        /// Add headers in HttpClient
        /// </summary>
        /// <param name="client"></param>
        /// <param name="headers"></param>
        internal static void AddHeaders(this HttpClient client, Dictionary<string, string> headers)
        {
            foreach (string key in headers.Keys)
            {
                headers.TryGetValue(key, out string value);
                client.DefaultRequestHeaders.Add(key, value);
            }
        }
        /// <summary>
        /// JSON Header
        /// </summary>
        /// <param name="client"></param>
        internal static void AddJsonHeader(this HttpClient client)
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
