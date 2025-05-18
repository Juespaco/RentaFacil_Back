using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.MediatR.Vehicles.GetVehicleAvailability
{
    class GetVehicleAvailabilityHandler : IRequestHandler<GetVehicleAvailabilityQuery, IEnumerable<VehicleDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetVehicleAvailabilityHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<VehicleDto>> Handle(GetVehicleAvailabilityQuery request, CancellationToken cancellationToken)
        {
            var allVehicles = await _unitOfWork.Repository<Vehicle>().GetAsync(x => x.VehicleTypeId == request.VehicleType);
            var unavailableVehicleIds =  await _unitOfWork.Repository<Booking>().GetAsync(x => x.StartDate <= DateTime.Parse(request.EndDate) && x.EndDate >= DateTime.Parse(request.StartDate));
            var unavailableIds = unavailableVehicleIds.Select(b => b.VehicleId).Distinct();
            var availableVehicles = allVehicles
                .Where(v => !unavailableIds.Contains(v.Id))
                .ToList();
            return _mapper.Map<IEnumerable<VehicleDto>>(availableVehicles);
        }
    }

}
