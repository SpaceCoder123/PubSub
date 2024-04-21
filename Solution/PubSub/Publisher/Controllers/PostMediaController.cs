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
        private IPublisherService _publishService;
        public PostMediaController(IAuditService auditService, IPublisherService publishService)
        {
            _auditService = auditService;
            _publishService = publishService;
        }
        [HttpPost]
        public async Task<IActionResult> PostMedia(MediaSongDTO mediaSongDTO, [Required][FromHeader] Guid TransactionId)
        {
            try
            {
                mediaSongDTO.TransactionId = TransactionId;
                await _auditService.InsertMediaAudit(mediaSongDTO, EventTypes.ReceivedPayloadInPublisher);
                await _publishService.SendPlayableMedia(mediaSongDTO);
                await _auditService.InsertMediaAudit(mediaSongDTO, EventTypes.SuccessfullyCompletedProcessingPublisher);
                return Ok("Data processed.");
            }
            catch (Exception ex)
            {
                await _auditService.InsertExceptionAudit(ex.Message, TransactionId.ToString(), EventTypes.ErrorPublisher);
                return BadRequest(ex.Message);
            }
        }
    }
}