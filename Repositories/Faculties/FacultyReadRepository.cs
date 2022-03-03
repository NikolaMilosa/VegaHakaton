using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Context;
using Model;
using Repositories.Base;

namespace Repositories.Faculties
{
    public class FacultyReadRepository : ReadBaseRepository<Guid, Faculty>, IFacultyReadRepository
    {
        public FacultyReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
