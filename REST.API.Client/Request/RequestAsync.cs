using REST.API.Client.Exceptions;
using REST.API.Client.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace REST.API.Client.Request
{
    /// <summary>
    /// Request 
    /// </summary>
    public partial class Request
    {
        /// <summary>
        /// URL
        /// </summary>
        public readonly string URL;
        /// <summary>
        /// Request Headers
        /// </summary>
        public readonly Dictionary<string, string> Headers;
        /// <summary>
        /// Initializes a new instance of the REST.API.Client.Request Request class
        /// </summary>
        /// <param name="url"></param>
        /// <param name="headers"></param>
        /// <exception cref="InvalidURLException"></exception>
        public Request(string url, Dictionary<string, string> headers)
        {
            if (url.IsURL())
            {
                this.URL = url;
            }
            else
            {
                throw new InvalidURLException("URL is invalid");
            }
            this.Headers = headers;
        }
        /// <summary>
        /// POST method
        /// </summary>
        /// <param name="data"></param>
        /// <returns>the tsk object representing the asynchronus operation</returns>
        public async Task<HttpResponseMessage> PostAsync(object data)
        {
            HttpClient client = new HttpClient();
            StringContent httpContent = data.GetJsonContent();
            client.AddHeaders(Headers);
            client.AddJsonHeader();
            var response = await client.PostAsync(URL, httpContent);
            return response;
        }
        /// <summary>
        /// GET method
        /// </summary>
        /// <returns>the tsk object representing the asynchronus operation</returns>
        public async Task<HttpResponseMessage> GetAsync()
        {
            HttpClient client = new HttpClient();
            client.AddHeaders(Headers);
            client.AddJsonHeader();
            var response = await client.GetAsync(URL);
            return response;
        }
    }
}
