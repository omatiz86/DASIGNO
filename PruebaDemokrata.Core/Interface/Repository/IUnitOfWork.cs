using PruebaDemokrata.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaDemokrata.Core.Interface.Repository
{
    public interface IUnitOfWork
    {
        int SaveChanges();
        IBaseRepository<T> BaseRepository<T>() where T : BaseEntity;


        IUsuarioRepository UsuarioRepository();

    }
}
