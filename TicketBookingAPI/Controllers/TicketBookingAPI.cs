using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketBookingAPI.Models;                       // Add
using TicketBookingAPI.Data;

namespace TicketBookingAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TicketBookingAPI : ControllerBase
    {
        private readonly ApiContext _context;
        public TicketBookingAPI(ApiContext context)
        {
            _context = context;
        }

        // Create / Edit
        [HttpPost]
        public JsonResult CreateEdit (TicketBooking booking)
        {
            if (booking.Id == 0) 
            {
                _context.Bookings.Add(booking);
            }
            else
            {
                var bookingInDb = _context.Bookings.Find(booking.Id);
                if (bookingInDb == null)
                    return new JsonResult(NotFound());

                booking = bookingInDb;
            }
            _context.SaveChanges();
            return new JsonResult(Ok(booking));
        }

        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.Bookings.Find(id);

            if(result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = (_context.Bookings.Find(id));

            if (result == null)
                return new JsonResult(NotFound());

            _context.Bookings.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }

        // Get all
        [HttpGet()]
        public JsonResult GetAll()
        {
            var result = _context.Bookings.ToList();

            return new JsonResult(Ok(result));
        }
    }
}
