using App.DataAccess.Repository.Interface;
using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccess.Repository
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(DbContext context) : base(context)
        {

        }

        public bool LoginUsuario(Usuario Entity)
        {
            bool result = false;
            IEnumerable<Usuario> resultList = null;

            resultList = _context.Database.SqlQuery<Usuario>
            ("usp_login_usuario @Login @Password",
             new SqlParameter("@Login", Entity.Login),
             new SqlParameter("@Password", Entity.Password)
            ).ToList();

            if (resultList != null)
            {
                result = true;
            }
            return result;
        }
    }
}
