using System;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using Microsoft.CSharp;
using Newtonsoft.Json.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
//We are going to use only public data so users can verify. TO accomplish this, we will use only APIKEY.

namespace GoogleBloggerAPITests
{
    [TestClass]
    public class Frst
    {
        //Some required variables
        const string key = "AIzaSyA6mCnYHn3E-KzgOsQ31B0lWDTRORkVLx4";
        const string endPoint = "https://www.googleapis.com/blogger/v3/";
        const string blogID = "2018816985818355058";
        string jsonString = String.Empty;
        [TestMethod]
        public void getBlogs()
        {
            using (var webClient = new WebClient())
            {
                webClient.BaseAddress = endPoint;
                try
                {
                    jsonString = webClient.DownloadString("blogs/" + blogID + "?key=" + key);
                    JObject rss = JObject.Parse(jsonString);
                    string rssTitle = (string)rss["posts"]["totalItems"];
                    Assert.AreEqual("1", rssTitle);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
                
            }       
        }
    }
}
