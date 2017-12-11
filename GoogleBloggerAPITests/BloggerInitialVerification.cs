using System;
using System.Net;
using Newtonsoft.Json.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//We are going to use only public data so users can verify. TO accomplish this, we will use only APIKEY.

namespace GoogleBloggerAPITests
{
    [TestClass]
    public class BloggerInitialVerification
    {
        //Some required variables
        const string key = "AIzaSyA6mCnYHn3E-KzgOsQ31B0lWDTRORkVLx4";
        const string endPoint = "https://www.googleapis.com/blogger/v3/";
        const string blogID = "2018816985818355058";
        string reffUrlForGetBlogger = "blogs/" + blogID + "?key=" + key;
        String jsonString = String.Empty;

        [TestMethod]
        public void getBlogs()
        {
            using (var webClient = new WebClient())
            {
                webClient.BaseAddress = endPoint;
                try
                {
                    jsonString = webClient.DownloadString(reffUrlForGetBlogger);

                    JObject response = JObject.Parse(jsonString);

                    //Assert Response with kind, name, url, and total posts avialable.
                    Assert.AreEqual("blogger#blog", (string)response["kind"]);
                    Assert.AreEqual("CAQ1", (string)response["name"]);
                    Assert.AreEqual("http://caq10.blogspot.com/", (string)response["url"]);
                    Assert.AreEqual(1, (int)response["posts"]["totalItems"]);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                
            }       
        }
    }
}
