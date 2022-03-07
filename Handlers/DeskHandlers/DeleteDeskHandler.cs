using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HandlerObjects.Command;
using Infrastructure.UnitOfWork;
using MediatR;
using Repositories.Desks;

namespace Handlers.DeskHandlers
{
    public class DeleteDeskHandler : IRequestHandler<DeleteDeskCommand, string>
    {
        private readonly IUnitOfWork _uow;

        public DeleteDeskHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<string> Handle(DeleteDeskCommand request, CancellationToken cancellationToken)
        {
            var desk = _uow.GetRepository<IDeskReadRepository>()
                .GetById(request.DeskId);

            if(desk == null)
                return string.Empty;

            _uow.GetRepository<IDeskWriteRepository>().Delete(desk);

            UpdateOrder(desk.Order, desk.RoomId);

            return desk.Id;
        }

        public void UpdateOrder(int deletedOrder, string roomId)
        {
            var nextDesks = _uow.GetRepository<IDeskReadRepository>()
                .GetAll()
                .Where(x => x.Order > deletedOrder && x.RoomId == roomId);

            foreach (var table in nextDesks)
            {
                table.Order--;
            }

            _uow.GetRepository<IDeskWriteRepository>().UpdateRange(nextDesks);
        }
    }
}
