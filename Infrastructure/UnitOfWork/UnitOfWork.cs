using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Context;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IComponentContext _componentContext;

        public UnitOfWork(AppDbContext context, IComponentContext componentContext)
        {
            _context = context;
            _componentContext = componentContext;
        }

        public T GetRepository<T>()
        {
            return _componentContext.Resolve<T>(new TypedParameter(typeof(T), _context));
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
