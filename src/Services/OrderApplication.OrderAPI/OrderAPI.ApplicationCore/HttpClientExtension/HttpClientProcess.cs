using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.ApplicationCore.HttpClientExtension
{
    public static class HttpClientProcess
    {
        public static async Task<JObject> GetCustomerData(HttpClient client)
        {
            var result = await client.GetAsync(client.BaseAddress.AbsoluteUri);

            var readResult = await result.Content.ReadAsStringAsync();

            var resultObject = (JObject)JsonConvert.DeserializeObject(readResult);

            return resultObject;
        }
    }
}
