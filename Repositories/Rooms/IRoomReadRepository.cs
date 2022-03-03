using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Repositories.Base;

namespace Repositories.Rooms
{
    public interface IRoomReadRepository : IReadBaseRepository<Guid, Room>
    {
        IEnumerable<Desk> GetDesksInRoom(Guid roomId);
    }
}
