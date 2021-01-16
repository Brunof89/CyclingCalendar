using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyclingCalendar.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Calendar : ControllerBase
    {
        private readonly IEventService _eventService;
        public Calendar(IEventService eventService)
        {
            this._eventService = eventService;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Event>>> GetAll()
        {
            var todoItem = await _eventService.GetAll();

            return Ok(todoItem);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> Get(Guid id)
        {
            var todoItem = await _eventService.Get(id);

            return Ok(todoItem);
        }

        [HttpPost()]
        public async Task<ActionResult<Event>> Create(Event @event)
        {
            var todoItem = await _eventService.Create(@event);

            return Ok(todoItem);
        }

        [HttpPut()]
        public async Task<ActionResult<IEnumerable<Event>>> Edit(Event @event)
        {
            var todoItem = await _eventService.Edit(@event);

            return Ok(todoItem);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<Event>>> Delete(Guid id)
        {
            await _eventService.Delete(id);

            return Ok("");
        }
    }
}
