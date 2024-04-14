using Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Publisher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(PublisherExceptionFilter))]
    public class PostMediaController : ControllerBase
    {
        private IPublisherService _publisherService;
        private IAuditService _auditService;
        public PostMediaController(IPublisherService publisherService, IAuditService auditService)
        {
            _publisherService = publisherService;
            _auditService = auditService;
        }
        [Route("PostMedia")]
        [HttpPost]
        public async Task<IActionResult> PostMedia(MediaSongDTO mediaSongDTO)
        {
            var output = await _auditService.InsertMediaAudit(mediaSongDTO, "RecievedPayloadInPublisher");
            var isSongInserted = await _publisherService.InsertPlayableMedia(mediaSongDTO);
            if(isSongInserted) 
            {
                await _auditService.InsertMediaAudit(mediaSongDTO, "SuccessfullyCompletedProcessingPublisher");
            }
            return Ok(isSongInserted);
        }
    }
}
