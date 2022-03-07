using System;
using System.Threading.Tasks;
using HandlerObjects.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("/rooms")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoomController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetRooms([FromQuery] string faculty)
        {
            var result = string.IsNullOrEmpty(faculty) 
                ? await _mediator.Send(new GetAllRoomsQuery()) 
                : await _mediator.Send(new GetRoomsByFacultyIdQuery(faculty));
            return result == null ? BadRequest("Faculty not found!") : Ok(result);
        }
    }
}
