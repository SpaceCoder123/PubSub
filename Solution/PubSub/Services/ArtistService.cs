using Common;
using Entities;
using RepositoryLayer.Interfaces;
using Services.Interfaces;

namespace Services
{
    public class ArtistService : IArtistService
    {
        private IAuditService _auditService;
        private ISubscriberRepository _subscriberRepository;
        public ArtistService(IAuditService auditService, ISubscriberRepository subscriberRepository)
        {
            _auditService = auditService;
            _subscriberRepository = subscriberRepository;
        }
        public async Task<bool> AddArtist(ArtistDTO artistDTO)
        {
            SubscriberDTO<ArtistDTO> subscriberDTO = new();
            var artistStatus = await _subscriberRepository.InsertArtistDetails(artistDTO);
            if (artistStatus)
                return await _auditService.InsertSubscriberMediaAudit(subscriberDTO, EventTypes.SubscriberDataProcessing);
            else
                return await _auditService.InsertExceptionAudit("Error in adding artist details", subscriberDTO.TransactionId, EventTypes.ErrorSubscriber);
        }
    }
}
