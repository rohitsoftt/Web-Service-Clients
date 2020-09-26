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
        private string url;
        /// <summary>
        /// URL
        /// </summary>
        /// <exception cref="InvalidURLException">If URL is has invalid format</exception>
        public string URL { 
            get{
                return url;
            }
            set{
                if (value.IsURL())
                {
                    url = value;
                }
                else
                {
                    throw new InvalidURLException("URL is invalid");
                }
            } 
        }
        /// <summary>
        /// Request Headers
        /// </summary>
        public readonly Dictionary<string, string> Headers;
        /// <summary>
        /// Initializes a new instance of the REST.API.Client.Request Request class
        /// </summary>
        /// <param name="url"></param>
        /// <param name="headers"></param>
        /// <exception cref="InvalidURLException">If URL has invalid format</exception>
        public Request(string url, Dictionary<string, string> headers)
        {
            this.URL = url;
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

        public async Task<HttpResponseMessage> GetAsync(Dictionary<string, string> queryParam)
        {
            HttpClient client = new HttpClient();
            client.AddHeaders(Headers);
            client.AddJsonHeader();
            string query;
            using (var content = new FormUrlEncodedContent(queryParam)){
                query = await content.ReadAsStringAsync();
            }
            var newURL = "";
            if (URL.EndsWith("/") || URL.EndsWith("\\"))
            {
                newURL = URL.Substring(0, URL.Length - 1);
            }
            else
            {
                newURL = URL;
            }
            string queryURL = $"{newURL}?{query}";
            var response = await client.GetAsync(queryURL);
            return response;
        }

        /// <summary>
        /// Set URL
        /// </summary>
        /// <param name="url"></param>
        public void SetURL(string url)
        {
            this.URL = url;
        }
    }
}
