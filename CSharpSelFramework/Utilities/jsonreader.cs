using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharpSelFramework.Utilities
{
    public class JsonReader
    {
        public JsonReader()
        {
        }
        public string extractData(string tokenName)
        {
            //json dosyasını ulaştık
           var myJsonString= File.ReadAllText("Utilities/testData.json");
            //jsonu parse ettik
           var jsonObject= JToken.Parse(myJsonString);
            //username string şekilde ekrana bastık 
          return jsonObject.SelectToken(tokenName).Value<string>();
        }

        public string[] extractDataArray(string tokenName)
        {
            //json dosyasını ulaştık
            var myJsonString = File.ReadAllText("Utilities/testData.json");
            //jsonu parse ettik
            var jsonObject = JToken.Parse(myJsonString);
            //username string şekilde ekrana bastık 
           List<string> productsList= jsonObject.SelectToken(tokenName).Values<string>().ToList();
           return productsList.ToArray();
        }
    }
}
