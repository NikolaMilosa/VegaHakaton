using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Context;
using Model;
using Repositories.Base;

namespace Repositories.Rooms
{
    public class RoomWriteRepository : WriteBaseRepository<Room>, IRoomWriteRepository
    {
        public RoomWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
