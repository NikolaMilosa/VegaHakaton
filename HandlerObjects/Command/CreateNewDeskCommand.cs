using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using HandlerObjects.Responses;
using MediatR;

namespace HandlerObjects.Command
{
    public class CreateNewDeskCommand : IRequest<BasicResponse>
    {
        public string RoomId { get; }

        public CreateNewDeskCommand(string roomId)
        {
            RoomId = roomId;
        }

        public CreateNewDeskCommand(DeskDto deskDto)
        {
            RoomId = deskDto.RoomId;
        }
    }
}
