using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Model;

namespace HandlerObjects.Queries
{
    public class GetAllDesksByRoomIdQuery : IRequest<IEnumerable<Desk>>
    {
        public string RoomId { get; }

        public GetAllDesksByRoomIdQuery(string roomId)
        {
            RoomId = roomId;
        }
    }
}
