using PruebaDemokrata.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PruebaDemokrata.Core.Interface.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {

        TEntity Add(TEntity entity);

        TEntity Update(TEntity entity);

        bool Delete(TEntity entity);

        TEntity Get(Expression<Func<TEntity, bool>> expression);

        List<TEntity> List(Expression<Func<TEntity, bool>> expression);

    }
}
