using Common;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services.Interfaces;
using Subscriber.Filters;

namespace Subscriber.Controllers
{
    [ApiController]
    [ServiceFilter(typeof(SubscriberExceptionFilter))]
    public class ReceiveMediaController : ControllerBase
    {
        private ISubscriberService _subscriberService;
        private IAuditService _auditService;
        public ReceiveMediaController(ISubscriberService subscriberService, IAuditService auditService)
        {
            _subscriberService = subscriberService;
            _auditService = auditService;
        }

        [Route("/api/ReceiveMedia")]
        [HttpPost]
        public async Task<IActionResult> ReceiveMedia(string mediaPayload)
        {
            RecieveMediaDTO mediaSongDTO = JsonConvert.DeserializeObject<RecieveMediaDTO>(mediaPayload);
            await _auditService.InsertMediaAudit(mediaSongDTO, EventTypes.SubscriberDataReceived);
            var isSongInserted = await _subscriberService.InsertSongDetails(mediaSongDTO);
            if (isSongInserted)
            {
                await _auditService.InsertMediaAudit(mediaSongDTO, EventTypes.SubscriberDataAddedToDB);
            }
            return Ok(isSongInserted);
        }
    }
}
