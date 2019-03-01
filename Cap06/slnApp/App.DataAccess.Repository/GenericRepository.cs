using App.DataAccess.Repository.Interface;
using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccess.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity:class
    {
        private AppDataModel _context;

        public GenericRepository()
        {
            _context = new AppDataModel();
        }

        public void Add(TEntity entity)
        {
            // se agrega la entidad al contexto de Entity Framework
            _context.Set<TEntity>().Add(entity);
            // Se confirma la transacción
            _context.SaveChanges();
        }

        public int Count()
        {
            //throw new NotImplementedException();
            return _context.Set<TEntity>().Count();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity GetById<TId>(TId id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity entity)
        {
            // se atacha la entidad al contexto de Entity Framework
            _context.Set<TEntity>().Attach(entity);
            _context.Set<TEntity>().Remove(entity);
            // Se confirma la transacción
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            // se atacha la entidad al contexto de Entity Framework
            _context.Set<TEntity>().Attach(entity);
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            // Se confirma la transacción
            _context.SaveChanges();
        }
    }
}
