using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSharpSelFramework.Utilities
{
    public class jsonreader
    {
        public jsonreader()
        {
        }
        public void extractData()
        {
            //json dosyasını ulaştık
           var myJsonString= File.ReadAllText("Utilities/testData.json");
            //jsonu parse ettik
           var jsonObject= JToken.Parse(myJsonString);
            //username string şekilde ekrana bastık 
           Console.WriteLine(jsonObject.SelectToken("username").Value<string>());
        }
    }
}
