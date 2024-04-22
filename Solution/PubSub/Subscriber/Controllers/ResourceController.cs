using Common;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services.Interfaces;

namespace Subscriber.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private IAuditService _auditService;
        private IArtistService _artistService;
        public ResourceController(IAuditService auditService, IArtistService artistService)
        {
            _auditService = auditService;
            _artistService = artistService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateArtist(string payload)
        {
            SubscriberDTO<ArtistDTO> artist = new();
            try
            {
                artist = JsonConvert.DeserializeObject<SubscriberDTO<ArtistDTO>>(payload);
                await _auditService.InsertSubscriberMediaAudit(artist, EventTypes.SubscriberDataReceived);
                var transactionStatus = await _artistService.AddArtist(artist.Data);
                if (transactionStatus)
                {
                    await _auditService.InsertSubscriberMediaAudit(artist, EventTypes.SubscriberDataAddedToDB);
                    return Ok("Artist Successfully created");
                }
                else
                {
                    await _auditService.InsertExceptionAudit("Failed to Create Artist Resource", artist.TransactionId, EventTypes.ErrorSubscriber);
                    return BadRequest("Failed to Create Artist Resource");
                }
            }
            catch (Exception ex)
            {
                await _auditService.InsertExceptionAudit(ex.Message, artist.TransactionId, EventTypes.ErrorSubscriber);
                return BadRequest($"Failed to Create Artist Resource- {ex.Message}");
            }

        }
    }
}
