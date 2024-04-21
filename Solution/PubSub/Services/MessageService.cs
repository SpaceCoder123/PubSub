using Common;
using Microsoft.Azure.ServiceBus;
using RepositoryLayer;
using Services.Interfaces;
using System.Text;
public class MessageService : IMessageService
{
    private readonly ServiceBusConnectionLayer _serviceBusConnectionLayer;
    private IAuditService _auditService;

    public MessageService(ServiceBusConnectionLayer serviceBusConnectionLayer)
    {
        _serviceBusConnectionLayer = serviceBusConnectionLayer;
    }
    public async Task<bool> SendMessageToQueue(string queueName, string messageBody, string TransactionId)
    {
        var queueClient = _serviceBusConnectionLayer.CreateQueueClient(queueName);

        try
        {
            var message = new Message(Encoding.UTF8.GetBytes(messageBody));
            queueClient.SendAsync(message).GetAwaiter().GetResult();
        }
        catch (Exception ex)
        {
            await _auditService.InsertExceptionAudit(ex.Message, TransactionId, EventTypes.ErrorPublisher);
            return false;
        }
        finally
        {
            queueClient.CloseAsync().GetAwaiter().GetResult();
        }
        return true;
    }
}
