using Common;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Publisher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(PublisherExceptionFilter))]
    public class PostMediaController : ControllerBase
    {
        private IAuditService _auditService;
        public PostMediaController(IAuditService auditService)
        {
            _auditService = auditService;
        }
        [HttpPost]
        public async Task<IActionResult> PostMedia(MediaSongDTO mediaSongDTO, [Required][FromHeader] Guid TransactionId)
        {
            mediaSongDTO.TransactionId = TransactionId;
            await _auditService.InsertMediaAudit(mediaSongDTO, EventTypes.ReceivedPayloadInPublisher);
            return Ok("Data processed.");
        }
    }
}