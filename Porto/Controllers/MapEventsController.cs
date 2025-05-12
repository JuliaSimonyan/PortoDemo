using Microsoft.AspNetCore.Mvc;
using Porto.App.Interfaces;

namespace Porto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MapEventsController : ControllerBase
    {
        private readonly IEvent _eventService;

        public MapEventsController(IEvent eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var events = await _eventService.GetAllEvents();
            return Ok(events);
        }
    }
}
