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
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllRoomsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{faculty}")]
        public async Task<IActionResult> GetById(Guid faculty)
        {
            var query = new GetRoomsByFacultyIdQuery(faculty);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
