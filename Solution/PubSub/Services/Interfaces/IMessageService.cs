namespace Services.Interfaces
{
    public interface IMessageService
    {
        public Task<bool> SendMessageToQueue(string messageBody, string TransactionId);
    }
}
