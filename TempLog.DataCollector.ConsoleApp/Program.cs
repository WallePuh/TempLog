using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TempLog.TdTool;
using TempLog.TdTool.Ssh;
using System.Configuration;

namespace TempLog.DataCollector.ConsoleApp
{
    class Program
    {
        public static string HttpBaseAddress { get { return ConfigurationManager.AppSettings["HttpBaseAddress"]; } }

        static void Main(string[] args)
        {
            ITdToolClient tdToolClient = new SshClient();
            var listResult = tdToolClient.GetListResult();

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(HttpBaseAddress);

            // Add an Accept header for JSON format.
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            foreach (var sensorResult in listResult.SensorResults)
            {
                var response = httpClient.PostAsJsonAsync("api/measurement", sensorResult).Result;

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
                else
                {
                    Console.WriteLine("{0} - {1} : DONE", response.RequestMessage.RequestUri, sensorResult.SensorId);
                }
            }
        }
    }
}
