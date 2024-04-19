using Common;
using Entities;
using RepositoryLayer.Interfaces;
using Services.Interfaces;

namespace Services
{
    public class SubscriberService : ISubscriberService
    {
        private ISubscriberRepository _subscriberRepository;
        private IAuditService _auditService;
        public SubscriberService(ISubscriberRepository subscriberRepository, IAuditService auditService)
        {
            _subscriberRepository = subscriberRepository;
            _auditService = auditService;
        }
        public async Task<bool> InsertSongDetails(RecieveMediaDTO mediaSong)
        {
            await _auditService.InsertMediaAudit(mediaSong, EventTypes.SubscriberDataProcessing);
            return await _subscriberRepository.InsertBasicDetailsToDb(mediaSong);
        }
    }
}
