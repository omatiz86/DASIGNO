using Microsoft.EntityFrameworkCore;
using PruebaDemokrata.Core.Entites;
using PruebaDemokrata.Core.Interface.Repository;
using PruebaDemokrata.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaDemokrata.Infrastructure.Context
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly EFContext _dbContext;

        public UnitOfWork(EFContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IBaseRepository<T> BaseRepository<T>() where T : BaseEntity
        {
            return new RepositoryBase<T>(_dbContext);
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public IUsuarioRepository UsuarioRepository()
        {
            return new UsuarioRepository(_dbContext);
        }
    }
}
