using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpTest.extensionMethods
{
    public static class ExtensionMethods
    {
        /* extend the RestClient to include a way to get the Response Time
         * 
         * 
         * 
         */
        public static async Task<(RestResponse r, TimeSpan t)> GetClientResponseWithTimeSpan(this RestClient restClient, RestRequest request)
        {
            Stopwatch timer = Stopwatch.StartNew();
            RestResponse restResponse = await restClient.ExecuteAsync(request);
            timer.Stop();
            return (restResponse, timer.Elapsed);
        }
    }
}
