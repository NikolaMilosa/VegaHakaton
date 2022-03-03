using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Model;

namespace HandlerObjects.Queries
{
    public class GetRoomsByFacultyIdQuery : IRequest<Room>, IRequest<IEnumerable<Room>>
    {
        public Guid FacultyId { get; }

        public GetRoomsByFacultyIdQuery(Guid facultyId)
        {
            FacultyId = facultyId;
        }
    }
}
