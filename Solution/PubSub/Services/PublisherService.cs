using RepositoryLayer.Interfaces;
using Services.Interfaces;

namespace Services
{
    public class PublisherService : IPublisherService
    {
        private IPublisherRepository _publisherRepository;
        private IAuditService _auditService;
        public PublisherService(IPublisherRepository publisherRepository, IAuditService auditService)
        {
            _publisherRepository = publisherRepository;
            _auditService = auditService;
        }

        //public async Task<bool> InsertPlayableMedia(MediaSongDTO mediaSongDTO)
        //{
        //    await _auditService.InsertMediaAudit(mediaSongDTO, EventTypes.SubscriberDataProcessing);
        //    return await _publisherRepository.InsertSong(mediaSongDTO);
        //}
    }
}
