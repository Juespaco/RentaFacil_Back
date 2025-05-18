using Application.MediatR.Bookings;
using Application.MediatR.Bookings.CreateBooking;
using Application.MediatR.Bookings.GetBookingWithFilters;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookingController : ControllerBase
    {

        private readonly IMediator _mediator;
        public BookingController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        [EnableCors("MyPolicy")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<bool> CreateAsync(CreateBookingCommand booking)
        {
            await _mediator.Send(booking);
            return true;
        }

        [HttpPost("GetBookinsWithFilters")]
        [EnableCors("MyPolicy")]
        [ProducesResponseType(typeof(IEnumerable<BookingDto>), 200)]
        public async Task<IEnumerable<BookingDto>> GetbookinsWithFiltersAsync([FromBody] GetBookingWithFiltersQuery parameters)
        {
            return await _mediator.Send(parameters);
        }

    }
}
