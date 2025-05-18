using Application.MediatR.Clients;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.MediatR.Bookings.CreateBooking
{
    public record CreateBookingCommand(
       [Required] string StartDate,
       [Required] string EndDate,
       [Required] int VehicleId,
       [Required] int EmployeeId,
       [Required] ClientDto Client
    ) : IRequest;
}
