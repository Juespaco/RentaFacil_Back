using Application.MediatR.Clients;
using Application.MediatR.Clients.GetClientByDocument;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClientController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ClientController(IMediator mediator) => _mediator = mediator;

        [HttpGet("GetClientByDocument/{document}")]
        [EnableCors("MyPolicy")]
        [ProducesResponseType(typeof(ClientDto), 200)]
        public async Task<ClientDto> GetAllAsync(string document)
        {
            return await _mediator.Send(new GetClientByDocumentQuery(document));
        }
    }
}
