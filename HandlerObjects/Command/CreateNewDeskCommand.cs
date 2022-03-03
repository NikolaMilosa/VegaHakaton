using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using MediatR;

namespace HandlerObjects.Command
{
    public class CreateNewDeskCommand : IRequest<Guid>
    {
        public string Name { get; }
        public Guid RoomId { get; }

        public CreateNewDeskCommand(string name, Guid roomId)
        {
            Name = name;
            RoomId = roomId;
        }

        public CreateNewDeskCommand(DeskDto deskDto)
        {
            Name = deskDto.Name;
            RoomId = deskDto.RoomId;
        }
    }
}
