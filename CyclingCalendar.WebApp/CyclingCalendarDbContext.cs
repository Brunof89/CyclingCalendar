using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyclingCalendar.WebApp
{
    public class CyclingCalendarDbContext:DbContext
    {
        public CyclingCalendarDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Event> Events { get; set; }
    
    }
}
