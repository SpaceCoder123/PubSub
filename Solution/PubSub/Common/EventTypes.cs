namespace Common
{
    public static class EventTypes
    {
        public const string ReceivedPayloadInPublisher = "RecievedPayloadInPublisher";
        public const string ProcessingInPublisher = "ProcessingInPublisher";
        public const string SuccessfullyCompletedProcessingPublisher = "SuccessfullyCompletedProcessingPublisher";
        public const string DataSentToServiceBus = "DataSentToServiceBus";
        public const string ServiceBusTriggerDataReceived = "ServiceBusTriggerDataReceived";
        public const string ServiceBusTriggerProcessingCompleted = "ServiceBusTriggerProcessingCompleted";
        public const string SubscriberDataReceived = "SubscriberDataReceived";
        public const string SubscriberDataProcessing = "SubscriberDataProcessing";
        public const string SubscriberDataAddedToDB = "SubscriberDataAddedToDB";
        public const string ErrorPublisher = "ErrorPublisher";
        public const string ErrorServiceBusTrigger = "ErrorServiceBusTrigger";
        public const string ErrorSubscriber = "ErrorSubscriber";
    }
}
