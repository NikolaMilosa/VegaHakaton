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
using Repositories.Rooms;

namespace Handlers.RoomHandlers
{
    public class GetAllRoomsHandler : IRequestHandler<GetAllRoomsQuery, IEnumerable<Room>>
    {
        private readonly IUnitOfWork _uow;

        public GetAllRoomsHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<Room>> Handle(GetAllRoomsQuery request, CancellationToken cancellationToken)
        {
            return _uow.GetRepository<IRoomReadRepository>()
                .GetAll();
        }
    }
}
