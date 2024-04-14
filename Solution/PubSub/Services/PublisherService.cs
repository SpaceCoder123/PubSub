
using AutoMapper;
using Entities;
using RepositoryLayer.Interfaces;
using Services.Interfaces;

namespace Services
{
    public class PublisherService : IPublisherService
    {
        private IPublisherRepository _publisherRepository;
        private IMapper _mapper;
        private IAuditService _auditService;
        public PublisherService(IPublisherRepository publisherRepository, IMapper mapper, IAuditService auditService)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
            _auditService = auditService;
        }

        public async Task<bool> InsertPlayableMedia(MediaSongDTO mediaSongDTO)
        {
            await _auditService.InsertMediaAudit(mediaSongDTO, "ProcessingInPublisher");
            MediaSongEntity entity = _mapper.Map<MediaSongEntity>(mediaSongDTO);
            return await _publisherRepository.InsertSong(entity);
        }
    }
}
