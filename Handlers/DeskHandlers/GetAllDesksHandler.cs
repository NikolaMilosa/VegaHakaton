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

namespace Handlers.DeskHandlers
{
    public class GetAllDesksHandler : IRequestHandler<GetAllDesksQuery, IEnumerable<Desk>>
    {
        private readonly IUnitOfWork _uow;

        public GetAllDesksHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<Desk>> Handle(GetAllDesksQuery request, CancellationToken cancellationToken)
        {
            return _uow.GetRepository<IDeskReadRepository>()
                .GetAll();
        }
    }
}
