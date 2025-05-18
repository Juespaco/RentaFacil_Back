using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.MediatR.Bookings.CreateBooking
{
    public class CreateBookingHandler : IRequestHandler<CreateBookingCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBookingHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _unitOfWork.BeginAsync<Booking>();
                var booking = _mapper.Map<Booking>(request);
                if (request.Client.Id > 0)
                {
                    var client = await _unitOfWork.Repository<Client>().GetByIdAsync(request.Client.Id);
                    client.Document = request.Client.Document;
                    client.Phone = request.Client.Phone;
                    client.FullName = request.Client.FullName;
                    client.Email = request.Client.Email;
                    var dataClient = await _unitOfWork.Repository<Client>().UpdateAsync(client);
                    booking.ClientId = client.Id;
                }
                else
                {
                    var IncomingClient = _mapper.Map<Client>(request.Client);
                    var dataClient = await _unitOfWork.Repository<Client>().AddAsync(IncomingClient);
                    booking.ClientId = dataClient.Id;
                }
            
                var data = await _unitOfWork.Repository<Booking>().AddAsync(booking);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {

                throw ex ;
            }
            
        }
    }
}
