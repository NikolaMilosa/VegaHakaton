using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Context;
using Microsoft.EntityFrameworkCore;
using Model;
using Repositories.Base;

namespace Repositories.Rooms
{
    public class RoomReadRepository : ReadBaseRepository<Guid, Room>, IRoomReadRepository
    {
        public RoomReadRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Desk> GetDesksInRoom(Guid roomId)
        {
            return GetById(roomId).Desks;
        }
    }
}
