using AutoMapper;
using Domain.Entities;

namespace Application.MediatR.Clients
{
    class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientDto>();
            CreateMap<ClientDto,Client>();
        }
    }
}
