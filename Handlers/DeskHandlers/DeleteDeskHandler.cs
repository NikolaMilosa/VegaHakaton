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
    public class DeleteDeskHandler : IRequestHandler<DeleteDeskCommand, Guid>
    {
        private readonly IUnitOfWork _uow;

        public DeleteDeskHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Guid> Handle(DeleteDeskCommand request, CancellationToken cancellationToken)
        {
            var desk = _uow.GetRepository<IDeskReadRepository>()
                .GetById(request.DeskId);

            if(desk == null)
                return Guid.Empty;

            _uow.GetRepository<IDeskWriteRepository>().Delete(desk);
            return desk.Id;
        }
    }
}
