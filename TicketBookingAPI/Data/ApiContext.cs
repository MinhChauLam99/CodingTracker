using Microsoft.EntityFrameworkCore;                    // them
using TicketBookingAPI.Models;                          // them

namespace TicketBookingAPI.Data
{
    public class ApiContext : DbContext                    // Build
    {
        public DbSet<TicketBooking> Bookings { get; set; }
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) 
        {

        }
    }
}
