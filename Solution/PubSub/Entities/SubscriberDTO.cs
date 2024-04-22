namespace Entities
{
    public class SubscriberDTO<T>
    {
        public string TransactionId { get; set; }
        public T Data { get; set; }
    }
}
