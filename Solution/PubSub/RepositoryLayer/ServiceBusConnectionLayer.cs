using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;

namespace RepositoryLayer
{
    public class ServiceBusConnectionLayer
    {
        private readonly string _connectionString;
        public ServiceBusConnectionLayer(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ServiceBusConnection");
        }
        public IQueueClient CreateQueueClient(string queueName)
        {
            return new QueueClient(_connectionString, queueName);
        }
    }
}
