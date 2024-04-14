namespace Entities
{
    public class Audit
    {
        public string TransactionId { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }
        public string AuditType { get; set; }
        public string Payload { get; set; }
    }
}
