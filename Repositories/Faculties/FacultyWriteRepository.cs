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
    public class FacultyWriteRepository : WriteBaseRepository<Faculty>, IFacultyWriteRepository
    {
        public FacultyWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
