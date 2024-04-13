using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Publisher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(PublisherExceptionFilter))]
    public class PostMediaController : ControllerBase
    {
        public PostMediaController() 
        {

        }
    }
}
