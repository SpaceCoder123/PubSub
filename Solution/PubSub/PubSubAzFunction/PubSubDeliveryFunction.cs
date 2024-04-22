using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Text;
using System;
using System.Threading.Tasks;

namespace PubSubAzFunction
{
    public class PubSubDeliveryFunction
    {
        private readonly IConfiguration _config;
        private HttpClient _httpClient;

        public PubSubDeliveryFunction(IConfiguration config, HttpClient httpClient)
        {
            _config = config;
            _httpClient = httpClient;
        }

        [FunctionName("PubSubDeliveryFunction")]
        public async Task Run([ServiceBusTrigger("%ServiceBusQueueName%", Connection = "ServiceBusConnectionString")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
            string apiUrl = ConstantsConnections.LocalIISUrl;
            try
            {
                var response = await _httpClient.PostAsync(apiUrl, new StringContent(myQueueItem, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    log.LogInformation("HTTP request to ReceiveMedia endpoint succeeded!");
                }
                else
                {
                    log.LogError($"HTTP request to ReceiveMedia endpoint failed with status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                log.LogError($"An error occurred while sending HTTP request to ReceiveMedia endpoint: {ex.Message}");
            }
        }
    }
}