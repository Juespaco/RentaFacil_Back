using MediatR;
using System.Runtime.InteropServices;

namespace Application.MediatR.Bookings.GetBookingWithFilters
{
    public record GetBookingWithFiltersQuery(
        string? DocumentClient = null,
        string? PlateNumber = null
    ) : IRequest<IEnumerable<BookingDto>>;
}
