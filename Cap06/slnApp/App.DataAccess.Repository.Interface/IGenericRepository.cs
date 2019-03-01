using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccess.Repository.Interface
{
    public interface IGenericRepository<TEntity> where TEntity:class
    {
        void Add(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);

        int Count();

        TEntity GetById<TId>(TId id);

        IEnumerable<TEntity> GetAll();
        
    }
}
