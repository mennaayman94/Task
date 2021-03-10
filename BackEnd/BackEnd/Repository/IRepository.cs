using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Repository
{
    //Generic IRepository
    public interface IRepository <TEntity>
    {
        IQueryable<TEntity> GetAll();
        TEntity GetById(int id);
        TEntity Add(TEntity entity);
        void Remove(TEntity entity);
        void Edit(TEntity entity);
    }
}
