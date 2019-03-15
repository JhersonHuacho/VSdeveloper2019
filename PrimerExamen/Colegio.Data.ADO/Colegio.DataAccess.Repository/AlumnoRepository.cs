using Colegio.DataAcces.Repository.Interfaces;
using Colegio.Entities.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.DataAccess.Repository
{
    public class AlumnoRepository : GenericRepository<Alumno>, IAlumnoRepository
    {
        public AlumnoRepository(DbContext context) : base(context)
        {

        }

        public IEnumerable<Alumno> listarTodosLosAlumnos(string nombre)
        {
            return _context.Database.SqlQuery<Alumno>
                ("usp_listarAlumnos @nombre",
                new SqlParameter("@nombre", nombre)
                ).ToList();

        }
    }
}
