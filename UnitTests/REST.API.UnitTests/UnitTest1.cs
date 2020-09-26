using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using REST.API.Client.Request;

namespace REST.API.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("secretkey", "token");
            Request request = new Request("http://example.com/unitTest", dictionary);

            var result = request.PostAsync(new Data
            {
                Subject = "Unit Test",
                HtmlBody = "<b> Welcome Unit Test</b>"
            }).Result;
            Console.WriteLine(result.StatusCode);
        }
    }

    public class Data
    {
        public string Subject { get; set; }
        public string HtmlBody { get; set; }
        public string TextBody { get; set; }
    }
}
