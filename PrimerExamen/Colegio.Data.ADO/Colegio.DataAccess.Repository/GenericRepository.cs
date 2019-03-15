using Colegio.DataAcces.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.DataAccess.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;

        public GenericRepository(DbContext pContext)
        {
            _context = pContext;
        }

        public IEnumerable<TEntity> listarPorNombres<TNombres>(TNombres nombre)
        {
            throw new NotImplementedException();
        }

        //public IEnumerable<TEntity> listarPorNombres<TNombres>(TNombres nombre)
        //{
        //    //var result = _context.Set<TEntity>().Find(nombre);
        //    //return result;
        //}
    }
}
