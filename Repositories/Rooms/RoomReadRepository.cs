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
    public class RoomReadRepository : ReadBaseRepository<string, Room>, IRoomReadRepository
    {
        public RoomReadRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Desk> GetDesksInRoom(string roomId)
        {
            return GetAll()
                .Where(x => x.Id == roomId)
                .Include(x => x.Desks)
                .FirstOrDefault()?
                .Desks;
        }

        public int GetNextInOrder(string roomId)
        {
            var room = GetAll()
                .Where(x => x.Id == roomId)
                .Include(x => x.Desks)
                .FirstOrDefault();
            if (room == null)
                throw new Exception("Room not found");

            return room.Desks.Count;
        }
    }
}
