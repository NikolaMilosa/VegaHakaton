using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HandlerObjects.Command;
using HandlerObjects.Responses;
using Infrastructure.UnitOfWork;
using MediatR;
using Model;
using Repositories.Desks;
using Repositories.Rooms;
using Services.RandomHexaGenerator;

namespace Handlers.DeskHandlers
{
    public class CreateNewDeskHandler : IRequestHandler<CreateNewDeskCommand, BasicResponse>
    {
        private readonly IUnitOfWork _uow;
        private readonly IGenerator _generator;

        public CreateNewDeskHandler(IUnitOfWork uow, IGenerator generator)
        {
            _uow = uow;
            _generator = generator;
        }

        public async Task<BasicResponse> Handle(CreateNewDeskCommand request, CancellationToken cancellationToken)
        {
            if (!RoomExists(request.RoomId))
                return new BasicResponse(false, $"Room not found!");
            
            var desk = AddNewDesk(request);

            return new BasicResponse(true, $"Desk added with Id {desk.Id}");
        }

        private bool RoomExists(string roomId)
        {
            return _uow.GetRepository<IRoomReadRepository>().GetById(roomId) != null;
        }

        private Desk AddNewDesk(CreateNewDeskCommand request)
        {
            var newDesk = new Desk()
            {
                Order = _uow.GetRepository<IRoomReadRepository>().GetNextInOrder(request.RoomId),
                RoomId = request.RoomId,
                Id = _generator.GenId<IDeskReadRepository, Desk>()
            };

            _uow.GetRepository<IDeskWriteRepository>().Add(newDesk);

            _uow.SaveChanges();

            return newDesk;
        }
    }
}
