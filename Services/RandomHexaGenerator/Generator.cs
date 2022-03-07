using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.UnitOfWork;
using Repositories.Base;

namespace Services.RandomHexaGenerator
{
    public class Generator : IGenerator
    {
        private readonly IUnitOfWork _uow;

        public Generator(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public string GenId<TRepo, TEntity>() 
            where TEntity : class
            where TRepo : IReadBaseRepository<string, TEntity>
        {
            var random = new Random();

            var prefix = "621cce90";
            var allowedCharacters = "abcdef0123456789";
            var len = 16;

            var result = string.Empty;
            var shouldContinue = true;

            while (shouldContinue)
            {
                result = string.Empty;
                for (int i = 0; i < len; i++)
                {
                    int nextCharPos = random.Next(allowedCharacters.Length);
                    result += allowedCharacters.ElementAt(nextCharPos);
                }

                shouldContinue = _uow.GetRepository<TRepo>().GetById(result) != null;
            }

            return prefix + result;
        }
    }
}
