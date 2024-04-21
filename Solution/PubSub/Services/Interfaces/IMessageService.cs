namespace Services.Interfaces
{
    public interface IMessageService
    {
        public Task<bool> SendMessageToQueue(string queueName, string messageBody, string TransactionId);
    }
}
