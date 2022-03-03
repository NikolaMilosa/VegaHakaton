using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HandlerObjects.Queries;
using Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Model;
using Repositories.Faculties;

namespace Handlers.FacultyHandlers
{
    public class GetAllFacultiesHandler : IRequestHandler<GetAllFacultiesQuery, IEnumerable<Faculty>>
    {
        private readonly IUnitOfWork _uow;

        public GetAllFacultiesHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<Faculty>> Handle(GetAllFacultiesQuery request, CancellationToken cancellationToken)
        {
            return _uow.GetRepository<IFacultyReadRepository>()
                .GetAll();
        }
    }
}
