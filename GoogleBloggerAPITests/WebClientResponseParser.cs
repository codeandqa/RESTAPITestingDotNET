using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GoogleBloggerAPITests
{
    public class WebClientResponseParser
    {
        //private string response;
        JObject parsedResponse = null;

        public WebClientResponseParser(string reponse)
        {
            

        }

        public static string ConvertResponseIntoList(string response, params string[] parameters)
        {
            JObject parsedParams = JObject.Parse(response);
            foreach (var item in parameters)
            {

            }

            return "";
        }
    }
}
