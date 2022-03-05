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
        public async Task<IActionResult> GetDesks([FromQuery] string room)
        {
            var result = string.IsNullOrEmpty(room) 
                ? await _mediator.Send(new GetAllDesksQuery())
                : await _mediator.Send(new GetAllDesksByRoomIdQuery(room));
            return result == null ? BadRequest("Room not found!") : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostDesk([FromBody] DeskDto newDesk)
        {
            var command = new CreateNewDeskCommand(newDesk);
            var result = await _mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : NotFound("Room not found!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDesk(string id)
        {
            var command = new DeleteDeskCommand(id);
            var result = await _mediator.Send(command);
            return result == string.Empty ? NotFound("Desk not found!") : Ok(result);
        }
    }
}
