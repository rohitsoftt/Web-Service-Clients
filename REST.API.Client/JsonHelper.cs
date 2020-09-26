using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace REST.API.Client
{
    /// <summary>
    /// Json helper class
    /// </summary>
    public static class JsonHelper
    {
        /// <summary>
        /// returns StringContent 
        /// </summary>
        /// <param name="content">Object of any class</param>
        /// <returns>returns System.Net.Http.StringContent</returns>
        public static StringContent GetJsonContent(this object content)
        {
            var jsonsetting = GetSerializeSetting();
            string json = JsonConvert.SerializeObject(content, jsonsetting);
            var httpcontent = new StringContent(json, Encoding.UTF8, "application/json");
            return httpcontent;
        }
        /// <summary>
        /// Deserialization of json object
        /// </summary>
        /// <typeparam name="T">JSON string</typeparam>
        /// <param name="data"></param>
        /// <returns>Specified class object</returns>
        public static T DeserializeObject<T>(this string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }
        /// <summary>
        /// Serialization of give object into string
        /// </summary>
        /// <param name="value">Object of class</param>
        /// <returns>JSON string</returns>
        public static string SerializeObject(object value)
        {
            return JsonConvert.SerializeObject(value, GetSerializeSetting());
        }
        /// <summary>
        /// Json Serializer Settings
        /// </summary>
        /// <returns>Returns Newtonsoft.Json.JsonSerializerSettings</returns>
        internal static JsonSerializerSettings GetSerializeSetting()
        {
            return new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                },
                Formatting = Formatting.Indented
            };
        }
        /// <summary>
        /// ResponseBodyObject by Deserializing response body
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="responseMessage"></param>
        /// <returns></returns>
        public static async Task<T> ResponseBodyObjectAsync<T>(this HttpResponseMessage responseMessage)
        {
            string dataString = await responseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(dataString);
        }
    }
}
