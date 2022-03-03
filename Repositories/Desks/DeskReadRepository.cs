using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Context;
using Model;
using Repositories.Base;

namespace Repositories.Desks
{
    public class DeskReadRepository : ReadBaseRepository<Guid, Desk>, IDeskReadRepository
    {
        public DeskReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
