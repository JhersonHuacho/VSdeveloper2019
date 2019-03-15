using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.DataAcces.Repository.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity:class
    {
        IEnumerable<TEntity> listarPorNombres<TNombres>(TNombres nombre);
    }
}
