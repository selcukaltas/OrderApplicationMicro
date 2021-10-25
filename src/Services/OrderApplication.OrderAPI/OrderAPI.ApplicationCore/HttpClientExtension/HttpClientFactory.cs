using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.ApplicationCore.HttpClientExtension
{
    public static class HttpClientFactory
    {

        public static HttpClient Get(string url)
        {
            var result = new HttpClient()
            {
                BaseAddress = new Uri(url),

            };
            result.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/94.0.4606.81 Safari/537.36 Edg/94.0.992.50");
            return result;
        }
    }
}
