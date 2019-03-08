using App.DataAccess.Repository.Interface;
using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace App.DataAccess.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity:class
    {

        protected readonly DbContext _context;

        public GenericRepository(DbContext pContext)
        {
            _context = pContext;
        }

        public void Add(TEntity entity)
        {
            //Se agrega la entidad al contexto de Entity Framework
            _context.Set<TEntity>().Add(entity);

            //Se confirma la transaccion
            _context.SaveChanges();
            
        }

        public int Count()
        {
            return _context.Set<TEntity>().Count();
        }

        public TEntity FindEntity<TId>(Expression<Func<TEntity, bool>> filter)
        {
            return
                    _context.Set<TEntity>().Where(filter).FirstOrDefault();
        }

        public IEnumerable<TEntity> GetAll(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = ""
            )
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties
                   .Split(new char[] { ',' }
                    ,StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }


            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }


        }

        public TEntity GetById<TId>(TId id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Attach(entity);
            _context.Set<TEntity>().Remove(entity);

            //Se confirma la transaccion
            var result = _context.SaveChanges();

        }

        public void Update(TEntity entity)
        {
            //Se atacha la entidad al contexto de Entity Framework
            _context.Set<TEntity>().Attach(entity);
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;

            //Se confirma la transaccion
            var result = _context.SaveChanges();
            
        }
    }
}
