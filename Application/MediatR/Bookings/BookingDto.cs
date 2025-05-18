using Application.MediatR.Clients;
using Application.MediatR.Vehicles;
using Domain.Entities;

namespace Application.MediatR.Bookings
{
    public class BookingDto
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int ClientId { get; set; }
        public ClientDto Client { get; set; } = null!;

        public int VehicleId { get; set; }
        public VehicleDto Vehicle { get; set; } = null!;

        public int EmployeeId { get; set; }
    }
}
