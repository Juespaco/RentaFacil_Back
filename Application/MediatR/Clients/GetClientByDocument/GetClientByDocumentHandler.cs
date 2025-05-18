using Application.MediatR.Vehicles;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.MediatR.Clients.GetClientByDocument
{
    public class GetClientByDocumentHandler : IRequestHandler<GetClientByDocumentQuery, ClientDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetClientByDocumentHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ClientDto> Handle(GetClientByDocumentQuery request, CancellationToken cancellationToken)
        {
            var clients =  await _unitOfWork.Repository<Client>().GetAsync(x => x.Document == request.document);
            return _mapper.Map<ClientDto>(clients.FirstOrDefault());
        }
    }
}
