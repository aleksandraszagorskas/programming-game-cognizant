using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ProgrammingGame.App.Services
{
    public class ChallengeService
    {
        public ChallengeService()
        {

        }

        public async Task<HttpResponseMessage> SubmitTask()
        {
            var clientId = "99c27a137808f59397fce5d86177495a";
            var clientSecret = "34ebdb23968d053efac301b6934d07ca98b0fa871a0388bf7a39a59fccc2759e";
            var script = @"
                using System;
                class Program
                {
                    static void Main(string[] args) {
                        //Your code goes here
                        Console.WriteLine(""Hello World!"");
                    }
                }
            ";
            var language = "csharp";
            var versionIndex = "0";

            try
            {
                using (var client = new HttpClient())
                {
                    var input = @$"{{
                        ""clientId"": ""{clientId}"", 
                        ""clientSecret"": ""{clientSecret}"",
                        ""script"": ""{HttpUtility.JavaScriptStringEncode(script)}"",
                        ""language"": ""{language}"",
                        ""versionIndex"": ""{versionIndex}"" 
                    }}";

                    var content = new StringContent(input, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync("https://api.jdoodle.com/v1/execute", content);

                    return response;
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
