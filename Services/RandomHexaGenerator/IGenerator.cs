using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.UnitOfWork;
using Repositories.Base;

namespace Services.RandomHexaGenerator
{
    public interface IGenerator
    {
        string GenId<TRepo, TEntity>()
            where TEntity : class
            where TRepo : IReadBaseRepository<string, TEntity>;
    }
}
