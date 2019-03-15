using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.DataAcces.Repository.Interfaces
{
    public interface IColegioUnitOfWork : IDisposable
    {
        IAlumnoRepository AlumnoRepository { get; set; }
    }
}
