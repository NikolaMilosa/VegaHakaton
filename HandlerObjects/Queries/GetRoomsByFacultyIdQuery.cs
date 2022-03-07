using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Model;

namespace HandlerObjects.Queries
{
    public class GetRoomsByFacultyIdQuery : IRequest<IEnumerable<Room>>
    {
        public string FacultyId { get; }

        public GetRoomsByFacultyIdQuery(string facultyId)
        {
            FacultyId = facultyId;
        }
    }
}
