using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Context;
using Microsoft.EntityFrameworkCore;
using Model;
using Repositories.Base;

namespace Repositories.Faculties
{
    public class FacultyReadRepository : ReadBaseRepository<Guid, Faculty>, IFacultyReadRepository
    {
        public FacultyReadRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Room> GetRoomsByFacultyId(Guid facultyId)
        {
            return GetAll()
                .Where(x => x.Id == facultyId)
                .Include(x => x.Rooms)
                .FirstOrDefault()?
                .Rooms;
        }
    }
}
