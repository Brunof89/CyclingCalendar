using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyclingCalendar.WebApp
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> GetAll();
        Task<Event> Get(Guid id);
        Task<Event> Create(Event @event);
        Task<Event> Edit(Event @event);
        Task Delete(Guid id);
    }

    public class EventService : IEventService
    {
        private readonly CyclingCalendarDbContext _dbContext;
        public EventService(CyclingCalendarDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IEnumerable<Event>> GetAll()
        {
            return this._dbContext.Events.Where(e => e.Active).OrderByDescending(e => e.Date).AsEnumerable();
        }

        public async Task<Event> Get(Guid id)
        {
            return await this._dbContext.Events.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Event> Edit(Event @event)
        {
            var obj = await Get(@event.Id);
            obj.Date = @event.Date;
            obj.Description = @event.Description;
            await this._dbContext.SaveChangesAsync();
            return obj;
        }

        public async Task<Event> Create(Event @event)
        {
            @event.Id = Guid.NewGuid();
            @event.Active = true;
            this._dbContext.Events.Add(@event);
            await this._dbContext.SaveChangesAsync();
            return @event;
        }

        public async Task Delete(Guid id)
        {
            var obj = await Get(id);
            obj.Active = false;
            await this._dbContext.SaveChangesAsync();
        }
    }
}
