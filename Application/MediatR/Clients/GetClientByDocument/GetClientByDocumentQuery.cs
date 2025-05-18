using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.MediatR.Clients.GetClientByDocument
{
    public record GetClientByDocumentQuery(
        [Required] string document
     ) : IRequest<ClientDto>;
}
