using System;
using System.Threading.Tasks;
using DTO;
using HandlerObjects.Command;
using HandlerObjects.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("/desks")]
    [ApiController]
    public class DeskController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DeskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllDesksQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{room}")]
        public async Task<IActionResult> GetByRoomId(Guid room)
        {
            var query = new GetAllDesksByRoomIdQuery(room);
            var result = await _mediator.Send(query);
            return result == null ? BadRequest("Room not found!") : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostDesk([FromBody] DeskDto newDesk)
        {
            var command = new CreateNewDeskCommand(newDesk);
            var result = await _mediator.Send(command);
            return result == Guid.Empty ? NotFound("Room not found!") : Ok(result);
        }

        [HttpDelete("/{id}")]
        public async Task<IActionResult> DeleteDesk(Guid id)
        {
            var command = new DeleteDeskCommand(id);
            var result = await _mediator.Send(command);
            return result == Guid.Empty ? NotFound("Desk not found!") : Ok(result);
        }
    }
}
