using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.MediatR.Vehicles.GetVehicleAvailability
{
    public record GetVehicleAvailabilityQuery(
        [Required] int VehicleType,
        [Required] string StartDate,
        [Required] string EndDate
     ) : IRequest<IEnumerable<VehicleDto>>;
}
