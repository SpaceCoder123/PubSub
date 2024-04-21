using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace PubSubAzFunction
{
    public class PubSubDeliveryFunction
    {
        private readonly IConfiguration _config;

        public PubSubDeliveryFunction(IConfiguration config)
        {
            _config = config;
        }

        [FunctionName("PubSubDeliveryFunction")]
        public void Run([ServiceBusTrigger("%ServiceBusQueueName%", Connection = "ServiceBusConnectionString")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}