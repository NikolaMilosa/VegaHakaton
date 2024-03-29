﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Base
{
    public interface IReadBaseRepository<TKey, TEntity> where TEntity: class
    {
        TEntity GetById(TKey id);

        DbSet<TEntity> GetAll();
    }
}
