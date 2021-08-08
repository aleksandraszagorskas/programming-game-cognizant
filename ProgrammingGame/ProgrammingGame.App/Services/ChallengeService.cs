using Newtonsoft.Json.Linq;
using ProgrammingGame.App.DTO;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ProgrammingGame.App.Services
{
    public class ChallengeService : IChallengeService
    {
        public async Task<TaskSubmitResultDto> SubmitTaskAsync(string scriptString)
        {
            var clientId = "99c27a137808f59397fce5d86177495a";
            var clientSecret = "34ebdb23968d053efac301b6934d07ca98b0fa871a0388bf7a39a59fccc2759e";
            var language = "csharp";
            var versionIndex = "0";

            try
            {
                using (var client = new HttpClient())
                {
                    var input = @$"{{
                        ""clientId"": ""{clientId}"", 
                        ""clientSecret"": ""{clientSecret}"",
                        ""script"": ""{HttpUtility.JavaScriptStringEncode(scriptString)}"",
                        ""language"": ""{language}"",
                        ""versionIndex"": ""{versionIndex}"" 
                    }}";

                    var content = new StringContent(input, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync("https://api.jdoodle.com/v1/execute", content);

                    return await ParseResponse(response);
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private async Task<TaskSubmitResultDto> ParseResponse(HttpResponseMessage response)
        {
            var result = await response.Content.ReadAsStringAsync();
            dynamic jobj = JObject.Parse(result);

            var output = ((string)jobj.output)?.Replace("\n", "").Replace("\r", "");
            var time = ((string)jobj.cpuTime)?.Replace("\n", "").Replace("\r", "");

            return new TaskSubmitResultDto { Output = output, Time = time };
        }
    }
}
