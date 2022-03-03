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
    public class DeskWriteRepository : WriteBaseRepository<Desk>, IDeskWriteRepository
    {
        public DeskWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
