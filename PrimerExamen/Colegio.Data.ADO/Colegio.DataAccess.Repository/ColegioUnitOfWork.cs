using Colegio.DataAcces.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.DataAccess.Repository
{
    public class ColegioUnitOfWork : IColegioUnitOfWork
    {
        private readonly DbContext _context;

        public ColegioUnitOfWork()
        {
            _context = new ColegioDataModel();
            CreateRepositories();
        }

        private void CreateRepositories()
        {
            this.AlumnoRepository = new AlumnoRepository(_context);
        }

        public IAlumnoRepository AlumnoRepository { get; set; }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
