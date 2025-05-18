using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using System.Linq.Expressions;

namespace Application.MediatR.Bookings.GetBookingWithFilters
{
    public class GetBookingWithFiltersHandler : IRequestHandler<GetBookingWithFiltersQuery, IEnumerable<BookingDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBookingWithFiltersHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<BookingDto>> Handle(GetBookingWithFiltersQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Booking, bool>>? predicate = null;

            if (!string.IsNullOrWhiteSpace(request.PlateNumber) || !string.IsNullOrWhiteSpace(request.DocumentClient))
            {
                predicate = b =>
                    (string.IsNullOrEmpty(request.PlateNumber) || b.Vehicle.PlateNumber.Contains(request.PlateNumber)) &&
                    (string.IsNullOrEmpty(request.DocumentClient) || b.Client.Document.Contains(request.DocumentClient));
            }
            var bookings = await _unitOfWork.Repository<Booking>().GetMulipleAsync(
                predicate: predicate,
                includes: new List<Expression<Func<Booking, object>>>
                {
                    b => b.Vehicle,
                    b => b.Client
                }
            );

            return _mapper.Map<IEnumerable<BookingDto>>(bookings);
        }
    }
}
