using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HandlerObjects.Queries;
using Infrastructure.UnitOfWork;
using MediatR;
using Model;
using Repositories.Desks;
using Repositories.Rooms;

namespace Handlers.DeskHandlers
{
    public class GetAllDesksByRoomHandler : IRequestHandler<GetAllDesksByRoomIdQuery, IEnumerable<Desk>>
    {
        private readonly IUnitOfWork _uow;

        public GetAllDesksByRoomHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<Desk>> Handle(GetAllDesksByRoomIdQuery request, CancellationToken cancellationToken)
        {
            return _uow.GetRepository<IRoomReadRepository>()
                .GetDesksInRoom(request.RoomId);
        }
    }
}
