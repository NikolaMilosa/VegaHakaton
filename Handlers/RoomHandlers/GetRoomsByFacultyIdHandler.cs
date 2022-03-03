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
using Repositories.Faculties;

namespace Handlers.RoomHandlers
{
    public class GetRoomsByFacultyIdHandler : IRequestHandler<GetRoomsByFacultyIdQuery, IEnumerable<Room>>
    {
        private readonly IUnitOfWork _uow;

        public GetRoomsByFacultyIdHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<IEnumerable<Room>> Handle(GetRoomsByFacultyIdQuery request, CancellationToken cancellationToken)
        {
            return _uow.GetRepository<IFacultyReadRepository>()
                .GetRoomsByFacultyId(request.FacultyId);
        }
    }
}
