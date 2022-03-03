using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HandlerObjects.Command;
using Infrastructure.UnitOfWork;
using MediatR;
using Model;
using Repositories.Desks;
using Repositories.Rooms;

namespace Handlers.DeskHandlers
{
    public class CreateNewDeskHandler : IRequestHandler<CreateNewDeskCommand, Guid>
    {
        private readonly IUnitOfWork _uow;

        public CreateNewDeskHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Guid> Handle(CreateNewDeskCommand request, CancellationToken cancellationToken)
        {
            var room = _uow.GetRepository<IRoomReadRepository>().GetById(request.RoomId);

            if (room == null)
                return Guid.Empty;

            var newDesk = new Desk()
            {
                Name = request.Name,
                RoomId = room.Id
            };

            _uow.GetRepository<IDeskWriteRepository>().Add(newDesk);

            _uow.SaveChanges();

            return newDesk.Id;
        }
    }
}
