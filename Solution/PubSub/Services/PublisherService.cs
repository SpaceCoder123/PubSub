using Common;
using Entities;
using Newtonsoft.Json;
using Services.Interfaces;

namespace Services
{
    public class PublisherService : IPublisherService
    {
        private IAuditService _auditService;
        private IMessageService _messageService;
        public PublisherService(IAuditService auditService, IMessageService messageService)
        {
            _auditService = auditService;
            _messageService = messageService;
        }

        public async Task<bool> SendPlayableMedia(MediaSongDTO mediaSongDTO)
        {
            string mediaSongJSON = JsonConvert.SerializeObject(mediaSongDTO);
            bool status = await _messageService.SendMessageToQueue(mediaSongJSON, mediaSongDTO.TransactionId.ToString());
            if(status)
                await _auditService.InsertMediaAudit(mediaSongDTO, EventTypes.DataSentToServiceBus);
            else
                await _auditService.InsertExceptionAudit("Error in inserting message to service bus", mediaSongDTO.TransactionId.ToString(), EventTypes.DataSentToServiceBus);
            return true;
        }
    }
}
